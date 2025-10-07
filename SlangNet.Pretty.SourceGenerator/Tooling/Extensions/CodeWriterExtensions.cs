using CodeGenHelpers;
using Microsoft.CodeAnalysis;

namespace SlangNet.Pretty.SourceGenerator.Tooling.Extensions;

static class CodeWriterExtensions
{
    extension(ICodeWriter writer)
    {
        public InvokeBuilder BuildMethodInvoke(IMethodSymbol method) =>
            new(writer, method);

        public ICodeWriter WriteVariableDeclaration(string type,
                                                    string name,
                                                    string? value = null)
        {
            writer.Append($"{type} {name}");
            if (value is not null) writer.AppendUnindented($" = {value}");
            return writer;
        }

        public ICodeWriter WriteVariableDeclaration(ITypeSymbol type,
                                                    string name,
                                                    string? value = null)
        {
            return writer.WriteVariableDeclaration(type.ToFullyQualified(), name, value);
        }

        public ICodeWriter EndLine()
        {
            writer.AppendUnindentedLine(";");
            return writer;
        }
    }
}