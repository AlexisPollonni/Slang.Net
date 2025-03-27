using System;
using SlangNet.Gfx.Desc;

namespace SlangNet.Gfx;

public class TextureResource : Resource
{
    public new unsafe ITextureResource* Pointer => (ITextureResource*)base.Pointer;

    public unsafe TextureResource(ITextureResource* pointer) : base((IResource*)pointer) { }

    public unsafe TextureResourceDesc GetDesc()
    {
        var nativePtr = Pointer->getDesc();
        TextureResourceDesc.CreateFromNative(*nativePtr, out var managed);
        return managed;
    }
    
    
    public readonly struct SubresourceData(Memory<byte> data, nuint strideY, nuint strideZ)
    {
        public Memory<byte> Data { get; } = data;
        public nuint StrideY { get; } = strideY;
        public nuint StrideZ { get; } = strideZ;
    }
}