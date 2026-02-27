using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text.RegularExpressions;
using CppSharp;
using CppSharp.AST;
using CppSharp.AST.Extensions;
using CppSharp.Generators;
using CppSharp.Passes;
using CppSharp.Types;
using Attribute = CppSharp.AST.Attribute;
using Type = CppSharp.AST.Type;

namespace ShaderSlang.Net.Scripts.CppSharpGenerator.Passes;

internal class GenerateSlangComInterfacesPass : TranslationUnitPass
{
    private readonly HashSet<Class> _processedComInterfaces = [];

    public GenerateSlangComInterfacesPass(BindingContext context)
    {
        context.GeneratorOutputPasses.AddPass(new OutPutPass(_processedComInterfaces));
    }

    public override bool VisitClassDecl(Class visClass)
    {
        if (_processedComInterfaces.Contains(visClass)) return true;

        if (visClass.Name.StartsWith('I') && visClass.IsISlangUnknown())
        {
            TransformNativeToComInterface(visClass);
        }

        return base.VisitClassDecl(visClass);
    }

    public override bool VisitMethodDecl(Method method)
    {
        if(method.Namespace is not Class containingClass) return base.VisitMethodDecl(method);
        if (!_processedComInterfaces.Contains(method.Namespace)) return base.VisitMethodDecl(method);

        if (method.Access is not AccessSpecifier.Public || method is not
            {
                IsConstructor: false, IsDestructor: false, IsOperator: false, IsCopyConstructor: false,
                IsDefaultConstructor: false, IsMoveConstructor: false, IsPure: true, IsVirtual: true
            } || method.OriginalName.Equals("getTypeGuid", StringComparison.OrdinalIgnoreCase) ||
            method.OriginalName.Equals("queryInterface", StringComparison.OrdinalIgnoreCase) ||
            method.OriginalName.Equals("addRef", StringComparison.OrdinalIgnoreCase) ||
            method.OriginalName.Equals("release", StringComparison.OrdinalIgnoreCase))
        {
            containingClass.Methods.Remove(method);
            containingClass.Declarations.Remove(method);
            
            return false;
        }

        method.Body = "";
        method.BodyStmt = null;
        method.IsPure = false;
        AddMethodComAttributes(method);

        method.ExcludeFromPasses.Add(typeof(ParamTypeToInterfacePass));

        if (method.ReturnType.Type.IsPrimitiveType(PrimitiveType.Bool))
        {
            method.Attributes.Add(new ReturnAttribute(CreateMarshalAsAttribute(UnmanagedType.I1)));
        }

        return base.VisitMethodDecl(method);
    }

    public override bool VisitParameterDecl(Parameter param)
    {
        // Safety check: ensure parameter has a valid type
        if (param.Type == null || param.QualifiedType.Type == null)
        {
            Diagnostics.Warning($"Parameter {param.Name} has null type, skipping transformation");
            return false;
        }

        TransformParameterCommon(param);

        return base.VisitParameterDecl(param);
    }

    private void TransformNativeToComInterface(Class visClass)
    {
        // Remove non-ISlangUnknown bases
        var basesToRemove = visClass.Bases.Where(specifier => !specifier.Class.IsISlangUnknown()).ToArray();
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

        AddComInterfaceAttributes(visClass, guid.Value);

        // Add a type map to modify the generated marshalling code for this interface
        Context.TypeMaps.AddTypeMapForClass(visClass, new SlangUnknownTypeMap(visClass, Context));

        _processedComInterfaces.Add(visClass);
    }

