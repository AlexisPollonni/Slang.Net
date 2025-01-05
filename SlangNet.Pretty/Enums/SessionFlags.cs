using System;
using static SlangNet.Bindings.Generated.Slang;

namespace SlangNet;

[Flags]
public enum SessionFlags : uint
{
    None = kSessionFlags_None,
}
