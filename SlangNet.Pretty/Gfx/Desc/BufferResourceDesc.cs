using System;
using Nito.Disposables;
using SlangNet.Gfx.Desc;
using SlangNet.Internal;
namespace SlangNet.Gfx;

public readonly record struct BufferResourceDesc(
    ResourceDescBase Base,
    nuint SizeInBytes = 0,
    nuint ElementSize = 0,
    Format Format = Format.Unknown
) : IMarshalsToNative<IBufferResource.BufferResourceDesc>, IMarshalsFromNative<BufferResourceDesc, IBufferResource.BufferResourceDesc>
{
    public readonly int GetNativeAllocSize()
    {
        return Base.GetNativeAllocSize() + SysUnsafe.SizeOf<nuint>() * 2 + SysUnsafe.SizeOf<Format>();
    }

    public void AsNative(ref MarshallingAllocBuffer buffer, out IBufferResource.BufferResourceDesc native)
    {
        Base.AsNative(ref buffer, out var nativeBase);
        
        native = new()
        {
            Base = nativeBase,
            sizeInBytes = SizeInBytes,
            elementSize = ElementSize,
            format = Format
        };
    }
    
    public static unsafe void CreateFromNative(IBufferResource.BufferResourceDesc native, out BufferResourceDesc managed)
    {
        ResourceDescBase.CreateFromNative(native.Base, out var baseDesc);
        
        managed = new(
            baseDesc,
            native.sizeInBytes,
            native.elementSize,
            native.format
        );
    }
}
