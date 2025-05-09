﻿using System;

using static SlangNet.Bindings.Generated.SlangApi;

namespace SlangNet.Enums;

[Flags]
public enum CompileFlags : uint
{
    NoMangling = SLANG_COMPILE_FLAG_NO_MANGLING,
    NoCodegen = SLANG_COMPILE_FLAG_NO_CODEGEN,
    Obfuscate = SLANG_COMPILE_FLAG_OBFUSCATE,
    NoChecking = SLANG_COMPILE_FLAG_NO_CHECKING,
    SplitMixedTypes = SLANG_COMPILE_FLAG_SPLIT_MIXED_TYPES
}
