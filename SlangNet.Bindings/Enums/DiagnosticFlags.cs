using System;

using static SlangNet.Bindings.Generated.SlangApi;

namespace SlangNet;

[Flags]
public enum DiagnosticFlags : uint
{
    VerbosePaths = SLANG_DIAGNOSTIC_FLAG_VERBOSE_PATHS,
    TreatWarningsAsErrors = SLANG_DIAGNOSTIC_FLAG_TREAT_WARNINGS_AS_ERRORS
}
