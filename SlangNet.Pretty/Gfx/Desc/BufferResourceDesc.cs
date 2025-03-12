using System;
using Nito.Disposables;
using SlangNet.Gfx.Desc;
using SlangNet.Internal;
namespace SlangNet.Gfx;

public record struct BufferResourceDesc(
    ResourceDescBase Base,
    nuint SizeInBytes = 0,
    nuint ElementSize = 0,
    Format Format = Format.Unknown
) : IMarshalsToNative<IBufferResource.BufferResourceDesc>, IMarshalsFromNative<BufferResourceDesc, IBufferResource.BufferResourceDesc>
{
    public unsafe IDisposable AsNative(out IBufferResource.BufferResourceDesc native)
    {
        var disposable = new CollectionDisposable();
        Base.AsNative(out var nativeBase).DisposeWith(disposable);
        
        native = new IBufferResource.BufferResourceDesc
        {
            Base = nativeBase,
            sizeInBytes = SizeInBytes,
            elementSize = ElementSize,
            format = Format
        };
        
        return disposable;
    }
    
    public static unsafe void CreateFromNative(IBufferResource.BufferResourceDesc native, out BufferResourceDesc managed)
    {
        ResourceDescBase.CreateFromNative(native.Base, out var baseDesc);
        
        managed = new BufferResourceDesc(
            baseDesc,
            native.sizeInBytes,
            native.elementSize,
            native.format
        );
    }
}
