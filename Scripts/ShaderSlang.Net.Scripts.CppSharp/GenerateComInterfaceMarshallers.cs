using System.Runtime.InteropServices.Marshalling;
using CppSharp;
using CppSharp.AST;
using CppSharp.Passes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Attribute = CppSharp.AST.Attribute;

namespace ShaderSlang.Net.Scripts.CppSharp;

internal sealed class GenerateComInterfaceMarshallers : TranslationUnitPass
{
    private OutputPass? _outputPass;

    public override bool VisitClassDecl(Class visClass)
    {
        if (ASTContext.IsISlangUnknown(visClass))
            return false;
        
        if (visClass.Attributes.Any(attribute => attribute.Type == typeof(NativeMarshallingAttribute)))
            return false;

        if (visClass is { IsStatic: false, Ignore: false, IsRefType: true })
        {
            if (_outputPass is null)
            {
                _outputPass = new();
                Context.GeneratorOutputPasses.AddPass(_outputPass);
            }

            visClass.Attributes.Add(CreateNativeMarshallingAttribute(visClass));
            
            _outputPass.ClassesToMarshal.Add(visClass);
            
            if (visClass.Name.EndsWith("Desc")) visClass.IsPOD = true;
        }

        return base.VisitClassDecl(visClass);
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

            var classDecl = root.DescendantNodesAndSelf().OfType<ClassDeclarationSyntax>().FirstOrDefault();
            if (classDecl is null) return;

            var name = classDecl.Identifier.Text;

            var marshalledClass = ClassesToMarshal.FirstOrDefault(visClass => visClass.Name == name);
            if (marshalledClass is null)
                return;

            const MarshalMode marshalMode = MarshalMode.Default;

            var managedTypeName = marshalledClass.ToGlobalFullName();
            var marshallerTypeName = $"{marshalledClass.Name}Marshaller";
            var marshallerAttributeTypeName = typeof(CustomMarshallerAttribute).ToGlobalFullName();

            var marshalModeText = typeof(MarshalMode).ToGlobalFullName() + "." + marshalMode;

            var generatedClass = $$"""
                                   [{{marshallerAttributeTypeName}}(typeof({{managedTypeName}}), {{marshalModeText}}, typeof({{marshallerTypeName}}))]
                                   internal unsafe static partial class {{marshallerTypeName}}
                                   {
                                       public static {{managedTypeName}} ConvertToManaged(void* native)
                                       {
                                           if (native == null)
                                               return null;
                                           return {{managedTypeName}}.__GetOrCreateInstance(new __IntPtr(native), saveInstance: false);
                                       }

                                       public static void* ConvertToUnmanaged({{managedTypeName}} managed)
                                       {
                                           if (managed == null)
                                               return null;
                                           return managed.__Instance.ToPointer();
                                       }
                                   }
                                   """;

            var indentation = block.Blocks.LastOrDefault()?.Text.CurrentIndentation ?? 0;

            var textGenerator = new TextGenerator
            {
                IsStartOfLine =  true,
                CurrentIndentation = indentation
            };
            
            textGenerator.WriteLine($"[{marshallerAttributeTypeName}(typeof({managedTypeName}), {marshalModeText}, typeof({marshallerTypeName}))]");
            textGenerator.WriteLine($"internal unsafe static partial class {marshallerTypeName}");
            textGenerator.WriteOpenBraceAndIndent();
            
            
            textGenerator.WriteLine($"public static {managedTypeName} ConvertToManaged(void* native)");
            textGenerator.WriteOpenBraceAndIndent();
            
            // ConvertToManaged body
            textGenerator.WriteLine("if (native == null)");
            textGenerator.Indent();
            textGenerator.WriteLine("return null;");
            textGenerator.Unindent();
            
            textGenerator.WriteLine($"return {managedTypeName}.__GetOrCreateInstance(new __IntPtr(native), saveInstance: false);");
            
            textGenerator.UnindentAndWriteCloseBrace();
            
            
            textGenerator.WriteLine($"public static void* ConvertToUnmanaged({managedTypeName} managed)");
            textGenerator.WriteOpenBraceAndIndent();
            // ConvertToUnmanaged body
            textGenerator.WriteLine("if (managed == null)");
            textGenerator.Indent();
            textGenerator.WriteLine("return null;");
            textGenerator.Unindent();
            textGenerator.WriteLine("return managed.__Instance.ToPointer();");
            textGenerator.UnindentAndWriteCloseBrace();
            
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