    private static Guid? FindInterfaceGuid(Class @class)
    {
        var guidMethod = @class.FindMethod("GetTypeGuid");
        if (guidMethod == null)
        {
            return null;
        }

        var guidNumbers = guidMethod.Body.ReplaceLineBreaks("")
                                    .Replace("return", "")
                                    .Replace(";", "")
                                    .Replace("{", "")
                                    .Replace("}", "")
                                    .Split(',', 11, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                                    .Select(digit => digit.TrimEnd('U'))
                                    .Select(uint.Parse)
                                    .ToArray();

        return new Guid(guidNumbers[0],
                        (ushort)guidNumbers[1],
                        (ushort)guidNumbers[2],
                        (byte)guidNumbers[3],
                        (byte)guidNumbers[4],
                        (byte)guidNumbers[5],
                        (byte)guidNumbers[6],
                        (byte)guidNumbers[7],
                        (byte)guidNumbers[8],
                        (byte)guidNumbers[9],
                        (byte)guidNumbers[10]);
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

    private static void TransformParameterCommon(Parameter param)
    {
        var isOutParam = param.OriginalName.StartsWith("out", StringComparison.OrdinalIgnoreCase);
        var type = param.Type.Desugar();

        if (param.Namespace is not Function function)
        {
            return;
        }

        if (isOutParam && function is { IsInternal: false, Access: AccessSpecifier.Public })
        {
            param.Usage = ParameterUsage.Out;
        }

        if (function is not Method { IsVirtual: true })
        {
            return;
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

    private sealed class OutPutPass(IEnumerable<Class> slangUnknownClasses) : GeneratorOutputPass
    {
        private Regex? _stripPattern;

        public override void VisitGeneratorOutput(GeneratorOutput output)
        {
            // We populate the regex pattern here and not the constructor so this runs after all the passes
            //strips lines like "outDiagnostics = new global::ShaderSlang.Net.Bindings.Generated.ISlangBlob();" since they are illegal.
            var contentToStripFromLines = slangUnknownClasses.Select(@class => $" = new {@class.ToGlobalFullName()}();");

            _stripPattern = new($"^.*({string.Join("|", contentToStripFromLines.Select(Regex.Escape))}).*$",
                                RegexOptions.Multiline);

            base.VisitGeneratorOutput(output);
        }

        public override void HandleBlock(Block block)
        {
            var strBuilder = block.Text.StringBuilder;
            var realizedStr = strBuilder.ToString();


            realizedStr = _stripPattern?.Replace(realizedStr, string.Empty);

            if (realizedStr == null) return;

            strBuilder.Clear();
            strBuilder.Append(realizedStr);

            base.HandleBlock(block);
        }
    }
}

internal sealed class SlangUnknownTypeMap : TypeMap
{
    public override bool DoesMarshalling => true;
    public override bool IsIgnored => false;

    private readonly Class _unknownClass;
    private readonly string _managedTypeName;
    private readonly string _managedMarshallerName;

    public SlangUnknownTypeMap(Class unknownClass, BindingContext context)
    {
        _unknownClass = unknownClass;
        _managedTypeName = unknownClass.ToGlobalFullName();
        _managedMarshallerName = typeof(ComInterfaceMarshaller<>).ToGlobalFullName().Replace("`1", $"<{_managedTypeName}>");

        Type = new TagType(unknownClass);
        Context = context;
    }

    public override Type SignatureType(TypePrinterContext ctx)
    {
        return new CustomType(_managedTypeName);
    }

    public override void MarshalToManaged(MarshalContext ctx)
    {
        ctx.Return.Write($"{_managedMarshallerName}.ConvertToManaged((void*){ctx.ReturnVarName})");
    }

    public override void MarshalToNative(MarshalContext ctx)
    {
        if (ctx.MarshalKind is MarshalKind.Unknown)
        {
            var parameter = ctx.Function?.Parameters[ctx.ParameterIndex];

            if (parameter is null || ctx.ParameterIndex < 0)
            {
                Diagnostics.Warning(
                    $"Unable to determine parameter for marshalling of type {_managedTypeName}, defaulting to null pointer");
                ctx.Return.Write("nint.Zero");
                return;
            }

            if (parameter.Usage == ParameterUsage.Out)
            {
                ctx.Return.Write("stackalloc void* [1]");

                ctx.ArgumentPrefix.Write("(nint)");
                ctx.Cleanup.WriteLine($"{parameter.Name} = {_managedMarshallerName}.ConvertToManaged(*{ctx.ArgName});");

                return;
            }

            if (parameter.Usage == ParameterUsage.In)
            {
                ctx.Return.Write($"(nint){_managedMarshallerName}.ConvertToUnmanaged({parameter.Name})");
                return;
            }
        }

        ctx.Return.Write("(nint)0");
        Diagnostics.Warning($"Marshalling of type {_managedTypeName} is not fully implemented, defaulting to null pointer");
    }
}