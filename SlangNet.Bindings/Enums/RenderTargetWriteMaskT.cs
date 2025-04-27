using System;
using SlangNet.Bindings.Generated;

namespace SlangNet;

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