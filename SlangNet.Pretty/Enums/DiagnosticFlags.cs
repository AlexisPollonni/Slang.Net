using System;

namespace SlangNet;

[Flags]
public enum DiagnosticFlags
{
    VerbosePaths = SLANG_DIAGNOSTIC_FLAG_VERBOSE_PATHS,
    TreatWarningsAsErrors = SLANG_DIAGNOSTIC_FLAG_TREAT_WARNINGS_AS_ERRORS
}
