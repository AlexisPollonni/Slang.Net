using System.Diagnostics.CodeAnalysis;
using CppSharp;
using CppSharp.AST;
using CppSharp.Generators;
using CppSharp.Passes;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Attribute = CppSharp.AST.Attribute;

namespace ShaderSlang.Net.Scripts.CppSharp;

[SuppressMessage("Performance", "CA1860:Avoid using \'Enumerable.Any()\' extension method")]
internal sealed class FixParametersMissingAttributesPass : TranslationUnitPass
{
    private readonly OutputPass _outputPass;

    public FixParametersMissingAttributesPass(BindingContext context)
    {
        _outputPass = new();

        context.GeneratorOutputPasses.AddPass(_outputPass);
    }

    public override bool VisitParameterDecl(Parameter parameter)
    {
        if (parameter.Attributes.Count <= 0) return base.VisitParameterDecl(parameter);

        _outputPass.ParametersToTransform.Add(parameter);
        return true;
    }

    public override bool VisitMethodDecl(Method method)
    {
        var returnAtts = method.Attributes.OfType<ReturnAttribute>();
        if (!returnAtts.Any()) return base.VisitMethodDecl(method);

        _outputPass.MethodsWithReturnToTransform.Add(method);
        return true;
    }


    private sealed class OutputPass : GeneratorOutputPass
    {
        public List<Parameter> ParametersToTransform { get; } = [];
        public List<Method> MethodsWithReturnToTransform { get; } = [];

        public override void VisitMethod(Block block)
        {
            if (block.Parent.Kind is not BlockKind.Interface)
                return;
            var tree = CSharpSyntaxTree.ParseText(block.Text.ToString());

            tree.TryGetRoot(out var root);

            if (root is null) return;

            var descendants = root.DescendantNodesAndSelf();
            var definedMethod = descendants.OfType<LocalFunctionStatementSyntax>().FirstOrDefault();

            if (definedMethod is null) return;

            var currentMethodName = definedMethod.Identifier.Text;
            var currentMethod = ParametersToTransform
                .Select(parameter => parameter.Namespace)
                .OfType<Method>()
                .Union(MethodsWithReturnToTransform)
                .FirstOrDefault(method => method.Name == currentMethodName);

            if (currentMethod is null) return;

            var newRoot = root.ReplaceNode(definedMethod, TransformMethodSyntax(definedMethod, currentMethod));

            var newBlockText = newRoot.ToFullString();

            block.Text.StringBuilder.Clear();
            block.Text.StringBuilder.Append(newBlockText);

            base.VisitMethod(block);
        }

        private LocalFunctionStatementSyntax TransformMethodSyntax(LocalFunctionStatementSyntax methodSyntax,
            Method method)
        {
            if (!method.Parameters.Select(p => p.Name)
                    .SequenceEqual(methodSyntax.ParameterList.Parameters.Select(p => p.Identifier.Text)))
            {
                Diagnostics.Warning(
                    $"Method {method.Name} has parameters that do not match the syntax parameters, skipping transformation");
                return methodSyntax;
            }

            var parameterToNode = method.Parameters.Zip(methodSyntax.ParameterList.Parameters).ToDictionary();

            // Transforms syntax of method parameters that are missing attributes, and collects modified syntax nodes to be replaced in the method syntax tree
            var modifiedParamAttrs = parameterToNode.Keys.Intersect(ParametersToTransform)
                .Select(parameter => (Parameter: parameter, ParameterSyntax: parameterToNode[parameter]))
                .Select(tuple => Modified(tuple.ParameterSyntax,
                    TransformParameterSyntax(tuple.ParameterSyntax, tuple.Parameter)));


            var returnAttributes = method.Attributes.OfType<ReturnAttribute>().ToArray();

            // Transforms syntax of method return attributes, and collects modified syntax nodes to be replaced in the method syntax tree
            var modifiedReturnAttrs = methodSyntax.AttributeLists
                .Where(AttributeListMatchesReturnTarget)
                .Select(att => Modified(att, AttributeListToReturnTarget(att)));

            var modifiedNodes = modifiedParamAttrs.Union(modifiedReturnAttrs).ToDictionary();
            
            return methodSyntax.ReplaceNodes(modifiedNodes.Keys, (syntax, _) => modifiedNodes[syntax]);

            static (SyntaxNode Original, SyntaxNode Modified) Modified(SyntaxNode original, SyntaxNode modified) =>
                (original, modified);

            bool AttributeListMatchesReturnTarget(AttributeListSyntax attributeListSyntax)
            {
                return attributeListSyntax.Attributes.Any(attributeSyntax => 
                    returnAttributes.Any(attr => MatchAttributeToSyntax(attributeSyntax, attr)));
            }
        }

        private static AttributeListSyntax AttributeListToReturnTarget(AttributeListSyntax attributeListSyntax)
        {
            return attributeListSyntax.WithTarget(
                SyntaxFactory.AttributeTargetSpecifier(SyntaxFactory.Token(SyntaxKind.ReturnKeyword)
                ).WithTrailingTrivia(SyntaxFactory.Space));
        }

        private static bool MatchAttributeToSyntax(AttributeSyntax attrSyntax, Attribute attribute)
        {
            var attrName = attrSyntax.Name.ToString();
            if (!attribute.Type.ToGlobalFullName().Contains(attrName)) return false;

            var expectedArgs = AttributeToSyntax(attribute).ArgumentList?.Arguments ?? [];
            var actualArgs = attrSyntax.ArgumentList?.Arguments ?? [];

            return expectedArgs.Select(a => a.ToString())
                .SequenceEqual(actualArgs.Select(a => a.ToString()));
            ;
        }

        private static ParameterSyntax TransformParameterSyntax(ParameterSyntax syntaxParameter, Parameter parameter)
        {
            if (syntaxParameter.AttributeLists.Count > 0) return syntaxParameter;

            var attributesToAdd = parameter.Attributes.Select(AttributeToSyntax).ToArray();

            if (attributesToAdd.Length == 0) return syntaxParameter;

            var attributeList = SyntaxFactory.AttributeList().AddAttributes(attributesToAdd)
                .WithTrailingTrivia(SyntaxFactory.Space);

            return syntaxParameter.AddAttributeLists(attributeList);
        }

        private static AttributeSyntax AttributeToSyntax(Attribute attribute)
        {
            var attributeName = attribute.Type.ToGlobalFullName().Replace("Attribute", "");
            var attributeArgs = SyntaxFactory.ParseAttributeArgumentList($"({attribute.Value})");
            return SyntaxFactory.Attribute(SyntaxFactory.ParseName(attributeName), attributeArgs);
        }
    }
}