using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated;

/// <include file='IRenderCommandEncoder.xml' path='doc/member[@name="IRenderCommandEncoder"]/*' />
[Guid("7A8D56D0-53E6-4AD6-85F7-D14DC110FDCE")]
[NativeTypeName("struct IRenderCommandEncoder : gfx::IResourceCommandEncoder")]
[NativeInheritance("IResourceCommandEncoder")]
public unsafe partial struct IRenderCommandEncoder
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(IRenderCommandEncoder* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(IRenderCommandEncoder* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(IRenderCommandEncoder* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _endEncoding(IRenderCommandEncoder* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _writeTimestamp(IRenderCommandEncoder* pThis, [NativeTypeName("gfx::IQueryPool *")] IQueryPool* queryPool, [NativeTypeName("gfx::GfxIndex")] int queryIndex);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _copyBuffer(IRenderCommandEncoder* pThis, [NativeTypeName("gfx::IBufferResource *")] IBufferResource* dst, [NativeTypeName("gfx::Offset")] nuint dstOffset, [NativeTypeName("gfx::IBufferResource *")] IBufferResource* src, [NativeTypeName("gfx::Offset")] nuint srcOffset, [NativeTypeName("gfx::Size")] nuint size);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _copyTexture(IRenderCommandEncoder* pThis, [NativeTypeName("gfx::ITextureResource *")] ITextureResource* dst, [NativeTypeName("gfx::ResourceState")] ResourceState dstState, [NativeTypeName("gfx::SubresourceRange")] SubresourceRange dstSubresource, [NativeTypeName("gfx::ITextureResource::Offset3D")] Offset3D dstOffset, [NativeTypeName("gfx::ITextureResource *")] ITextureResource* src, [NativeTypeName("gfx::ResourceState")] ResourceState srcState, [NativeTypeName("gfx::SubresourceRange")] SubresourceRange srcSubresource, [NativeTypeName("gfx::ITextureResource::Offset3D")] Offset3D srcOffset, [NativeTypeName("gfx::ITextureResource::Extents")] Extents extent);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _copyTextureToBuffer(IRenderCommandEncoder* pThis, [NativeTypeName("gfx::IBufferResource *")] IBufferResource* dst, [NativeTypeName("gfx::Offset")] nuint dstOffset, [NativeTypeName("gfx::Size")] nuint dstSize, [NativeTypeName("gfx::Size")] nuint dstRowStride, [NativeTypeName("gfx::ITextureResource *")] ITextureResource* src, [NativeTypeName("gfx::ResourceState")] ResourceState srcState, [NativeTypeName("gfx::SubresourceRange")] SubresourceRange srcSubresource, [NativeTypeName("gfx::ITextureResource::Offset3D")] Offset3D srcOffset, [NativeTypeName("gfx::ITextureResource::Extents")] Extents extent);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _uploadTextureData(IRenderCommandEncoder* pThis, [NativeTypeName("gfx::ITextureResource *")] ITextureResource* dst, [NativeTypeName("gfx::SubresourceRange")] SubresourceRange subResourceRange, [NativeTypeName("gfx::ITextureResource::Offset3D")] Offset3D offset, [NativeTypeName("gfx::ITextureResource::Extents")] Extents extent, [NativeTypeName("gfx::ITextureResource::SubresourceData *")] SubresourceData* subResourceData, [NativeTypeName("gfx::GfxCount")] int subResourceDataCount);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _uploadBufferData(IRenderCommandEncoder* pThis, [NativeTypeName("gfx::IBufferResource *")] IBufferResource* dst, [NativeTypeName("gfx::Offset")] nuint offset, [NativeTypeName("gfx::Size")] nuint size, void* data);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _textureBarrier(IRenderCommandEncoder* pThis, [NativeTypeName("gfx::GfxCount")] int count, [NativeTypeName("ITextureResource *const *")] ITextureResource** textures, [NativeTypeName("gfx::ResourceState")] ResourceState src, [NativeTypeName("gfx::ResourceState")] ResourceState dst);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _textureSubresourceBarrier(IRenderCommandEncoder* pThis, [NativeTypeName("gfx::ITextureResource *")] ITextureResource* texture, [NativeTypeName("gfx::SubresourceRange")] SubresourceRange subresourceRange, [NativeTypeName("gfx::ResourceState")] ResourceState src, [NativeTypeName("gfx::ResourceState")] ResourceState dst);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _bufferBarrier(IRenderCommandEncoder* pThis, [NativeTypeName("gfx::GfxCount")] int count, [NativeTypeName("IBufferResource *const *")] IBufferResource** buffers, [NativeTypeName("gfx::ResourceState")] ResourceState src, [NativeTypeName("gfx::ResourceState")] ResourceState dst);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _clearResourceView(IRenderCommandEncoder* pThis, [NativeTypeName("gfx::IResourceView *")] IResourceView* view, [NativeTypeName("gfx::ClearValue *")] ClearValue* clearValue, [NativeTypeName("gfx::ClearResourceViewFlags::Enum")] Enum flags);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _resolveResource(IRenderCommandEncoder* pThis, [NativeTypeName("gfx::ITextureResource *")] ITextureResource* source, [NativeTypeName("gfx::ResourceState")] ResourceState sourceState, [NativeTypeName("gfx::SubresourceRange")] SubresourceRange sourceRange, [NativeTypeName("gfx::ITextureResource *")] ITextureResource* dest, [NativeTypeName("gfx::ResourceState")] ResourceState destState, [NativeTypeName("gfx::SubresourceRange")] SubresourceRange destRange);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _resolveQuery(IRenderCommandEncoder* pThis, [NativeTypeName("gfx::IQueryPool *")] IQueryPool* queryPool, [NativeTypeName("gfx::GfxIndex")] int index, [NativeTypeName("gfx::GfxCount")] int count, [NativeTypeName("gfx::IBufferResource *")] IBufferResource* buffer, [NativeTypeName("gfx::Offset")] nuint offset);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _beginDebugEvent(IRenderCommandEncoder* pThis, [NativeTypeName("const char *")] sbyte* name, [NativeTypeName("float[3]")] float* rgbColor);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _endDebugEvent(IRenderCommandEncoder* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _bindPipeline(IRenderCommandEncoder* pThis, [NativeTypeName("gfx::IPipelineState *")] IPipelineState* state, IShaderObject** outRootShaderObject);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _bindPipelineWithRootObject(IRenderCommandEncoder* pThis, [NativeTypeName("gfx::IPipelineState *")] IPipelineState* state, [NativeTypeName("gfx::IShaderObject *")] IShaderObject* rootObject);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setViewports(IRenderCommandEncoder* pThis, [NativeTypeName("gfx::GfxCount")] int count, [NativeTypeName("const Viewport *")] Viewport* viewports);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setScissorRects(IRenderCommandEncoder* pThis, [NativeTypeName("gfx::GfxCount")] int count, [NativeTypeName("const ScissorRect *")] ScissorRect* scissors);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setPrimitiveTopology(IRenderCommandEncoder* pThis, [NativeTypeName("gfx::PrimitiveTopology")] PrimitiveTopology topology);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setVertexBuffers(IRenderCommandEncoder* pThis, [NativeTypeName("gfx::GfxIndex")] int startSlot, [NativeTypeName("gfx::GfxCount")] int slotCount, [NativeTypeName("IBufferResource *const *")] IBufferResource** buffers, [NativeTypeName("const Offset *")] nuint* offsets);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setIndexBuffer(IRenderCommandEncoder* pThis, [NativeTypeName("gfx::IBufferResource *")] IBufferResource* buffer, [NativeTypeName("gfx::Format")] Format indexFormat, [NativeTypeName("gfx::Offset")] nuint offset = 0);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _draw(IRenderCommandEncoder* pThis, [NativeTypeName("gfx::GfxCount")] int vertexCount, [NativeTypeName("gfx::GfxIndex")] int startVertex = 0);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _drawIndexed(IRenderCommandEncoder* pThis, [NativeTypeName("gfx::GfxCount")] int indexCount, [NativeTypeName("gfx::GfxIndex")] int startIndex = 0, [NativeTypeName("gfx::GfxIndex")] int baseVertex = 0);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _drawIndirect(IRenderCommandEncoder* pThis, [NativeTypeName("gfx::GfxCount")] int maxDrawCount, [NativeTypeName("gfx::IBufferResource *")] IBufferResource* argBuffer, [NativeTypeName("gfx::Offset")] nuint argOffset, [NativeTypeName("gfx::IBufferResource *")] IBufferResource* countBuffer = null, [NativeTypeName("gfx::Offset")] nuint countOffset = 0);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _drawIndexedIndirect(IRenderCommandEncoder* pThis, [NativeTypeName("gfx::GfxCount")] int maxDrawCount, [NativeTypeName("gfx::IBufferResource *")] IBufferResource* argBuffer, [NativeTypeName("gfx::Offset")] nuint argOffset, [NativeTypeName("gfx::IBufferResource *")] IBufferResource* countBuffer = null, [NativeTypeName("gfx::Offset")] nuint countOffset = 0);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setStencilReference(IRenderCommandEncoder* pThis, [NativeTypeName("uint32_t")] uint referenceValue);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _setSamplePositions(IRenderCommandEncoder* pThis, [NativeTypeName("gfx::GfxCount")] int samplesPerPixel, [NativeTypeName("gfx::GfxCount")] int pixelCount, [NativeTypeName("const SamplePosition *")] SamplePosition* samplePositions);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _drawInstanced(IRenderCommandEncoder* pThis, [NativeTypeName("gfx::GfxCount")] int vertexCount, [NativeTypeName("gfx::GfxCount")] int instanceCount, [NativeTypeName("gfx::GfxIndex")] int startVertex, [NativeTypeName("gfx::GfxIndex")] int startInstanceLocation);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _drawIndexedInstanced(IRenderCommandEncoder* pThis, [NativeTypeName("gfx::GfxCount")] int indexCount, [NativeTypeName("gfx::GfxCount")] int instanceCount, [NativeTypeName("gfx::GfxIndex")] int startIndexLocation, [NativeTypeName("gfx::GfxIndex")] int baseVertexLocation, [NativeTypeName("gfx::GfxIndex")] int startInstanceLocation);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _drawMeshTasks(IRenderCommandEncoder* pThis, int x, int y, int z);

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((IRenderCommandEncoder*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((IRenderCommandEncoder*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((IRenderCommandEncoder*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ICommandEncoder.endEncoding" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void endEncoding()
    {
        Marshal.GetDelegateForFunctionPointer<_endEncoding>(lpVtbl->endEncoding)((IRenderCommandEncoder*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ICommandEncoder.writeTimestamp" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void writeTimestamp([NativeTypeName("gfx::IQueryPool *")] IQueryPool* queryPool, [NativeTypeName("gfx::GfxIndex")] int queryIndex)
    {
        Marshal.GetDelegateForFunctionPointer<_writeTimestamp>(lpVtbl->writeTimestamp)((IRenderCommandEncoder*)Unsafe.AsPointer(ref this), queryPool, queryIndex);
    }

    /// <inheritdoc cref="IResourceCommandEncoder.copyBuffer" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void copyBuffer([NativeTypeName("gfx::IBufferResource *")] IBufferResource* dst, [NativeTypeName("gfx::Offset")] nuint dstOffset, [NativeTypeName("gfx::IBufferResource *")] IBufferResource* src, [NativeTypeName("gfx::Offset")] nuint srcOffset, [NativeTypeName("gfx::Size")] nuint size)
    {
        Marshal.GetDelegateForFunctionPointer<_copyBuffer>(lpVtbl->copyBuffer)((IRenderCommandEncoder*)Unsafe.AsPointer(ref this), dst, dstOffset, src, srcOffset, size);
    }

    /// <inheritdoc cref="IResourceCommandEncoder.copyTexture" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void copyTexture([NativeTypeName("gfx::ITextureResource *")] ITextureResource* dst, [NativeTypeName("gfx::ResourceState")] ResourceState dstState, [NativeTypeName("gfx::SubresourceRange")] SubresourceRange dstSubresource, [NativeTypeName("gfx::ITextureResource::Offset3D")] Offset3D dstOffset, [NativeTypeName("gfx::ITextureResource *")] ITextureResource* src, [NativeTypeName("gfx::ResourceState")] ResourceState srcState, [NativeTypeName("gfx::SubresourceRange")] SubresourceRange srcSubresource, [NativeTypeName("gfx::ITextureResource::Offset3D")] Offset3D srcOffset, [NativeTypeName("gfx::ITextureResource::Extents")] Extents extent)
    {
        Marshal.GetDelegateForFunctionPointer<_copyTexture>(lpVtbl->copyTexture)((IRenderCommandEncoder*)Unsafe.AsPointer(ref this), dst, dstState, dstSubresource, dstOffset, src, srcState, srcSubresource, srcOffset, extent);
    }

    /// <inheritdoc cref="IResourceCommandEncoder.copyTextureToBuffer" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void copyTextureToBuffer([NativeTypeName("gfx::IBufferResource *")] IBufferResource* dst, [NativeTypeName("gfx::Offset")] nuint dstOffset, [NativeTypeName("gfx::Size")] nuint dstSize, [NativeTypeName("gfx::Size")] nuint dstRowStride, [NativeTypeName("gfx::ITextureResource *")] ITextureResource* src, [NativeTypeName("gfx::ResourceState")] ResourceState srcState, [NativeTypeName("gfx::SubresourceRange")] SubresourceRange srcSubresource, [NativeTypeName("gfx::ITextureResource::Offset3D")] Offset3D srcOffset, [NativeTypeName("gfx::ITextureResource::Extents")] Extents extent)
    {
        Marshal.GetDelegateForFunctionPointer<_copyTextureToBuffer>(lpVtbl->copyTextureToBuffer)((IRenderCommandEncoder*)Unsafe.AsPointer(ref this), dst, dstOffset, dstSize, dstRowStride, src, srcState, srcSubresource, srcOffset, extent);
    }

    /// <inheritdoc cref="IResourceCommandEncoder.uploadTextureData" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void uploadTextureData([NativeTypeName("gfx::ITextureResource *")] ITextureResource* dst, [NativeTypeName("gfx::SubresourceRange")] SubresourceRange subResourceRange, [NativeTypeName("gfx::ITextureResource::Offset3D")] Offset3D offset, [NativeTypeName("gfx::ITextureResource::Extents")] Extents extent, [NativeTypeName("gfx::ITextureResource::SubresourceData *")] SubresourceData* subResourceData, [NativeTypeName("gfx::GfxCount")] int subResourceDataCount)
    {
        Marshal.GetDelegateForFunctionPointer<_uploadTextureData>(lpVtbl->uploadTextureData)((IRenderCommandEncoder*)Unsafe.AsPointer(ref this), dst, subResourceRange, offset, extent, subResourceData, subResourceDataCount);
    }

    /// <inheritdoc cref="IResourceCommandEncoder.uploadBufferData" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void uploadBufferData([NativeTypeName("gfx::IBufferResource *")] IBufferResource* dst, [NativeTypeName("gfx::Offset")] nuint offset, [NativeTypeName("gfx::Size")] nuint size, void* data)
    {
        Marshal.GetDelegateForFunctionPointer<_uploadBufferData>(lpVtbl->uploadBufferData)((IRenderCommandEncoder*)Unsafe.AsPointer(ref this), dst, offset, size, data);
    }

    /// <inheritdoc cref="IResourceCommandEncoder.textureBarrier" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void textureBarrier([NativeTypeName("gfx::GfxCount")] int count, [NativeTypeName("ITextureResource *const *")] ITextureResource** textures, [NativeTypeName("gfx::ResourceState")] ResourceState src, [NativeTypeName("gfx::ResourceState")] ResourceState dst)
    {
        Marshal.GetDelegateForFunctionPointer<_textureBarrier>(lpVtbl->textureBarrier)((IRenderCommandEncoder*)Unsafe.AsPointer(ref this), count, textures, src, dst);
    }

    /// <inheritdoc cref="IResourceCommandEncoder.textureSubresourceBarrier" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void textureSubresourceBarrier([NativeTypeName("gfx::ITextureResource *")] ITextureResource* texture, [NativeTypeName("gfx::SubresourceRange")] SubresourceRange subresourceRange, [NativeTypeName("gfx::ResourceState")] ResourceState src, [NativeTypeName("gfx::ResourceState")] ResourceState dst)
    {
        Marshal.GetDelegateForFunctionPointer<_textureSubresourceBarrier>(lpVtbl->textureSubresourceBarrier)((IRenderCommandEncoder*)Unsafe.AsPointer(ref this), texture, subresourceRange, src, dst);
    }

    /// <inheritdoc cref="IResourceCommandEncoder.bufferBarrier" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void bufferBarrier([NativeTypeName("gfx::GfxCount")] int count, [NativeTypeName("IBufferResource *const *")] IBufferResource** buffers, [NativeTypeName("gfx::ResourceState")] ResourceState src, [NativeTypeName("gfx::ResourceState")] ResourceState dst)
    {
        Marshal.GetDelegateForFunctionPointer<_bufferBarrier>(lpVtbl->bufferBarrier)((IRenderCommandEncoder*)Unsafe.AsPointer(ref this), count, buffers, src, dst);
    }

    /// <inheritdoc cref="IResourceCommandEncoder.clearResourceView" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void clearResourceView([NativeTypeName("gfx::IResourceView *")] IResourceView* view, [NativeTypeName("gfx::ClearValue *")] ClearValue* clearValue, [NativeTypeName("gfx::ClearResourceViewFlags::Enum")] Enum flags)
    {
        Marshal.GetDelegateForFunctionPointer<_clearResourceView>(lpVtbl->clearResourceView)((IRenderCommandEncoder*)Unsafe.AsPointer(ref this), view, clearValue, flags);
    }

    /// <inheritdoc cref="IResourceCommandEncoder.resolveResource" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void resolveResource([NativeTypeName("gfx::ITextureResource *")] ITextureResource* source, [NativeTypeName("gfx::ResourceState")] ResourceState sourceState, [NativeTypeName("gfx::SubresourceRange")] SubresourceRange sourceRange, [NativeTypeName("gfx::ITextureResource *")] ITextureResource* dest, [NativeTypeName("gfx::ResourceState")] ResourceState destState, [NativeTypeName("gfx::SubresourceRange")] SubresourceRange destRange)
    {
        Marshal.GetDelegateForFunctionPointer<_resolveResource>(lpVtbl->resolveResource)((IRenderCommandEncoder*)Unsafe.AsPointer(ref this), source, sourceState, sourceRange, dest, destState, destRange);
    }

    /// <inheritdoc cref="IResourceCommandEncoder.resolveQuery" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void resolveQuery([NativeTypeName("gfx::IQueryPool *")] IQueryPool* queryPool, [NativeTypeName("gfx::GfxIndex")] int index, [NativeTypeName("gfx::GfxCount")] int count, [NativeTypeName("gfx::IBufferResource *")] IBufferResource* buffer, [NativeTypeName("gfx::Offset")] nuint offset)
    {
        Marshal.GetDelegateForFunctionPointer<_resolveQuery>(lpVtbl->resolveQuery)((IRenderCommandEncoder*)Unsafe.AsPointer(ref this), queryPool, index, count, buffer, offset);
    }

    /// <inheritdoc cref="IResourceCommandEncoder.beginDebugEvent" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void beginDebugEvent([NativeTypeName("const char *")] sbyte* name, [NativeTypeName("float[3]")] float* rgbColor)
    {
        Marshal.GetDelegateForFunctionPointer<_beginDebugEvent>(lpVtbl->beginDebugEvent)((IRenderCommandEncoder*)Unsafe.AsPointer(ref this), name, rgbColor);
    }

    /// <inheritdoc cref="IResourceCommandEncoder.endDebugEvent" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void endDebugEvent()
    {
        Marshal.GetDelegateForFunctionPointer<_endDebugEvent>(lpVtbl->endDebugEvent)((IRenderCommandEncoder*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IRenderCommandEncoder.xml' path='doc/member[@name="IRenderCommandEncoder.bindPipeline"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int bindPipeline([NativeTypeName("gfx::IPipelineState *")] IPipelineState* state, IShaderObject** outRootShaderObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_bindPipeline>(lpVtbl->bindPipeline)((IRenderCommandEncoder*)Unsafe.AsPointer(ref this), state, outRootShaderObject);
    }

    /// <include file='IRenderCommandEncoder.xml' path='doc/member[@name="IRenderCommandEncoder.bindPipelineWithRootObject"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int bindPipelineWithRootObject([NativeTypeName("gfx::IPipelineState *")] IPipelineState* state, [NativeTypeName("gfx::IShaderObject *")] IShaderObject* rootObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_bindPipelineWithRootObject>(lpVtbl->bindPipelineWithRootObject)((IRenderCommandEncoder*)Unsafe.AsPointer(ref this), state, rootObject);
    }

    /// <include file='IRenderCommandEncoder.xml' path='doc/member[@name="IRenderCommandEncoder.setViewports"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setViewports([NativeTypeName("gfx::GfxCount")] int count, [NativeTypeName("const Viewport *")] Viewport* viewports)
    {
        Marshal.GetDelegateForFunctionPointer<_setViewports>(lpVtbl->setViewports)((IRenderCommandEncoder*)Unsafe.AsPointer(ref this), count, viewports);
    }

    /// <include file='IRenderCommandEncoder.xml' path='doc/member[@name="IRenderCommandEncoder.setScissorRects"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setScissorRects([NativeTypeName("gfx::GfxCount")] int count, [NativeTypeName("const ScissorRect *")] ScissorRect* scissors)
    {
        Marshal.GetDelegateForFunctionPointer<_setScissorRects>(lpVtbl->setScissorRects)((IRenderCommandEncoder*)Unsafe.AsPointer(ref this), count, scissors);
    }

    /// <include file='IRenderCommandEncoder.xml' path='doc/member[@name="IRenderCommandEncoder.setPrimitiveTopology"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setPrimitiveTopology([NativeTypeName("gfx::PrimitiveTopology")] PrimitiveTopology topology)
    {
        Marshal.GetDelegateForFunctionPointer<_setPrimitiveTopology>(lpVtbl->setPrimitiveTopology)((IRenderCommandEncoder*)Unsafe.AsPointer(ref this), topology);
    }

    /// <include file='IRenderCommandEncoder.xml' path='doc/member[@name="IRenderCommandEncoder.setVertexBuffers"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setVertexBuffers([NativeTypeName("gfx::GfxIndex")] int startSlot, [NativeTypeName("gfx::GfxCount")] int slotCount, [NativeTypeName("IBufferResource *const *")] IBufferResource** buffers, [NativeTypeName("const Offset *")] nuint* offsets)
    {
        Marshal.GetDelegateForFunctionPointer<_setVertexBuffers>(lpVtbl->setVertexBuffers)((IRenderCommandEncoder*)Unsafe.AsPointer(ref this), startSlot, slotCount, buffers, offsets);
    }

    /// <include file='IRenderCommandEncoder.xml' path='doc/member[@name="IRenderCommandEncoder.setIndexBuffer"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setIndexBuffer([NativeTypeName("gfx::IBufferResource *")] IBufferResource* buffer, [NativeTypeName("gfx::Format")] Format indexFormat, [NativeTypeName("gfx::Offset")] nuint offset = 0)
    {
        Marshal.GetDelegateForFunctionPointer<_setIndexBuffer>(lpVtbl->setIndexBuffer)((IRenderCommandEncoder*)Unsafe.AsPointer(ref this), buffer, indexFormat, offset);
    }

    /// <include file='IRenderCommandEncoder.xml' path='doc/member[@name="IRenderCommandEncoder.draw"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int draw([NativeTypeName("gfx::GfxCount")] int vertexCount, [NativeTypeName("gfx::GfxIndex")] int startVertex = 0)
    {
        return Marshal.GetDelegateForFunctionPointer<_draw>(lpVtbl->draw)((IRenderCommandEncoder*)Unsafe.AsPointer(ref this), vertexCount, startVertex);
    }

    /// <include file='IRenderCommandEncoder.xml' path='doc/member[@name="IRenderCommandEncoder.drawIndexed"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int drawIndexed([NativeTypeName("gfx::GfxCount")] int indexCount, [NativeTypeName("gfx::GfxIndex")] int startIndex = 0, [NativeTypeName("gfx::GfxIndex")] int baseVertex = 0)
    {
        return Marshal.GetDelegateForFunctionPointer<_drawIndexed>(lpVtbl->drawIndexed)((IRenderCommandEncoder*)Unsafe.AsPointer(ref this), indexCount, startIndex, baseVertex);
    }

    /// <include file='IRenderCommandEncoder.xml' path='doc/member[@name="IRenderCommandEncoder.drawIndirect"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int drawIndirect([NativeTypeName("gfx::GfxCount")] int maxDrawCount, [NativeTypeName("gfx::IBufferResource *")] IBufferResource* argBuffer, [NativeTypeName("gfx::Offset")] nuint argOffset, [NativeTypeName("gfx::IBufferResource *")] IBufferResource* countBuffer = null, [NativeTypeName("gfx::Offset")] nuint countOffset = 0)
    {
        return Marshal.GetDelegateForFunctionPointer<_drawIndirect>(lpVtbl->drawIndirect)((IRenderCommandEncoder*)Unsafe.AsPointer(ref this), maxDrawCount, argBuffer, argOffset, countBuffer, countOffset);
    }

    /// <include file='IRenderCommandEncoder.xml' path='doc/member[@name="IRenderCommandEncoder.drawIndexedIndirect"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int drawIndexedIndirect([NativeTypeName("gfx::GfxCount")] int maxDrawCount, [NativeTypeName("gfx::IBufferResource *")] IBufferResource* argBuffer, [NativeTypeName("gfx::Offset")] nuint argOffset, [NativeTypeName("gfx::IBufferResource *")] IBufferResource* countBuffer = null, [NativeTypeName("gfx::Offset")] nuint countOffset = 0)
    {
        return Marshal.GetDelegateForFunctionPointer<_drawIndexedIndirect>(lpVtbl->drawIndexedIndirect)((IRenderCommandEncoder*)Unsafe.AsPointer(ref this), maxDrawCount, argBuffer, argOffset, countBuffer, countOffset);
    }

    /// <include file='IRenderCommandEncoder.xml' path='doc/member[@name="IRenderCommandEncoder.setStencilReference"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setStencilReference([NativeTypeName("uint32_t")] uint referenceValue)
    {
        Marshal.GetDelegateForFunctionPointer<_setStencilReference>(lpVtbl->setStencilReference)((IRenderCommandEncoder*)Unsafe.AsPointer(ref this), referenceValue);
    }

    /// <include file='IRenderCommandEncoder.xml' path='doc/member[@name="IRenderCommandEncoder.setSamplePositions"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int setSamplePositions([NativeTypeName("gfx::GfxCount")] int samplesPerPixel, [NativeTypeName("gfx::GfxCount")] int pixelCount, [NativeTypeName("const SamplePosition *")] SamplePosition* samplePositions)
    {
        return Marshal.GetDelegateForFunctionPointer<_setSamplePositions>(lpVtbl->setSamplePositions)((IRenderCommandEncoder*)Unsafe.AsPointer(ref this), samplesPerPixel, pixelCount, samplePositions);
    }

    /// <include file='IRenderCommandEncoder.xml' path='doc/member[@name="IRenderCommandEncoder.drawInstanced"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int drawInstanced([NativeTypeName("gfx::GfxCount")] int vertexCount, [NativeTypeName("gfx::GfxCount")] int instanceCount, [NativeTypeName("gfx::GfxIndex")] int startVertex, [NativeTypeName("gfx::GfxIndex")] int startInstanceLocation)
    {
        return Marshal.GetDelegateForFunctionPointer<_drawInstanced>(lpVtbl->drawInstanced)((IRenderCommandEncoder*)Unsafe.AsPointer(ref this), vertexCount, instanceCount, startVertex, startInstanceLocation);
    }

    /// <include file='IRenderCommandEncoder.xml' path='doc/member[@name="IRenderCommandEncoder.drawIndexedInstanced"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int drawIndexedInstanced([NativeTypeName("gfx::GfxCount")] int indexCount, [NativeTypeName("gfx::GfxCount")] int instanceCount, [NativeTypeName("gfx::GfxIndex")] int startIndexLocation, [NativeTypeName("gfx::GfxIndex")] int baseVertexLocation, [NativeTypeName("gfx::GfxIndex")] int startInstanceLocation)
    {
        return Marshal.GetDelegateForFunctionPointer<_drawIndexedInstanced>(lpVtbl->drawIndexedInstanced)((IRenderCommandEncoder*)Unsafe.AsPointer(ref this), indexCount, instanceCount, startIndexLocation, baseVertexLocation, startInstanceLocation);
    }

    /// <include file='IRenderCommandEncoder.xml' path='doc/member[@name="IRenderCommandEncoder.drawMeshTasks"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int drawMeshTasks(int x, int y, int z)
    {
        return Marshal.GetDelegateForFunctionPointer<_drawMeshTasks>(lpVtbl->drawMeshTasks)((IRenderCommandEncoder*)Unsafe.AsPointer(ref this), x, y, z);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **)")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t ()")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t ()")]
        public IntPtr release;

        [NativeTypeName("void ()")]
        public IntPtr endEncoding;

        [NativeTypeName("void (IQueryPool *, GfxIndex)")]
        public IntPtr writeTimestamp;

        [NativeTypeName("void (IBufferResource *, Offset, IBufferResource *, Offset, Size)")]
        public IntPtr copyBuffer;

        [NativeTypeName("void (ITextureResource *, ResourceState, SubresourceRange, ITextureResource::Offset3D, ITextureResource *, ResourceState, SubresourceRange, ITextureResource::Offset3D, ITextureResource::Extents)")]
        public IntPtr copyTexture;

        [NativeTypeName("void (IBufferResource *, Offset, Size, Size, ITextureResource *, ResourceState, SubresourceRange, ITextureResource::Offset3D, ITextureResource::Extents)")]
        public IntPtr copyTextureToBuffer;

        [NativeTypeName("void (ITextureResource *, SubresourceRange, ITextureResource::Offset3D, ITextureResource::Extents, ITextureResource::SubresourceData *, GfxCount)")]
        public IntPtr uploadTextureData;

        [NativeTypeName("void (IBufferResource *, Offset, Size, void *)")]
        public IntPtr uploadBufferData;

        [NativeTypeName("void (GfxCount, ITextureResource *const *, ResourceState, ResourceState)")]
        public IntPtr textureBarrier;

        [NativeTypeName("void (ITextureResource *, SubresourceRange, ResourceState, ResourceState)")]
        public IntPtr textureSubresourceBarrier;

        [NativeTypeName("void (GfxCount, IBufferResource *const *, ResourceState, ResourceState)")]
        public IntPtr bufferBarrier;

        [NativeTypeName("void (IResourceView *, ClearValue *, ClearResourceViewFlags::Enum)")]
        public IntPtr clearResourceView;

        [NativeTypeName("void (ITextureResource *, ResourceState, SubresourceRange, ITextureResource *, ResourceState, SubresourceRange)")]
        public IntPtr resolveResource;

        [NativeTypeName("void (IQueryPool *, GfxIndex, GfxCount, IBufferResource *, Offset)")]
        public IntPtr resolveQuery;

        [NativeTypeName("void (const char *, float *)")]
        public IntPtr beginDebugEvent;

        [NativeTypeName("void ()")]
        public IntPtr endDebugEvent;

        [NativeTypeName("Result (IPipelineState *, IShaderObject **)")]
        public IntPtr bindPipeline;

        [NativeTypeName("Result (IPipelineState *, IShaderObject *)")]
        public IntPtr bindPipelineWithRootObject;

        [NativeTypeName("void (GfxCount, const Viewport *)")]
        public IntPtr setViewports;

        [NativeTypeName("void (GfxCount, const ScissorRect *)")]
        public IntPtr setScissorRects;

        [NativeTypeName("void (PrimitiveTopology)")]
        public IntPtr setPrimitiveTopology;

        [NativeTypeName("void (GfxIndex, GfxCount, IBufferResource *const *, const Offset *)")]
        public IntPtr setVertexBuffers;

        [NativeTypeName("void (IBufferResource *, Format, Offset)")]
        public IntPtr setIndexBuffer;

        [NativeTypeName("Result (GfxCount, GfxIndex)")]
        public IntPtr draw;

        [NativeTypeName("Result (GfxCount, GfxIndex, GfxIndex)")]
        public IntPtr drawIndexed;

        [NativeTypeName("Result (GfxCount, IBufferResource *, Offset, IBufferResource *, Offset)")]
        public IntPtr drawIndirect;

        [NativeTypeName("Result (GfxCount, IBufferResource *, Offset, IBufferResource *, Offset)")]
        public IntPtr drawIndexedIndirect;

        [NativeTypeName("void (uint32_t)")]
        public IntPtr setStencilReference;

        [NativeTypeName("Result (GfxCount, GfxCount, const SamplePosition *)")]
        public IntPtr setSamplePositions;

        [NativeTypeName("Result (GfxCount, GfxCount, GfxIndex, GfxIndex)")]
        public IntPtr drawInstanced;

        [NativeTypeName("Result (GfxCount, GfxCount, GfxIndex, GfxIndex, GfxIndex)")]
        public IntPtr drawIndexedInstanced;

        [NativeTypeName("Result (int, int, int)")]
        public IntPtr drawMeshTasks;
    }
}
