using System.Runtime.InteropServices.Marshalling;
using CppSharp;
using CppSharp.AST;
using CppSharp.AST.Extensions;
using CppSharp.Generators;
using CppSharp.Passes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Attribute = CppSharp.AST.Attribute;

namespace ShaderSlang.Net.Scripts.CppSharpGenerator.Passes;

internal sealed class GenerateComInterfaceMarshallersPass : TranslationUnitPass
{
    private OutputPass? _outputPass;

    public override bool VisitClassDecl(Class visClass)
    {
        if (visClass.IsISlangUnknown()) return base.VisitClassDecl(visClass);

        if (visClass.Attributes.Any(attribute => attribute.Type == typeof(NativeMarshallingAttribute))) return false;

        if (visClass is { IsStatic: false, Ignore: false })
        {
            if (_outputPass is null)
            {
                _outputPass = new();
                Context.GeneratorOutputPasses.AddPass(_outputPass);
            }

            visClass.Attributes.Add(CreateNativeMarshallingAttribute(visClass));

            _outputPass.ClassesToMarshal.Add(visClass);

            if (visClass.Name.EndsWith("Desc") || visClass.Name.EndsWith("Flag"))
            {
                visClass.Type = ClassType.ValueType;
                visClass.IsPOD = true;
            }
        }

        return base.VisitClassDecl(visClass);
    }

    public override bool VisitParameterDecl(Parameter parameter)
    {
        if (parameter.Namespace is Method method && method.Namespace is Class parentClass &&
            parentClass.IsISlangUnknown())
        {
            var final = parameter.Type.SkipPointerRefs();
            
            final.TryGetClass(out var paramPointeeClass);
            if (paramPointeeClass is not null && paramPointeeClass.IsValueType)
            {
                parameter.QualifiedType = new(new PointerType(new QualifiedType(final))
                                                  { Modifier = PointerType.TypeModifier.RVReference });
            }
        }

        return base.VisitParameterDecl(parameter);
    }

    private static Attribute CreateNativeMarshallingAttribute(Class marshalledType)
    {
        var value = $"typeof({marshalledType.ToGlobalFullName()}.{marshalledType.Name}Marshaller)";

        return new()
        {
            Type = typeof(NativeMarshallingAttribute),
            Value = value
        };
    }

    private sealed class OutputPass : GeneratorOutputPass
    {
        internal List<Class> ClassesToMarshal { get; } = [];

        public override void VisitClass(Block block)
        {
            var tree = CSharpSyntaxTree.ParseText(block.Generate().ToString());
            var root = tree.GetRoot();

            var classDecl = root.DescendantNodesAndSelf()
                                .OfType<ClassDeclarationSyntax>()
                                .Cast<TypeDeclarationSyntax>()
                                .FirstOrDefault();
            var structDecl = root.DescendantNodesAndSelf()
                                 .OfType<StructDeclarationSyntax>()
                                 .Cast<TypeDeclarationSyntax>()
                                 .FirstOrDefault();

            var typeDecl = classDecl ?? structDecl;
            if (typeDecl is null) return;

            var name = typeDecl.Identifier.Text;

            var marshalledClass = ClassesToMarshal.FirstOrDefault(visClass => visClass.Name == name);
            if (marshalledClass is null) return;

            const MarshalMode marshalMode = MarshalMode.Default;

            var managedTypeName = marshalledClass.ToGlobalFullName();
            var marshallerTypeName = $"{marshalledClass.Name}Marshaller";
            var marshallerAttributeTypeName = typeof(CustomMarshallerAttribute).ToGlobalFullName();

            var marshalModeText = typeof(MarshalMode).ToGlobalFullName() + "." + marshalMode;

            var indentation = block.Blocks.LastOrDefault()?.Text.CurrentIndentation ?? 0;

            var optionalNull = marshalledClass.IsRefType ? "" : "?";

            var textGenerator = new TextGenerator
            {
                IsStartOfLine = true,
                CurrentIndentation = indentation
            };

            textGenerator.WriteLine(
                $"[{marshallerAttributeTypeName}(typeof({managedTypeName}{optionalNull}), {marshalModeText}, typeof({marshallerTypeName}))]");
            textGenerator.WriteLine($"internal unsafe static partial class {marshallerTypeName}");
            textGenerator.WriteOpenBraceAndIndent();


            textGenerator.WriteLine($"public static {managedTypeName}{optionalNull} ConvertToManaged(void* native)");
            textGenerator.WriteOpenBraceAndIndent();

            // ConvertToManaged body
            textGenerator.WriteLine("if (native is null)");
            textGenerator.Indent();
            textGenerator.WriteLine("return null;");
            textGenerator.Unindent();

            textGenerator.WriteLine(marshalledClass.IsValueType
                                        ? $"return {managedTypeName}.__CreateInstance(new __IntPtr(native));"
                                        : $"return {managedTypeName}.__GetOrCreateInstance(new __IntPtr(native), saveInstance: false);");

            textGenerator.UnindentAndWriteCloseBrace();

            if (marshalledClass.IsValueType)
            {
                textGenerator.WriteLine(
                    $"public static ref __Internal GetPinnableReference({managedTypeName}? managed) => ref managed.Value.__Instance;");
            }
            else
            {
                textGenerator.WriteLine($"public static void* ConvertToUnmanaged({managedTypeName} managed)");
                textGenerator.WriteOpenBraceAndIndent();
                // ConvertToUnmanaged body
                textGenerator.WriteLine("if (managed is null)");
                textGenerator.Indent();
                textGenerator.WriteLine("return null;");
                textGenerator.Unindent();
                textGenerator.WriteLine("return managed.__Instance.ToPointer();");
                textGenerator.UnindentAndWriteCloseBrace();
            }

            textGenerator.UnindentAndWriteCloseBrace();

            block.Blocks.Add(new(BlockKind.Class)
            {
                Parent = block,
                Text = textGenerator,
                NewLineKind = NewLineKind.BeforeNextBlock,
                NeedsNewLine = true,
            });

            base.VisitClass(block);
        }
    }
}


internal sealed class FormatGeneratedCode : GeneratorOutputPass
{
    public override void VisitGeneratorOutput(GeneratorOutput output)
    {
        foreach (var codeGenerator in output.Outputs)
        {
            var generatedCode = codeGenerator.Generate();
            
            var tree = CSharpSyntaxTree.ParseText(generatedCode);

            tree.GetRoot();
        }
    }
} 