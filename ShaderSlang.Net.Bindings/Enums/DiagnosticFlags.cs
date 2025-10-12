using static ShaderSlang.Net.Bindings.Generated.SlangApi;

namespace ShaderSlang.Net.Bindings.Enums;

[Flags]
public enum DiagnosticFlags : uint
{
    VerbosePaths = SLANG_DIAGNOSTIC_FLAG_VERBOSE_PATHS,
    TreatWarningsAsErrors = SLANG_DIAGNOSTIC_FLAG_TREAT_WARNINGS_AS_ERRORS
}
