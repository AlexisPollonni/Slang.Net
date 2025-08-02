using CodeGenHelpers;
using Microsoft.CodeAnalysis;

namespace SlangNet.Pretty.SourceGenerator.Tooling.Extensions;

static class CodeWriterExtensions
{
    public static InvokeBuilder BuildMethodInvoke(this ICodeWriter writer, IMethodSymbol method) =>
        new(writer, method);

    public static ICodeWriter WriteVariableDeclaration(this ICodeWriter writer,
                                                       string type,
                                                       string name,
                                                       string? value = null)
    {
        writer.Append($"{type} {name}");
        if (value is not null) writer.AppendUnindented($" = {value}");
        return writer;
    }

    public static ICodeWriter WriteVariableDeclaration(this ICodeWriter writer,
                                                       ITypeSymbol type,
                                                       string name,
                                                       string? value = null)
    {
        return writer.WriteVariableDeclaration(type.ToFullyQualified(), name, value);
    }

    public static ICodeWriter EndLine(this ICodeWriter writer)
    {
        writer.AppendUnindentedLine(";");
        return writer;
    }
}