using CppSharp.AST;
using Microsoft.CodeAnalysis;

namespace ShaderSlang.Net.Scripts.CppSharpGenerator.Passes;

internal sealed partial class SyntaxCodeGeneratorPass
{
    public SyntaxNode? VisitParameterDecl(Parameter parameter) =>
        throw new NotImplementedException();
    public SyntaxNode? VisitEnumItemDecl(Enumeration.Item item) =>
        throw new NotImplementedException();

}