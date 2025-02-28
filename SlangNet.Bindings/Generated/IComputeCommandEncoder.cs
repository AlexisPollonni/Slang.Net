using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated;

/// <include file='IComputeCommandEncoder.xml' path='doc/member[@name="IComputeCommandEncoder"]/*' />
[Guid("88AA9322-82F7-4FE6-A68A-29C7FE798737")]
[NativeTypeName("struct IComputeCommandEncoder : gfx::IResourceCommandEncoder")]
[NativeInheritance("IResourceCommandEncoder")]
public unsafe partial struct IComputeCommandEncoder
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(IComputeCommandEncoder* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(IComputeCommandEncoder* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(IComputeCommandEncoder* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _endEncoding(IComputeCommandEncoder* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _writeTimestamp(IComputeCommandEncoder* pThis, [NativeTypeName("gfx::IQueryPool *")] IQueryPool* queryPool, [NativeTypeName("gfx::GfxIndex")] int queryIndex);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _copyBuffer(IComputeCommandEncoder* pThis, [NativeTypeName("gfx::IBufferResource *")] IBufferResource* dst, [NativeTypeName("gfx::Offset")] nuint dstOffset, [NativeTypeName("gfx::IBufferResource *")] IBufferResource* src, [NativeTypeName("gfx::Offset")] nuint srcOffset, [NativeTypeName("gfx::Size")] nuint size);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _copyTexture(IComputeCommandEncoder* pThis, [NativeTypeName("gfx::ITextureResource *")] ITextureResource* dst, [NativeTypeName("gfx::ResourceState")] ResourceState dstState, [NativeTypeName("gfx::SubresourceRange")] SubresourceRange dstSubresource, [NativeTypeName("gfx::ITextureResource::Offset3D")] Offset3D dstOffset, [NativeTypeName("gfx::ITextureResource *")] ITextureResource* src, [NativeTypeName("gfx::ResourceState")] ResourceState srcState, [NativeTypeName("gfx::SubresourceRange")] SubresourceRange srcSubresource, [NativeTypeName("gfx::ITextureResource::Offset3D")] Offset3D srcOffset, [NativeTypeName("gfx::ITextureResource::Extents")] Extents extent);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _copyTextureToBuffer(IComputeCommandEncoder* pThis, [NativeTypeName("gfx::IBufferResource *")] IBufferResource* dst, [NativeTypeName("gfx::Offset")] nuint dstOffset, [NativeTypeName("gfx::Size")] nuint dstSize, [NativeTypeName("gfx::Size")] nuint dstRowStride, [NativeTypeName("gfx::ITextureResource *")] ITextureResource* src, [NativeTypeName("gfx::ResourceState")] ResourceState srcState, [NativeTypeName("gfx::SubresourceRange")] SubresourceRange srcSubresource, [NativeTypeName("gfx::ITextureResource::Offset3D")] Offset3D srcOffset, [NativeTypeName("gfx::ITextureResource::Extents")] Extents extent);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _uploadTextureData(IComputeCommandEncoder* pThis, [NativeTypeName("gfx::ITextureResource *")] ITextureResource* dst, [NativeTypeName("gfx::SubresourceRange")] SubresourceRange subResourceRange, [NativeTypeName("gfx::ITextureResource::Offset3D")] Offset3D offset, [NativeTypeName("gfx::ITextureResource::Extents")] Extents extent, [NativeTypeName("gfx::ITextureResource::SubresourceData *")] SubresourceData* subResourceData, [NativeTypeName("gfx::GfxCount")] int subResourceDataCount);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _uploadBufferData(IComputeCommandEncoder* pThis, [NativeTypeName("gfx::IBufferResource *")] IBufferResource* dst, [NativeTypeName("gfx::Offset")] nuint offset, [NativeTypeName("gfx::Size")] nuint size, void* data);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _textureBarrier(IComputeCommandEncoder* pThis, [NativeTypeName("gfx::GfxCount")] int count, [NativeTypeName("ITextureResource *const *")] ITextureResource** textures, [NativeTypeName("gfx::ResourceState")] ResourceState src, [NativeTypeName("gfx::ResourceState")] ResourceState dst);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _textureSubresourceBarrier(IComputeCommandEncoder* pThis, [NativeTypeName("gfx::ITextureResource *")] ITextureResource* texture, [NativeTypeName("gfx::SubresourceRange")] SubresourceRange subresourceRange, [NativeTypeName("gfx::ResourceState")] ResourceState src, [NativeTypeName("gfx::ResourceState")] ResourceState dst);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _bufferBarrier(IComputeCommandEncoder* pThis, [NativeTypeName("gfx::GfxCount")] int count, [NativeTypeName("IBufferResource *const *")] IBufferResource** buffers, [NativeTypeName("gfx::ResourceState")] ResourceState src, [NativeTypeName("gfx::ResourceState")] ResourceState dst);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _clearResourceView(IComputeCommandEncoder* pThis, [NativeTypeName("gfx::IResourceView *")] IResourceView* view, [NativeTypeName("gfx::ClearValue *")] ClearValue* clearValue, [NativeTypeName("gfx::ClearResourceViewFlags::Enum")] Enum flags);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _resolveResource(IComputeCommandEncoder* pThis, [NativeTypeName("gfx::ITextureResource *")] ITextureResource* source, [NativeTypeName("gfx::ResourceState")] ResourceState sourceState, [NativeTypeName("gfx::SubresourceRange")] SubresourceRange sourceRange, [NativeTypeName("gfx::ITextureResource *")] ITextureResource* dest, [NativeTypeName("gfx::ResourceState")] ResourceState destState, [NativeTypeName("gfx::SubresourceRange")] SubresourceRange destRange);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _resolveQuery(IComputeCommandEncoder* pThis, [NativeTypeName("gfx::IQueryPool *")] IQueryPool* queryPool, [NativeTypeName("gfx::GfxIndex")] int index, [NativeTypeName("gfx::GfxCount")] int count, [NativeTypeName("gfx::IBufferResource *")] IBufferResource* buffer, [NativeTypeName("gfx::Offset")] nuint offset);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _beginDebugEvent(IComputeCommandEncoder* pThis, [NativeTypeName("const char *")] sbyte* name, [NativeTypeName("float[3]")] float* rgbColor);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _endDebugEvent(IComputeCommandEncoder* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _bindPipeline(IComputeCommandEncoder* pThis, [NativeTypeName("gfx::IPipelineState *")] IPipelineState* state, IShaderObject** outRootShaderObject);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _bindPipelineWithRootObject(IComputeCommandEncoder* pThis, [NativeTypeName("gfx::IPipelineState *")] IPipelineState* state, [NativeTypeName("gfx::IShaderObject *")] IShaderObject* rootObject);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _dispatchCompute(IComputeCommandEncoder* pThis, int x, int y, int z);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _dispatchComputeIndirect(IComputeCommandEncoder* pThis, [NativeTypeName("gfx::IBufferResource *")] IBufferResource* cmdBuffer, [NativeTypeName("gfx::Offset")] nuint offset);

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((IComputeCommandEncoder*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((IComputeCommandEncoder*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((IComputeCommandEncoder*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ICommandEncoder.endEncoding" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void endEncoding()
    {
        Marshal.GetDelegateForFunctionPointer<_endEncoding>(lpVtbl->endEncoding)((IComputeCommandEncoder*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ICommandEncoder.writeTimestamp" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void writeTimestamp([NativeTypeName("gfx::IQueryPool *")] IQueryPool* queryPool, [NativeTypeName("gfx::GfxIndex")] int queryIndex)
    {
        Marshal.GetDelegateForFunctionPointer<_writeTimestamp>(lpVtbl->writeTimestamp)((IComputeCommandEncoder*)Unsafe.AsPointer(ref this), queryPool, queryIndex);
    }

    /// <inheritdoc cref="IResourceCommandEncoder.copyBuffer" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void copyBuffer([NativeTypeName("gfx::IBufferResource *")] IBufferResource* dst, [NativeTypeName("gfx::Offset")] nuint dstOffset, [NativeTypeName("gfx::IBufferResource *")] IBufferResource* src, [NativeTypeName("gfx::Offset")] nuint srcOffset, [NativeTypeName("gfx::Size")] nuint size)
    {
        Marshal.GetDelegateForFunctionPointer<_copyBuffer>(lpVtbl->copyBuffer)((IComputeCommandEncoder*)Unsafe.AsPointer(ref this), dst, dstOffset, src, srcOffset, size);
    }

    /// <inheritdoc cref="IResourceCommandEncoder.copyTexture" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void copyTexture([NativeTypeName("gfx::ITextureResource *")] ITextureResource* dst, [NativeTypeName("gfx::ResourceState")] ResourceState dstState, [NativeTypeName("gfx::SubresourceRange")] SubresourceRange dstSubresource, [NativeTypeName("gfx::ITextureResource::Offset3D")] Offset3D dstOffset, [NativeTypeName("gfx::ITextureResource *")] ITextureResource* src, [NativeTypeName("gfx::ResourceState")] ResourceState srcState, [NativeTypeName("gfx::SubresourceRange")] SubresourceRange srcSubresource, [NativeTypeName("gfx::ITextureResource::Offset3D")] Offset3D srcOffset, [NativeTypeName("gfx::ITextureResource::Extents")] Extents extent)
    {
        Marshal.GetDelegateForFunctionPointer<_copyTexture>(lpVtbl->copyTexture)((IComputeCommandEncoder*)Unsafe.AsPointer(ref this), dst, dstState, dstSubresource, dstOffset, src, srcState, srcSubresource, srcOffset, extent);
    }

    /// <inheritdoc cref="IResourceCommandEncoder.copyTextureToBuffer" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void copyTextureToBuffer([NativeTypeName("gfx::IBufferResource *")] IBufferResource* dst, [NativeTypeName("gfx::Offset")] nuint dstOffset, [NativeTypeName("gfx::Size")] nuint dstSize, [NativeTypeName("gfx::Size")] nuint dstRowStride, [NativeTypeName("gfx::ITextureResource *")] ITextureResource* src, [NativeTypeName("gfx::ResourceState")] ResourceState srcState, [NativeTypeName("gfx::SubresourceRange")] SubresourceRange srcSubresource, [NativeTypeName("gfx::ITextureResource::Offset3D")] Offset3D srcOffset, [NativeTypeName("gfx::ITextureResource::Extents")] Extents extent)
    {
        Marshal.GetDelegateForFunctionPointer<_copyTextureToBuffer>(lpVtbl->copyTextureToBuffer)((IComputeCommandEncoder*)Unsafe.AsPointer(ref this), dst, dstOffset, dstSize, dstRowStride, src, srcState, srcSubresource, srcOffset, extent);
    }

    /// <inheritdoc cref="IResourceCommandEncoder.uploadTextureData" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void uploadTextureData([NativeTypeName("gfx::ITextureResource *")] ITextureResource* dst, [NativeTypeName("gfx::SubresourceRange")] SubresourceRange subResourceRange, [NativeTypeName("gfx::ITextureResource::Offset3D")] Offset3D offset, [NativeTypeName("gfx::ITextureResource::Extents")] Extents extent, [NativeTypeName("gfx::ITextureResource::SubresourceData *")] SubresourceData* subResourceData, [NativeTypeName("gfx::GfxCount")] int subResourceDataCount)
    {
        Marshal.GetDelegateForFunctionPointer<_uploadTextureData>(lpVtbl->uploadTextureData)((IComputeCommandEncoder*)Unsafe.AsPointer(ref this), dst, subResourceRange, offset, extent, subResourceData, subResourceDataCount);
    }

    /// <inheritdoc cref="IResourceCommandEncoder.uploadBufferData" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void uploadBufferData([NativeTypeName("gfx::IBufferResource *")] IBufferResource* dst, [NativeTypeName("gfx::Offset")] nuint offset, [NativeTypeName("gfx::Size")] nuint size, void* data)
    {
        Marshal.GetDelegateForFunctionPointer<_uploadBufferData>(lpVtbl->uploadBufferData)((IComputeCommandEncoder*)Unsafe.AsPointer(ref this), dst, offset, size, data);
    }

    /// <inheritdoc cref="IResourceCommandEncoder.textureBarrier" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void textureBarrier([NativeTypeName("gfx::GfxCount")] int count, [NativeTypeName("ITextureResource *const *")] ITextureResource** textures, [NativeTypeName("gfx::ResourceState")] ResourceState src, [NativeTypeName("gfx::ResourceState")] ResourceState dst)
    {
        Marshal.GetDelegateForFunctionPointer<_textureBarrier>(lpVtbl->textureBarrier)((IComputeCommandEncoder*)Unsafe.AsPointer(ref this), count, textures, src, dst);
    }

    /// <inheritdoc cref="IResourceCommandEncoder.textureSubresourceBarrier" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void textureSubresourceBarrier([NativeTypeName("gfx::ITextureResource *")] ITextureResource* texture, [NativeTypeName("gfx::SubresourceRange")] SubresourceRange subresourceRange, [NativeTypeName("gfx::ResourceState")] ResourceState src, [NativeTypeName("gfx::ResourceState")] ResourceState dst)
    {
        Marshal.GetDelegateForFunctionPointer<_textureSubresourceBarrier>(lpVtbl->textureSubresourceBarrier)((IComputeCommandEncoder*)Unsafe.AsPointer(ref this), texture, subresourceRange, src, dst);
    }

    /// <inheritdoc cref="IResourceCommandEncoder.bufferBarrier" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void bufferBarrier([NativeTypeName("gfx::GfxCount")] int count, [NativeTypeName("IBufferResource *const *")] IBufferResource** buffers, [NativeTypeName("gfx::ResourceState")] ResourceState src, [NativeTypeName("gfx::ResourceState")] ResourceState dst)
    {
        Marshal.GetDelegateForFunctionPointer<_bufferBarrier>(lpVtbl->bufferBarrier)((IComputeCommandEncoder*)Unsafe.AsPointer(ref this), count, buffers, src, dst);
    }

    /// <inheritdoc cref="IResourceCommandEncoder.clearResourceView" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void clearResourceView([NativeTypeName("gfx::IResourceView *")] IResourceView* view, [NativeTypeName("gfx::ClearValue *")] ClearValue* clearValue, [NativeTypeName("gfx::ClearResourceViewFlags::Enum")] Enum flags)
    {
        Marshal.GetDelegateForFunctionPointer<_clearResourceView>(lpVtbl->clearResourceView)((IComputeCommandEncoder*)Unsafe.AsPointer(ref this), view, clearValue, flags);
    }

    /// <inheritdoc cref="IResourceCommandEncoder.resolveResource" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void resolveResource([NativeTypeName("gfx::ITextureResource *")] ITextureResource* source, [NativeTypeName("gfx::ResourceState")] ResourceState sourceState, [NativeTypeName("gfx::SubresourceRange")] SubresourceRange sourceRange, [NativeTypeName("gfx::ITextureResource *")] ITextureResource* dest, [NativeTypeName("gfx::ResourceState")] ResourceState destState, [NativeTypeName("gfx::SubresourceRange")] SubresourceRange destRange)
    {
        Marshal.GetDelegateForFunctionPointer<_resolveResource>(lpVtbl->resolveResource)((IComputeCommandEncoder*)Unsafe.AsPointer(ref this), source, sourceState, sourceRange, dest, destState, destRange);
    }

    /// <inheritdoc cref="IResourceCommandEncoder.resolveQuery" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void resolveQuery([NativeTypeName("gfx::IQueryPool *")] IQueryPool* queryPool, [NativeTypeName("gfx::GfxIndex")] int index, [NativeTypeName("gfx::GfxCount")] int count, [NativeTypeName("gfx::IBufferResource *")] IBufferResource* buffer, [NativeTypeName("gfx::Offset")] nuint offset)
    {
        Marshal.GetDelegateForFunctionPointer<_resolveQuery>(lpVtbl->resolveQuery)((IComputeCommandEncoder*)Unsafe.AsPointer(ref this), queryPool, index, count, buffer, offset);
    }

    /// <inheritdoc cref="IResourceCommandEncoder.beginDebugEvent" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void beginDebugEvent([NativeTypeName("const char *")] sbyte* name, [NativeTypeName("float[3]")] float* rgbColor)
    {
        Marshal.GetDelegateForFunctionPointer<_beginDebugEvent>(lpVtbl->beginDebugEvent)((IComputeCommandEncoder*)Unsafe.AsPointer(ref this), name, rgbColor);
    }

    /// <inheritdoc cref="IResourceCommandEncoder.endDebugEvent" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void endDebugEvent()
    {
        Marshal.GetDelegateForFunctionPointer<_endDebugEvent>(lpVtbl->endDebugEvent)((IComputeCommandEncoder*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IComputeCommandEncoder.xml' path='doc/member[@name="IComputeCommandEncoder.bindPipeline"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int bindPipeline([NativeTypeName("gfx::IPipelineState *")] IPipelineState* state, IShaderObject** outRootShaderObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_bindPipeline>(lpVtbl->bindPipeline)((IComputeCommandEncoder*)Unsafe.AsPointer(ref this), state, outRootShaderObject);
    }

    /// <include file='IComputeCommandEncoder.xml' path='doc/member[@name="IComputeCommandEncoder.bindPipelineWithRootObject"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int bindPipelineWithRootObject([NativeTypeName("gfx::IPipelineState *")] IPipelineState* state, [NativeTypeName("gfx::IShaderObject *")] IShaderObject* rootObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_bindPipelineWithRootObject>(lpVtbl->bindPipelineWithRootObject)((IComputeCommandEncoder*)Unsafe.AsPointer(ref this), state, rootObject);
    }

    /// <include file='IComputeCommandEncoder.xml' path='doc/member[@name="IComputeCommandEncoder.dispatchCompute"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int dispatchCompute(int x, int y, int z)
    {
        return Marshal.GetDelegateForFunctionPointer<_dispatchCompute>(lpVtbl->dispatchCompute)((IComputeCommandEncoder*)Unsafe.AsPointer(ref this), x, y, z);
    }

    /// <include file='IComputeCommandEncoder.xml' path='doc/member[@name="IComputeCommandEncoder.dispatchComputeIndirect"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int dispatchComputeIndirect([NativeTypeName("gfx::IBufferResource *")] IBufferResource* cmdBuffer, [NativeTypeName("gfx::Offset")] nuint offset)
    {
        return Marshal.GetDelegateForFunctionPointer<_dispatchComputeIndirect>(lpVtbl->dispatchComputeIndirect)((IComputeCommandEncoder*)Unsafe.AsPointer(ref this), cmdBuffer, offset);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr release;

        [NativeTypeName("void () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr endEncoding;

        [NativeTypeName("void (IQueryPool *, GfxIndex) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr writeTimestamp;

        [NativeTypeName("void (IBufferResource *, Offset, IBufferResource *, Offset, Size) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr copyBuffer;

        [NativeTypeName("void (ITextureResource *, ResourceState, SubresourceRange, ITextureResource::Offset3D, ITextureResource *, ResourceState, SubresourceRange, ITextureResource::Offset3D, ITextureResource::Extents) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr copyTexture;

        [NativeTypeName("void (IBufferResource *, Offset, Size, Size, ITextureResource *, ResourceState, SubresourceRange, ITextureResource::Offset3D, ITextureResource::Extents) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr copyTextureToBuffer;

        [NativeTypeName("void (ITextureResource *, SubresourceRange, ITextureResource::Offset3D, ITextureResource::Extents, ITextureResource::SubresourceData *, GfxCount) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr uploadTextureData;

        [NativeTypeName("void (IBufferResource *, Offset, Size, void *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr uploadBufferData;

        [NativeTypeName("void (GfxCount, ITextureResource *const *, ResourceState, ResourceState) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr textureBarrier;

        [NativeTypeName("void (ITextureResource *, SubresourceRange, ResourceState, ResourceState) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr textureSubresourceBarrier;

        [NativeTypeName("void (GfxCount, IBufferResource *const *, ResourceState, ResourceState) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr bufferBarrier;

        [NativeTypeName("void (IResourceView *, ClearValue *, ClearResourceViewFlags::Enum) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr clearResourceView;

        [NativeTypeName("void (ITextureResource *, ResourceState, SubresourceRange, ITextureResource *, ResourceState, SubresourceRange) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr resolveResource;

        [NativeTypeName("void (IQueryPool *, GfxIndex, GfxCount, IBufferResource *, Offset) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr resolveQuery;

        [NativeTypeName("void (const char *, float *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr beginDebugEvent;

        [NativeTypeName("void () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr endDebugEvent;

        [NativeTypeName("Result (IPipelineState *, IShaderObject **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr bindPipeline;

        [NativeTypeName("Result (IPipelineState *, IShaderObject *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr bindPipelineWithRootObject;

        [NativeTypeName("Result (int, int, int) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr dispatchCompute;

        [NativeTypeName("Result (IBufferResource *, Offset) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr dispatchComputeIndirect;
    }
}
