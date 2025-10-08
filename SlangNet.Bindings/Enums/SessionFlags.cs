using static SlangNet.Bindings.Generated.SlangApi;

namespace SlangNet;

[Flags]
public enum SessionFlags : uint
{
    None = kSessionFlags_None,
}
