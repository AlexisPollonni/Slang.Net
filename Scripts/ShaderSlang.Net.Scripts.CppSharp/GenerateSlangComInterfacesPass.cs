using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using CppSharp;
using CppSharp.AST;
using CppSharp.AST.Extensions;
using CppSharp.Generators.C;
using CppSharp.Generators.CSharp;
using CppSharp.Passes;
using Attribute = CppSharp.AST.Attribute;

namespace ShaderSlang.Net.Scripts.CppSharp;

internal class GenerateSlangComInterfacesPass : TranslationUnitPass
{
    private readonly Dictionary<Class, Class> _originalToComInterfaceMap = [];

    public override bool VisitClassDecl(Class visClass)
    {
        if (_originalToComInterfaceMap.ContainsKey(visClass)) return true;

        if (!visClass.Name.StartsWith('I'))
            return true;

        if (!IsISlangUnknown(visClass))
            return true;


        // Remove non-ISlangUnknown bases
        var basesToRemove = visClass.Bases.Where(specifier => !IsISlangUnknown(specifier.Class)).ToArray();
        foreach (var baseToRemove in basesToRemove)
        {
            Diagnostics.Debug(
                $"Removing non-ISlangUnknown base {baseToRemove.Class.Name} from COM interface {visClass.Name}");
            visClass.Bases.Remove(baseToRemove);
        }

        // Remove IDisposable base if present
        visClass.Bases.RemoveAll(specifier => Equals(specifier.Type, new CILType(typeof(IDisposable))));
        visClass.Properties.Clear();
        visClass.Fields.Clear();
        visClass.OriginalClass = visClass;
        visClass.IsAbstract = false;

        visClass.ExcludeFromPasses.Add(typeof(GetterSetterToPropertyPass));

        // Mark as interface type WITHOUT clearing layout/fields
        visClass.Type = ClassType.Interface;

        // Don't clear Fields or Layout - CppSharp needs these for internal bookkeeping
        // The interface generator will ignore them anyway

        var guid = FindInterfaceGuid(visClass);
        if (guid is null)
        {
            guid = Guid.Empty;
            Diagnostics.Warning($"COM interface {visClass.Name} is missing GetTypeGuid method, using empty GUID");
        }

        // Transform methods in-place without removing them from the class
        var transformedMethods = TransformMethodsToComInterfaceMethods(visClass.Methods).ToList();

        // Replace the methods list with only the transformed methods
        // Keep them in Declarations to maintain proper parent references
        var methodsToRemove = visClass.Methods.Except(transformedMethods).ToArray();
        foreach (var method in methodsToRemove)
        {
            visClass.Methods.Remove(method);
            visClass.Declarations.Remove(method);
        }

        AddComInterfaceAttributes(visClass, guid.Value);

        _originalToComInterfaceMap[visClass] = visClass;

        return base.VisitClassDecl(visClass);
    }

