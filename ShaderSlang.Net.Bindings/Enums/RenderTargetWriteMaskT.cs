using ShaderSlang.Net.Bindings.Generated;

namespace ShaderSlang.Net.Bindings.Enums;

[Flags]
public enum RenderTargetWriteMaskT : byte
{
    EnableNone = GfxApi.EnableNone,
    EnableRed = GfxApi.EnableRed,
    EnableGreen = GfxApi.EnableGreen,
    EnableBlue = GfxApi.EnableBlue,
    EnableAlpha = GfxApi.EnableAlpha,
    EnableAll = GfxApi.EnableAll
}