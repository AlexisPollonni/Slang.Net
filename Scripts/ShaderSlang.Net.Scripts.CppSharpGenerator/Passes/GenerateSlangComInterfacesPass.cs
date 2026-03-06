using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text.RegularExpressions;
using CppSharp;
using CppSharp.AST;
using CppSharp.Generators;
using CppSharp.Passes;
using CppSharp.Types;
using Attribute = CppSharp.AST.Attribute;
using Type = CppSharp.AST.Type;

namespace ShaderSlang.Net.Scripts.CppSharpGenerator.Passes;

internal class GenerateSlangComInterfacesPass : TranslationUnitPass
{
    public override bool VisitClassDecl(Class visClass)
    {
        if (!visClass.Name.StartsWith('I') || !visClass.IsISlangUnknown())
            return false;

        if (!Visited.Contains(visClass))
            TransformNativeToComInterface(visClass);

        return base.VisitClassDecl(visClass);
    }

    public override bool VisitMethodDecl(Method method)
    {
        if (
            method.Access is not AccessSpecifier.Public
            || method.IsConstructor
            || method.IsDestructor
            || method.IsOperator
            || method.IsCopyConstructor
            || method.IsDefaultConstructor
            || method.IsMoveConstructor
            || method.IsInline
            || !method.IsPure
            || !method.IsVirtual
        )
        {
            method.ExplicitlyIgnore();
            Diagnostics.Debug(
                $"Skipping method {method.QualifiedLogicalOriginalName}, is not part of the COM interface"
            );

            return false;
        }

        if (
            method.OriginalName.Equals("getTypeGuid", StringComparison.OrdinalIgnoreCase)
            || method.OriginalName.Equals("queryInterface", StringComparison.OrdinalIgnoreCase)
            || method.OriginalName.Equals("addRef", StringComparison.OrdinalIgnoreCase)
            || method.OriginalName.Equals("release", StringComparison.OrdinalIgnoreCase)
        )
        {
            method.ExplicitlyIgnore();

            Diagnostics.Debug(
                $"Skipping method {method.QualifiedLogicalOriginalName}, is a special COM method that is handled by COM interop generator"
            );

            return false;
        }

        method.Body = "";
        method.BodyStmt = null;
        method.IsPure = false;
        method.IsVirtual = false;
        AddMethodComAttributes(method);

        method.ExcludeFromPasses.Add(typeof(ParamTypeToInterfacePass));

        return base.VisitMethodDecl(method);
    }

    private static void TransformNativeToComInterface(Class visClass)
    {
        // Remove non-ISlangUnknown bases
        var basesToRemove = visClass
            .Bases.Where(specifier => !specifier.Class.IsISlangUnknown())
            .ToArray();
        foreach (var baseToRemove in basesToRemove)
        {
            Diagnostics.Debug(
                $"Removing non-ISlangUnknown base {baseToRemove.Class.Name} from COM interface {visClass.Name}"
            );
            visClass.Bases.Remove(baseToRemove);
        }

        visClass.Properties.Clear();
        visClass.Fields.Clear();
        visClass.OriginalClass = visClass;
        visClass.IsAbstract = false;

        visClass.ExcludeFromPasses.Add(typeof(GetterSetterToPropertyPass));

        visClass.Type = ClassType.Interface;

        var guid = FindInterfaceGuid(visClass);
        if (guid is null)
        {
            guid = Guid.Empty;
            Diagnostics.Warning(
                $"COM interface {visClass.Name} is missing GetTypeGuid method, using empty GUID"
            );
        }

        AddComInterfaceAttributes(visClass, guid.Value);
    }

    private static Guid? FindInterfaceGuid(Class @class)
    {
        var guidMethod = @class.FindMethod("getTypeGuid");
        if (guidMethod == null)
        {
            return null;
        }

        var guidNumbers = guidMethod
            .Body.ReplaceLineBreaks("")
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

    private static void AddMethodComAttributes(Method method)
    {
        var preserveSigAttr = new Attribute { Type = typeof(PreserveSigAttribute) };

        //TODO: Change call conv on diff platforms, windows uses Stdcall and unix uses Cdecl
        var callconv = typeof(CallConvStdcall);

        var callconvAttr = new Attribute
        {
            Type = typeof(UnmanagedCallConvAttribute),
            Value = $"CallConvs = [typeof({callconv.FullName})]",
        };

        method.Attributes.AddRange(preserveSigAttr, callconvAttr);
    }

    private static void AddComInterfaceAttributes(Class comInterface, Guid guid)
    {
        var stringMarshalling =
            $"global::{typeof(StringMarshalling).FullName}.{nameof(StringMarshalling.Utf8)}";

        var generatedComInterfaceAttr = new Attribute
        {
            //TODO: custom string marshalling
            Type = typeof(GeneratedComInterfaceAttribute),
            Value = $"StringMarshalling = {stringMarshalling}",
        };

        var guidAttr = new Attribute { Type = typeof(GuidAttribute), Value = $"\"{guid:D}\"" };

        comInterface.Attributes.AddRange(guidAttr, generatedComInterfaceAttr);
    }
}
