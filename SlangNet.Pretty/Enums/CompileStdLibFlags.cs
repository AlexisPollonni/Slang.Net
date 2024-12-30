using System;

namespace SlangNet;

[Flags]
public enum CompileStdLibFlags : uint
{
    WriteDocumentation = CompileStdLibFlag.Enum.WriteDocumentation
}
