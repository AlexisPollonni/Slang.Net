using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ShaderSlang.Net.Bindings.Generated;

/// <include file='IResourceCommandEncoder.xml' path='doc/member[@name="IResourceCommandEncoder"]/*' />
[Guid("F99A00E9-ED50-4088-8A0E-3B26755031EA")]
[NativeTypeName("struct IResourceCommandEncoder : gfx::ICommandEncoder")]
[NativeInheritance("ICommandEncoder")]
public unsafe partial struct IResourceCommandEncoder
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(
        IResourceCommandEncoder* pThis,
        [NativeTypeName("const SlangUUID &")] SlangUUID* uuid,
        void** outObject
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(IResourceCommandEncoder* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(IResourceCommandEncoder* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _endEncoding(IResourceCommandEncoder* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _writeTimestamp(
        IResourceCommandEncoder* pThis,
        [NativeTypeName("gfx::IQueryPool *")] IQueryPool* queryPool,
        [NativeTypeName("gfx::GfxIndex")] int queryIndex
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _copyBuffer(
        IResourceCommandEncoder* pThis,
        [NativeTypeName("gfx::IBufferResource *")] IBufferResource* dst,
        [NativeTypeName("gfx::Offset")] nuint dstOffset,
        [NativeTypeName("gfx::IBufferResource *")] IBufferResource* src,
        [NativeTypeName("gfx::Offset")] nuint srcOffset,
        [NativeTypeName("gfx::Size")] nuint size
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _copyTexture(
        IResourceCommandEncoder* pThis,
        [NativeTypeName("gfx::ITextureResource *")] ITextureResource* dst,
        [NativeTypeName("gfx::ResourceState")] ResourceState dstState,
        [NativeTypeName("gfx::SubresourceRange")] SubresourceRange dstSubresource,
        [NativeTypeName("gfx::ITextureResource::Offset3D")] Offset3D dstOffset,
        [NativeTypeName("gfx::ITextureResource *")] ITextureResource* src,
        [NativeTypeName("gfx::ResourceState")] ResourceState srcState,
        [NativeTypeName("gfx::SubresourceRange")] SubresourceRange srcSubresource,
        [NativeTypeName("gfx::ITextureResource::Offset3D")] Offset3D srcOffset,
        [NativeTypeName("gfx::ITextureResource::Extents")] Extents extent
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _copyTextureToBuffer(
        IResourceCommandEncoder* pThis,
        [NativeTypeName("gfx::IBufferResource *")] IBufferResource* dst,
        [NativeTypeName("gfx::Offset")] nuint dstOffset,
        [NativeTypeName("gfx::Size")] nuint dstSize,
        [NativeTypeName("gfx::Size")] nuint dstRowStride,
        [NativeTypeName("gfx::ITextureResource *")] ITextureResource* src,
        [NativeTypeName("gfx::ResourceState")] ResourceState srcState,
        [NativeTypeName("gfx::SubresourceRange")] SubresourceRange srcSubresource,
        [NativeTypeName("gfx::ITextureResource::Offset3D")] Offset3D srcOffset,
        [NativeTypeName("gfx::ITextureResource::Extents")] Extents extent
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _uploadTextureData(
        IResourceCommandEncoder* pThis,
        [NativeTypeName("gfx::ITextureResource *")] ITextureResource* dst,
        [NativeTypeName("gfx::SubresourceRange")] SubresourceRange subResourceRange,
        [NativeTypeName("gfx::ITextureResource::Offset3D")] Offset3D offset,
        [NativeTypeName("gfx::ITextureResource::Extents")] Extents extent,
        [NativeTypeName("gfx::ITextureResource::SubresourceData *")]
            SubresourceData* subResourceData,
        [NativeTypeName("gfx::GfxCount")] int subResourceDataCount
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _uploadBufferData(
        IResourceCommandEncoder* pThis,
        [NativeTypeName("gfx::IBufferResource *")] IBufferResource* dst,
        [NativeTypeName("gfx::Offset")] nuint offset,
        [NativeTypeName("gfx::Size")] nuint size,
        void* data
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _textureBarrier(
        IResourceCommandEncoder* pThis,
        [NativeTypeName("gfx::GfxCount")] int count,
        [NativeTypeName("ITextureResource *const *")] ITextureResource** textures,
        [NativeTypeName("gfx::ResourceState")] ResourceState src,
        [NativeTypeName("gfx::ResourceState")] ResourceState dst
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _textureSubresourceBarrier(
        IResourceCommandEncoder* pThis,
        [NativeTypeName("gfx::ITextureResource *")] ITextureResource* texture,
        [NativeTypeName("gfx::SubresourceRange")] SubresourceRange subresourceRange,
        [NativeTypeName("gfx::ResourceState")] ResourceState src,
        [NativeTypeName("gfx::ResourceState")] ResourceState dst
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _bufferBarrier(
        IResourceCommandEncoder* pThis,
        [NativeTypeName("gfx::GfxCount")] int count,
        [NativeTypeName("IBufferResource *const *")] IBufferResource** buffers,
        [NativeTypeName("gfx::ResourceState")] ResourceState src,
        [NativeTypeName("gfx::ResourceState")] ResourceState dst
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _clearResourceView(
        IResourceCommandEncoder* pThis,
        [NativeTypeName("gfx::IResourceView *")] IResourceView* view,
        [NativeTypeName("gfx::ClearValue *")] ClearValue* clearValue,
        [NativeTypeName("gfx::ClearResourceViewFlags::Enum")] Enum flags
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _resolveResource(
        IResourceCommandEncoder* pThis,
        [NativeTypeName("gfx::ITextureResource *")] ITextureResource* source,
        [NativeTypeName("gfx::ResourceState")] ResourceState sourceState,
        [NativeTypeName("gfx::SubresourceRange")] SubresourceRange sourceRange,
        [NativeTypeName("gfx::ITextureResource *")] ITextureResource* dest,
        [NativeTypeName("gfx::ResourceState")] ResourceState destState,
        [NativeTypeName("gfx::SubresourceRange")] SubresourceRange destRange
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _resolveQuery(
        IResourceCommandEncoder* pThis,
        [NativeTypeName("gfx::IQueryPool *")] IQueryPool* queryPool,
        [NativeTypeName("gfx::GfxIndex")] int index,
        [NativeTypeName("gfx::GfxCount")] int count,
        [NativeTypeName("gfx::IBufferResource *")] IBufferResource* buffer,
        [NativeTypeName("gfx::Offset")] nuint offset
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _beginDebugEvent(
        IResourceCommandEncoder* pThis,
        [NativeTypeName("const char *")] sbyte* name,
        [NativeTypeName("float[3]")] float* rgbColor
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _endDebugEvent(IResourceCommandEncoder* pThis);

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface(
        [NativeTypeName("const SlangUUID &")] SlangUUID* uuid,
        void** outObject
    )
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)(
            (IResourceCommandEncoder*)Unsafe.AsPointer(ref this),
            uuid,
            outObject
        );
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)(
            (IResourceCommandEncoder*)Unsafe.AsPointer(ref this)
        );
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)(
            (IResourceCommandEncoder*)Unsafe.AsPointer(ref this)
        );
    }

    /// <inheritdoc cref="ICommandEncoder.endEncoding" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void endEncoding()
    {
        Marshal.GetDelegateForFunctionPointer<_endEncoding>(lpVtbl->endEncoding)(
            (IResourceCommandEncoder*)Unsafe.AsPointer(ref this)
        );
    }

    /// <inheritdoc cref="ICommandEncoder.writeTimestamp" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void writeTimestamp(
        [NativeTypeName("gfx::IQueryPool *")] IQueryPool* queryPool,
        [NativeTypeName("gfx::GfxIndex")] int queryIndex
    )
    {
        Marshal.GetDelegateForFunctionPointer<_writeTimestamp>(lpVtbl->writeTimestamp)(
            (IResourceCommandEncoder*)Unsafe.AsPointer(ref this),
            queryPool,
            queryIndex
        );
    }

    /// <include file='IResourceCommandEncoder.xml' path='doc/member[@name="IResourceCommandEncoder.copyBuffer"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void copyBuffer(
        [NativeTypeName("gfx::IBufferResource *")] IBufferResource* dst,
        [NativeTypeName("gfx::Offset")] nuint dstOffset,
        [NativeTypeName("gfx::IBufferResource *")] IBufferResource* src,
        [NativeTypeName("gfx::Offset")] nuint srcOffset,
        [NativeTypeName("gfx::Size")] nuint size
    )
    {
        Marshal.GetDelegateForFunctionPointer<_copyBuffer>(lpVtbl->copyBuffer)(
            (IResourceCommandEncoder*)Unsafe.AsPointer(ref this),
            dst,
            dstOffset,
            src,
            srcOffset,
            size
        );
    }

    /// <include file='IResourceCommandEncoder.xml' path='doc/member[@name="IResourceCommandEncoder.copyTexture"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void copyTexture(
        [NativeTypeName("gfx::ITextureResource *")] ITextureResource* dst,
        [NativeTypeName("gfx::ResourceState")] ResourceState dstState,
        [NativeTypeName("gfx::SubresourceRange")] SubresourceRange dstSubresource,
        [NativeTypeName("gfx::ITextureResource::Offset3D")] Offset3D dstOffset,
        [NativeTypeName("gfx::ITextureResource *")] ITextureResource* src,
        [NativeTypeName("gfx::ResourceState")] ResourceState srcState,
        [NativeTypeName("gfx::SubresourceRange")] SubresourceRange srcSubresource,
        [NativeTypeName("gfx::ITextureResource::Offset3D")] Offset3D srcOffset,
        [NativeTypeName("gfx::ITextureResource::Extents")] Extents extent
    )
    {
        Marshal.GetDelegateForFunctionPointer<_copyTexture>(lpVtbl->copyTexture)(
            (IResourceCommandEncoder*)Unsafe.AsPointer(ref this),
            dst,
            dstState,
            dstSubresource,
            dstOffset,
            src,
            srcState,
            srcSubresource,
            srcOffset,
            extent
        );
    }

    /// <include file='IResourceCommandEncoder.xml' path='doc/member[@name="IResourceCommandEncoder.copyTextureToBuffer"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void copyTextureToBuffer(
        [NativeTypeName("gfx::IBufferResource *")] IBufferResource* dst,
        [NativeTypeName("gfx::Offset")] nuint dstOffset,
        [NativeTypeName("gfx::Size")] nuint dstSize,
        [NativeTypeName("gfx::Size")] nuint dstRowStride,
        [NativeTypeName("gfx::ITextureResource *")] ITextureResource* src,
        [NativeTypeName("gfx::ResourceState")] ResourceState srcState,
        [NativeTypeName("gfx::SubresourceRange")] SubresourceRange srcSubresource,
        [NativeTypeName("gfx::ITextureResource::Offset3D")] Offset3D srcOffset,
        [NativeTypeName("gfx::ITextureResource::Extents")] Extents extent
    )
    {
        Marshal.GetDelegateForFunctionPointer<_copyTextureToBuffer>(lpVtbl->copyTextureToBuffer)(
            (IResourceCommandEncoder*)Unsafe.AsPointer(ref this),
            dst,
            dstOffset,
            dstSize,
            dstRowStride,
            src,
            srcState,
            srcSubresource,
            srcOffset,
            extent
        );
    }

    /// <include file='IResourceCommandEncoder.xml' path='doc/member[@name="IResourceCommandEncoder.uploadTextureData"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void uploadTextureData(
        [NativeTypeName("gfx::ITextureResource *")] ITextureResource* dst,
        [NativeTypeName("gfx::SubresourceRange")] SubresourceRange subResourceRange,
        [NativeTypeName("gfx::ITextureResource::Offset3D")] Offset3D offset,
        [NativeTypeName("gfx::ITextureResource::Extents")] Extents extent,
        [NativeTypeName("gfx::ITextureResource::SubresourceData *")]
            SubresourceData* subResourceData,
        [NativeTypeName("gfx::GfxCount")] int subResourceDataCount
    )
    {
        Marshal.GetDelegateForFunctionPointer<_uploadTextureData>(lpVtbl->uploadTextureData)(
            (IResourceCommandEncoder*)Unsafe.AsPointer(ref this),
            dst,
            subResourceRange,
            offset,
            extent,
            subResourceData,
            subResourceDataCount
        );
    }

    /// <include file='IResourceCommandEncoder.xml' path='doc/member[@name="IResourceCommandEncoder.uploadBufferData"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void uploadBufferData(
        [NativeTypeName("gfx::IBufferResource *")] IBufferResource* dst,
        [NativeTypeName("gfx::Offset")] nuint offset,
        [NativeTypeName("gfx::Size")] nuint size,
        void* data
    )
    {
        Marshal.GetDelegateForFunctionPointer<_uploadBufferData>(lpVtbl->uploadBufferData)(
            (IResourceCommandEncoder*)Unsafe.AsPointer(ref this),
            dst,
            offset,
            size,
            data
        );
    }

    /// <include file='IResourceCommandEncoder.xml' path='doc/member[@name="IResourceCommandEncoder.textureBarrier"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void textureBarrier(
        [NativeTypeName("gfx::GfxCount")] int count,
        [NativeTypeName("ITextureResource *const *")] ITextureResource** textures,
        [NativeTypeName("gfx::ResourceState")] ResourceState src,
        [NativeTypeName("gfx::ResourceState")] ResourceState dst
    )
    {
        Marshal.GetDelegateForFunctionPointer<_textureBarrier>(lpVtbl->textureBarrier)(
            (IResourceCommandEncoder*)Unsafe.AsPointer(ref this),
            count,
            textures,
            src,
            dst
        );
    }

    /// <include file='IResourceCommandEncoder.xml' path='doc/member[@name="IResourceCommandEncoder.textureSubresourceBarrier"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void textureSubresourceBarrier(
        [NativeTypeName("gfx::ITextureResource *")] ITextureResource* texture,
        [NativeTypeName("gfx::SubresourceRange")] SubresourceRange subresourceRange,
        [NativeTypeName("gfx::ResourceState")] ResourceState src,
        [NativeTypeName("gfx::ResourceState")] ResourceState dst
    )
    {
        Marshal.GetDelegateForFunctionPointer<_textureSubresourceBarrier>(
            lpVtbl->textureSubresourceBarrier
        )(
            (IResourceCommandEncoder*)Unsafe.AsPointer(ref this),
            texture,
            subresourceRange,
            src,
            dst
        );
    }

    /// <include file='IResourceCommandEncoder.xml' path='doc/member[@name="IResourceCommandEncoder.bufferBarrier"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void bufferBarrier(
        [NativeTypeName("gfx::GfxCount")] int count,
        [NativeTypeName("IBufferResource *const *")] IBufferResource** buffers,
        [NativeTypeName("gfx::ResourceState")] ResourceState src,
        [NativeTypeName("gfx::ResourceState")] ResourceState dst
    )
    {
        Marshal.GetDelegateForFunctionPointer<_bufferBarrier>(lpVtbl->bufferBarrier)(
            (IResourceCommandEncoder*)Unsafe.AsPointer(ref this),
            count,
            buffers,
            src,
            dst
        );
    }

    /// <include file='IResourceCommandEncoder.xml' path='doc/member[@name="IResourceCommandEncoder.clearResourceView"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void clearResourceView(
        [NativeTypeName("gfx::IResourceView *")] IResourceView* view,
        [NativeTypeName("gfx::ClearValue *")] ClearValue* clearValue,
        [NativeTypeName("gfx::ClearResourceViewFlags::Enum")] Enum flags
    )
    {
        Marshal.GetDelegateForFunctionPointer<_clearResourceView>(lpVtbl->clearResourceView)(
            (IResourceCommandEncoder*)Unsafe.AsPointer(ref this),
            view,
            clearValue,
            flags
        );
    }

    /// <include file='IResourceCommandEncoder.xml' path='doc/member[@name="IResourceCommandEncoder.resolveResource"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void resolveResource(
        [NativeTypeName("gfx::ITextureResource *")] ITextureResource* source,
        [NativeTypeName("gfx::ResourceState")] ResourceState sourceState,
        [NativeTypeName("gfx::SubresourceRange")] SubresourceRange sourceRange,
        [NativeTypeName("gfx::ITextureResource *")] ITextureResource* dest,
        [NativeTypeName("gfx::ResourceState")] ResourceState destState,
        [NativeTypeName("gfx::SubresourceRange")] SubresourceRange destRange
    )
    {
        Marshal.GetDelegateForFunctionPointer<_resolveResource>(lpVtbl->resolveResource)(
            (IResourceCommandEncoder*)Unsafe.AsPointer(ref this),
            source,
            sourceState,
            sourceRange,
            dest,
            destState,
            destRange
        );
    }

    /// <include file='IResourceCommandEncoder.xml' path='doc/member[@name="IResourceCommandEncoder.resolveQuery"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void resolveQuery(
        [NativeTypeName("gfx::IQueryPool *")] IQueryPool* queryPool,
        [NativeTypeName("gfx::GfxIndex")] int index,
        [NativeTypeName("gfx::GfxCount")] int count,
        [NativeTypeName("gfx::IBufferResource *")] IBufferResource* buffer,
        [NativeTypeName("gfx::Offset")] nuint offset
    )
    {
        Marshal.GetDelegateForFunctionPointer<_resolveQuery>(lpVtbl->resolveQuery)(
            (IResourceCommandEncoder*)Unsafe.AsPointer(ref this),
            queryPool,
            index,
            count,
            buffer,
            offset
        );
    }

    /// <include file='IResourceCommandEncoder.xml' path='doc/member[@name="IResourceCommandEncoder.beginDebugEvent"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void beginDebugEvent(
        [NativeTypeName("const char *")] sbyte* name,
        [NativeTypeName("float[3]")] float* rgbColor
    )
    {
        Marshal.GetDelegateForFunctionPointer<_beginDebugEvent>(lpVtbl->beginDebugEvent)(
            (IResourceCommandEncoder*)Unsafe.AsPointer(ref this),
            name,
            rgbColor
        );
    }

    /// <include file='IResourceCommandEncoder.xml' path='doc/member[@name="IResourceCommandEncoder.endDebugEvent"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void endDebugEvent()
    {
        Marshal.GetDelegateForFunctionPointer<_endDebugEvent>(lpVtbl->endDebugEvent)(
            (IResourceCommandEncoder*)Unsafe.AsPointer(ref this)
        );
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((stdcall))")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t () __attribute__((stdcall))")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t () __attribute__((stdcall))")]
        public IntPtr release;

        [NativeTypeName("void () __attribute__((stdcall))")]
        public IntPtr endEncoding;

        [NativeTypeName("void (IQueryPool *, GfxIndex) __attribute__((stdcall))")]
        public IntPtr writeTimestamp;

        [NativeTypeName(
            "void (IBufferResource *, Offset, IBufferResource *, Offset, Size) __attribute__((stdcall))"
        )]
        public IntPtr copyBuffer;

        [NativeTypeName(
            "void (ITextureResource *, ResourceState, SubresourceRange, ITextureResource::Offset3D, ITextureResource *, ResourceState, SubresourceRange, ITextureResource::Offset3D, ITextureResource::Extents) __attribute__((stdcall))"
        )]
        public IntPtr copyTexture;

        [NativeTypeName(
            "void (IBufferResource *, Offset, Size, Size, ITextureResource *, ResourceState, SubresourceRange, ITextureResource::Offset3D, ITextureResource::Extents) __attribute__((stdcall))"
        )]
        public IntPtr copyTextureToBuffer;

        [NativeTypeName(
            "void (ITextureResource *, SubresourceRange, ITextureResource::Offset3D, ITextureResource::Extents, ITextureResource::SubresourceData *, GfxCount) __attribute__((stdcall))"
        )]
        public IntPtr uploadTextureData;

        [NativeTypeName("void (IBufferResource *, Offset, Size, void *) __attribute__((stdcall))")]
        public IntPtr uploadBufferData;

        [NativeTypeName(
            "void (GfxCount, ITextureResource *const *, ResourceState, ResourceState) __attribute__((stdcall))"
        )]
        public IntPtr textureBarrier;

        [NativeTypeName(
            "void (ITextureResource *, SubresourceRange, ResourceState, ResourceState) __attribute__((stdcall))"
        )]
        public IntPtr textureSubresourceBarrier;

        [NativeTypeName(
            "void (GfxCount, IBufferResource *const *, ResourceState, ResourceState) __attribute__((stdcall))"
        )]
        public IntPtr bufferBarrier;

        [NativeTypeName(
            "void (IResourceView *, ClearValue *, ClearResourceViewFlags::Enum) __attribute__((stdcall))"
        )]
        public IntPtr clearResourceView;

        [NativeTypeName(
            "void (ITextureResource *, ResourceState, SubresourceRange, ITextureResource *, ResourceState, SubresourceRange) __attribute__((stdcall))"
        )]
        public IntPtr resolveResource;

        [NativeTypeName(
            "void (IQueryPool *, GfxIndex, GfxCount, IBufferResource *, Offset) __attribute__((stdcall))"
        )]
        public IntPtr resolveQuery;

        [NativeTypeName("void (const char *, float *) __attribute__((stdcall))")]
        public IntPtr beginDebugEvent;

        [NativeTypeName("void () __attribute__((stdcall))")]
        public IntPtr endDebugEvent;
    }
}
