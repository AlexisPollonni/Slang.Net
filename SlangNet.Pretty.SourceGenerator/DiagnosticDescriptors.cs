using Microsoft.CodeAnalysis;

namespace SlangNet.Pretty.SourceGenerator;

internal static class DiagnosticDescriptors
{
    private const string Category = "SlangNet";

    public static readonly DiagnosticDescriptor InvalidAttributeArguments = new(
        id: "SLANG001",
        title: "Invalid marshalling attribute arguments",
        messageFormat: "The GenerateMarshallingCodeAttribute requires valid type and method name arguments",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true);

    public static readonly DiagnosticDescriptor NativeMethodNotFound = new(
        id: "SLANG002",
        title: "Native method not found",
        messageFormat: "Could not find native method {0} in type {1}",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true);

    public static readonly DiagnosticDescriptor OutParameterMismatch = new(
        id: "SLANG003",
        title: "Out parameter mismatch",
        messageFormat: "Out parameter '{0}' has no corresponding native parameter",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true);

    public static readonly DiagnosticDescriptor InvalidOutParameterType = new(
        id: "SLANG004",
        title: "Invalid out parameter type",
        messageFormat: "Out parameter '{0}' must correspond to a double pointer in native code, but found '{1}'",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true);
} 