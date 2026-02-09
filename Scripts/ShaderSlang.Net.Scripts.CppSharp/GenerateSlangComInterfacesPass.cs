using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using CppSharp;
using CppSharp.AST;
using CppSharp.AST.Extensions;
using CppSharp.Generators;
using CppSharp.Passes;
using CppSharp.Types;
using Attribute = CppSharp.AST.Attribute;
using Type = CppSharp.AST.Type;

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
            Diagnostics.Debug($"Removing non-ISlangUnknown base {baseToRemove.Class.Name} from COM interface {visClass.Name}");
            visClass.Bases.Remove(baseToRemove);
        }

        // Remove IDisposable base if present
        visClass.Bases.RemoveAll(specifier => Equals(specifier.Type, new CILType(typeof(IDisposable))));

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
        var stringMarshalling = nameof(StringMarshalling.Utf8);

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
        
        // Handle pointer types
        if (!type.IsPointer())
        {
            // Non-pointer types: primitives, structs by value, enums
            // Keep as-is, they're already correct
            return;
        }

        var pointee = type.GetPointee().Desugar();
        var isDoublePointer = pointee.IsPointer();
        
        // Determine the final type
        Type finalType;
        Class? finalClass;
        
        if (isDoublePointer)
        {
            // T** -> unwrap to T
            finalType = pointee.GetPointee().Desugar();
        }
        else
        {
            // T* -> unwrap to T
            finalType = pointee;
        }
        
        finalType.TryGetClass(out finalClass);
        var isComInterface = finalClass != null && IsISlangUnknown(finalClass);
        var isPrimitiveType = finalType.IsPrimitiveType() || finalType.IsEnumType();
        var isVoidType = finalType.IsPrimitiveType(PrimitiveType.Void);

        // Case 1: void** outParam (void double pointer - common in COM QueryInterface)
        // Examples: void** outObject
        // Transform to: out nint outObject
        if (isDoublePointer && isVoidType)
        {
            param.Usage = ParameterUsage.Out;
            param.QualifiedType = new(new BuiltinType(PrimitiveType.IntPtr), param.QualifiedType.Qualifiers);
            return;
        }

        // Case 2: T** outParam (double pointer with "out" prefix)
        // Examples: ISlangBlob** outBlob, IDevice** outDevice
        // Transform to: out T outParam (nullable if optional)
        if (isDoublePointer && isOutParam)
        {
            param.Usage = ParameterUsage.Out;
            param.QualifiedType = new QualifiedType(finalType, param.QualifiedType.Qualifiers);
            return;
        }

        // Case 3: void* param (single void pointer)
        // Examples: void* userData, void* pData
        // Transform to: nint userData (or out nint if has "out" prefix)
        if (!isDoublePointer && isVoidType)
        {
            if (isOutParam)
            {
                Diagnostics.Error("Parameter {param.OriginalName} is a single void pointer with 'out' prefix, which is not a valid COM pattern. Consider changing it to a double pointer (void**) or removing the 'out' prefix.");
            }
            param.QualifiedType = new(new BuiltinType(PrimitiveType.IntPtr), param.QualifiedType.Qualifiers);
            return;
        }

        // Case 4: T* outParam (single pointer with "out" prefix) 
        // Examples: int* outCount, Format* outFormat
        // Transform to: out T outParam
        if (!isDoublePointer && isOutParam)
        {
            param.Usage = ParameterUsage.Out;
            param.QualifiedType = new QualifiedType(finalType, param.QualifiedType.Qualifiers);
            return;
        }

        // Case 5: const T* param (single pointer, const, no "out" prefix)
        // Examples: const SubresourceData* initData
        // Transform to: scoped ref readonly T param or in T param
        var pointeeQualified = ((PointerType)type).QualifiedPointee;
        if (!isDoublePointer && pointeeQualified.Qualifiers.IsConst)
        {
            param.Usage = ParameterUsage.In;
            param.QualifiedType = new QualifiedType(finalType, param.QualifiedType.Qualifiers);
            return;
        }

        // Case 6: T* param (single pointer, non-const, no "out" prefix)
        // Examples: byte* initData for buffers, spans
        // Transform to: ref T param or in T param (for single element)
        // OR Span<T> for array-like parameters
        if (!isDoublePointer && !isOutParam)
        {
            // Check if this is an array parameter by looking for count/size parameters
            var function = param.Namespace as Function;
            var hasCountParam = function?.Parameters.Any(p => 
                p.OriginalName.Contains("count", StringComparison.OrdinalIgnoreCase) ||
                p.OriginalName.Contains("size", StringComparison.OrdinalIgnoreCase) ||
                p.OriginalName.Contains("num", StringComparison.OrdinalIgnoreCase)) ?? false;

            if (hasCountParam && isPrimitiveType)
            {
                // Array parameter -> use Span<T>
                // The marshaller will handle this via MarshalUsing attribute
                // Keep as pointer for now, let custom marshalling handle it
                return;
            }
            else
            {
                // Single element reference parameter
                param.Usage = ParameterUsage.InOut;
                param.QualifiedType = new QualifiedType(finalType, param.QualifiedType.Qualifiers);
                return;
            }
        }

        // Case 7: COM interface* (single pointer to COM interface, no "out")
        // Examples: ITextureResource* texture (input parameter)
        // Keep as-is, COM interfaces are reference types
        if (!isDoublePointer && isComInterface && !isOutParam)
        {
            param.QualifiedType = new QualifiedType(finalType, param.QualifiedType.Qualifiers);
        }
    }
}

internal class ComInterfaceTypeMap : TypeMap
{
    public override void MarshalToManaged(MarshalContext ctx)
    {
        base.MarshalToManaged(ctx);
    }
}