    private static Guid? FindInterfaceGuid(Class @class)
    {
        var guidMethod = @class.FindMethod("GetTypeGuid");
        if (guidMethod == null)
        {
            return null;
        }

        var guidNumbers = guidMethod.Body
            .ReplaceLineBreaks("")
            .Replace("return", "")
            .Replace(";", "")
            .Replace("{", "")
            .Replace("}", "")
            .Split(',', 11, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(digit => digit.TrimEnd('U'))
            .Select(uint.Parse)
            .ToArray();

        return new Guid(
            guidNumbers[0],
            (ushort)guidNumbers[1],
            (ushort)guidNumbers[2],
            (byte)guidNumbers[3],
            (byte)guidNumbers[4],
            (byte)guidNumbers[5],
            (byte)guidNumbers[6],
            (byte)guidNumbers[7],
            (byte)guidNumbers[8],
            (byte)guidNumbers[9],
            (byte)guidNumbers[10]
        );
    }

    private static Class FindISlangUnknown(ASTContext ctx)
    {
        return ctx.FindClass("ISlangUnknown").Single();
    }

    private bool IsISlangUnknown(Class potential)
    {
        var slangUnknown = FindISlangUnknown(Context.ASTContext);

        return potential == slangUnknown || potential.Bases.Any(b => IsISlangUnknown(b.Class));
    }

    private static void AddMethodComAttributes(Method method)
    {
        var preserveSigAttr = new Attribute { Type = typeof(PreserveSigAttribute) };

        //TODO: Change call conv on diff platforms, windows uses Stdcall and unix uses Cdecl
        var callconv = typeof(CallConvStdcall);

        var callconvAttr = new Attribute
        {
            Type = typeof(UnmanagedCallConvAttribute),
            Value = $"CallConvs = [typeof({callconv.FullName})]"
        };

        method.Attributes.AddRange(preserveSigAttr, callconvAttr);
    }

    private static void AddComInterfaceAttributes(Class comInterface, Guid guid)
    {
        var stringMarshalling = $"global::{typeof(StringMarshalling).FullName}.{nameof(StringMarshalling.Utf8)}";

        var generatedComInterfaceAttr = new Attribute
        {
            //TODO: custom string marshalling
            Type = typeof(GeneratedComInterfaceAttribute),
            Value = $"StringMarshalling = {stringMarshalling}"
        };

        var guidAttr = new Attribute
        {
            Type = typeof(GuidAttribute),
            Value = $"\"{guid:D}\""
        };

        comInterface.Attributes.AddRange(guidAttr, generatedComInterfaceAttr);
    }

    private IEnumerable<Method> TransformMethodsToComInterfaceMethods(IEnumerable<Method> methods)
    {
        var methodsToTransform = methods.Where(m =>
                m.Access == AccessSpecifier.Public && m is
                    { IsConstructor: false, IsDestructor: false, IsOperator: false })
            .GroupBy(method => method.OriginalName, StringComparer.OrdinalIgnoreCase)
            .Select(grpMethods => grpMethods.FirstOrDefault(m => !(m.IsVirtual || m.IsPure)) ?? grpMethods.First())
            .SkipWhile(method => method.Name is "GetTypeGuid") //skip COM methods not part of interface
            .ToArray();

        foreach (var method in methodsToTransform)
        {
            method.Body = "";
            method.BodyStmt = null;
            method.IsPure = false;
            AddMethodComAttributes(method);

            method.ExcludeFromPasses.Add(typeof(ParamTypeToInterfacePass));

            foreach (var methodParameter in method.Parameters)
            {
                TransformParameter(methodParameter);
            }

            if (method.ReturnType.Type.IsPrimitiveType(PrimitiveType.Bool))
            {
                method.Attributes.Add(new ReturnAttribute(CreateMarshalAsAttribute(UnmanagedType.I1)));
            }
        }

        return methodsToTransform;
    }

    private void TransformParameter(Parameter param)
    {
        // Safety check: ensure parameter has a valid type
        if (param.Type == null || param.QualifiedType.Type == null)
        {
            Diagnostics.Warning($"Parameter {param.Name} has null type, skipping transformation");
            return;
        }

        var isOutParam = param.OriginalName.StartsWith("out", StringComparison.OrdinalIgnoreCase);
        var type = param.Type.Desugar();

        if (isOutParam)
        {
            param.Usage = ParameterUsage.Out;
        }

        if (type.IsPrimitiveType(PrimitiveType.Bool))
        {
            param.Attributes.Add(CreateMarshalAsAttribute(UnmanagedType.I1));
        }
    }
    
    private static Attribute CreateMarshalAsAttribute(UnmanagedType unmanagedType)
    {
        return new()
        {
            Type = typeof(MarshalAsAttribute),
            Value = $"{typeof(UnmanagedType).ToGlobalFullName()}.{unmanagedType}"
        };
    }
}