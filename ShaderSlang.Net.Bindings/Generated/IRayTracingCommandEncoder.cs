using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ShaderSlang.Net.Bindings.Generated;

/// <include file='IRayTracingCommandEncoder.xml' path='doc/member[@name="IRayTracingCommandEncoder"]/*' />
[Guid("9A672B87-5035-45E3-967C-1F85CDB3634F")]
[NativeTypeName("struct IRayTracingCommandEncoder : gfx::IResourceCommandEncoder")]
[NativeInheritance("IResourceCommandEncoder")]
public unsafe partial struct IRayTracingCommandEncoder
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(
        IRayTracingCommandEncoder* pThis,
        [NativeTypeName("const SlangUUID &")] SlangUUID* uuid,
        void** outObject
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(IRayTracingCommandEncoder* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(IRayTracingCommandEncoder* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _endEncoding(IRayTracingCommandEncoder* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _writeTimestamp(
        IRayTracingCommandEncoder* pThis,
        [NativeTypeName("gfx::IQueryPool *")] IQueryPool* queryPool,
        [NativeTypeName("gfx::GfxIndex")] int queryIndex
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _copyBuffer(
        IRayTracingCommandEncoder* pThis,
        [NativeTypeName("gfx::IBufferResource *")] IBufferResource* dst,
        [NativeTypeName("gfx::Offset")] nuint dstOffset,
        [NativeTypeName("gfx::IBufferResource *")] IBufferResource* src,
        [NativeTypeName("gfx::Offset")] nuint srcOffset,
        [NativeTypeName("gfx::Size")] nuint size
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _copyTexture(
        IRayTracingCommandEncoder* pThis,
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
        IRayTracingCommandEncoder* pThis,
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
        IRayTracingCommandEncoder* pThis,
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
        IRayTracingCommandEncoder* pThis,
        [NativeTypeName("gfx::IBufferResource *")] IBufferResource* dst,
        [NativeTypeName("gfx::Offset")] nuint offset,
        [NativeTypeName("gfx::Size")] nuint size,
        void* data
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _textureBarrier(
        IRayTracingCommandEncoder* pThis,
        [NativeTypeName("gfx::GfxCount")] int count,
        [NativeTypeName("ITextureResource *const *")] ITextureResource** textures,
        [NativeTypeName("gfx::ResourceState")] ResourceState src,
        [NativeTypeName("gfx::ResourceState")] ResourceState dst
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _textureSubresourceBarrier(
        IRayTracingCommandEncoder* pThis,
        [NativeTypeName("gfx::ITextureResource *")] ITextureResource* texture,
        [NativeTypeName("gfx::SubresourceRange")] SubresourceRange subresourceRange,
        [NativeTypeName("gfx::ResourceState")] ResourceState src,
        [NativeTypeName("gfx::ResourceState")] ResourceState dst
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _bufferBarrier(
        IRayTracingCommandEncoder* pThis,
        [NativeTypeName("gfx::GfxCount")] int count,
        [NativeTypeName("IBufferResource *const *")] IBufferResource** buffers,
        [NativeTypeName("gfx::ResourceState")] ResourceState src,
        [NativeTypeName("gfx::ResourceState")] ResourceState dst
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _clearResourceView(
        IRayTracingCommandEncoder* pThis,
        [NativeTypeName("gfx::IResourceView *")] IResourceView* view,
        [NativeTypeName("gfx::ClearValue *")] ClearValue* clearValue,
        [NativeTypeName("gfx::ClearResourceViewFlags::Enum")] Enum flags
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _resolveResource(
        IRayTracingCommandEncoder* pThis,
        [NativeTypeName("gfx::ITextureResource *")] ITextureResource* source,
        [NativeTypeName("gfx::ResourceState")] ResourceState sourceState,
        [NativeTypeName("gfx::SubresourceRange")] SubresourceRange sourceRange,
        [NativeTypeName("gfx::ITextureResource *")] ITextureResource* dest,
        [NativeTypeName("gfx::ResourceState")] ResourceState destState,
        [NativeTypeName("gfx::SubresourceRange")] SubresourceRange destRange
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _resolveQuery(
        IRayTracingCommandEncoder* pThis,
        [NativeTypeName("gfx::IQueryPool *")] IQueryPool* queryPool,
        [NativeTypeName("gfx::GfxIndex")] int index,
        [NativeTypeName("gfx::GfxCount")] int count,
        [NativeTypeName("gfx::IBufferResource *")] IBufferResource* buffer,
        [NativeTypeName("gfx::Offset")] nuint offset
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _beginDebugEvent(
        IRayTracingCommandEncoder* pThis,
        [NativeTypeName("const char *")] sbyte* name,
        [NativeTypeName("float[3]")] float* rgbColor
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _endDebugEvent(IRayTracingCommandEncoder* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _buildAccelerationStructure(
        IRayTracingCommandEncoder* pThis,
        [NativeTypeName("const IAccelerationStructure::BuildDesc &")] BuildDesc* desc,
        [NativeTypeName("gfx::GfxCount")] int propertyQueryCount,
        [NativeTypeName("gfx::AccelerationStructureQueryDesc *")]
            AccelerationStructureQueryDesc* queryDescs
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _copyAccelerationStructure(
        IRayTracingCommandEncoder* pThis,
        [NativeTypeName("gfx::IAccelerationStructure *")] IAccelerationStructure* dest,
        [NativeTypeName("gfx::IAccelerationStructure *")] IAccelerationStructure* src,
        [NativeTypeName("gfx::AccelerationStructureCopyMode")] AccelerationStructureCopyMode mode
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _queryAccelerationStructureProperties(
        IRayTracingCommandEncoder* pThis,
        [NativeTypeName("gfx::GfxCount")] int accelerationStructureCount,
        [NativeTypeName("IAccelerationStructure *const *")]
            IAccelerationStructure** accelerationStructures,
        [NativeTypeName("gfx::GfxCount")] int queryCount,
        [NativeTypeName("gfx::AccelerationStructureQueryDesc *")]
            AccelerationStructureQueryDesc* queryDescs
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _serializeAccelerationStructure(
        IRayTracingCommandEncoder* pThis,
        [NativeTypeName("gfx::DeviceAddress")] ulong dest,
        [NativeTypeName("gfx::IAccelerationStructure *")] IAccelerationStructure* source
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _deserializeAccelerationStructure(
        IRayTracingCommandEncoder* pThis,
        [NativeTypeName("gfx::IAccelerationStructure *")] IAccelerationStructure* dest,
        [NativeTypeName("gfx::DeviceAddress")] ulong source
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _bindPipeline(
        IRayTracingCommandEncoder* pThis,
        [NativeTypeName("gfx::IPipelineState *")] IPipelineState* state,
        IShaderObject** outRootObject
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _bindPipelineWithRootObject(
        IRayTracingCommandEncoder* pThis,
        [NativeTypeName("gfx::IPipelineState *")] IPipelineState* state,
        [NativeTypeName("gfx::IShaderObject *")] IShaderObject* rootObject
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _dispatchRays(
        IRayTracingCommandEncoder* pThis,
        [NativeTypeName("gfx::GfxIndex")] int rayGenShaderIndex,
        [NativeTypeName("gfx::IShaderTable *")] IShaderTable* shaderTable,
        [NativeTypeName("gfx::GfxCount")] int width,
        [NativeTypeName("gfx::GfxCount")] int height,
        [NativeTypeName("gfx::GfxCount")] int depth
    );

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface(
        [NativeTypeName("const SlangUUID &")] SlangUUID* uuid,
        void** outObject
    )
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)(
            (IRayTracingCommandEncoder*)Unsafe.AsPointer(ref this),
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
            (IRayTracingCommandEncoder*)Unsafe.AsPointer(ref this)
        );
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)(
            (IRayTracingCommandEncoder*)Unsafe.AsPointer(ref this)
        );
    }

    /// <inheritdoc cref="ICommandEncoder.endEncoding" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void endEncoding()
    {
        Marshal.GetDelegateForFunctionPointer<_endEncoding>(lpVtbl->endEncoding)(
            (IRayTracingCommandEncoder*)Unsafe.AsPointer(ref this)
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
            (IRayTracingCommandEncoder*)Unsafe.AsPointer(ref this),
            queryPool,
            queryIndex
        );
    }

    /// <inheritdoc cref="IResourceCommandEncoder.copyBuffer" />
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
            (IRayTracingCommandEncoder*)Unsafe.AsPointer(ref this),
            dst,
            dstOffset,
            src,
            srcOffset,
            size
        );
    }

    /// <inheritdoc cref="IResourceCommandEncoder.copyTexture" />
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
            (IRayTracingCommandEncoder*)Unsafe.AsPointer(ref this),
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

    /// <inheritdoc cref="IResourceCommandEncoder.copyTextureToBuffer" />
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
            (IRayTracingCommandEncoder*)Unsafe.AsPointer(ref this),
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

    /// <inheritdoc cref="IResourceCommandEncoder.uploadTextureData" />
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
            (IRayTracingCommandEncoder*)Unsafe.AsPointer(ref this),
            dst,
            subResourceRange,
            offset,
            extent,
            subResourceData,
            subResourceDataCount
        );
    }

    /// <inheritdoc cref="IResourceCommandEncoder.uploadBufferData" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void uploadBufferData(
        [NativeTypeName("gfx::IBufferResource *")] IBufferResource* dst,
        [NativeTypeName("gfx::Offset")] nuint offset,
        [NativeTypeName("gfx::Size")] nuint size,
        void* data
    )
    {
        Marshal.GetDelegateForFunctionPointer<_uploadBufferData>(lpVtbl->uploadBufferData)(
            (IRayTracingCommandEncoder*)Unsafe.AsPointer(ref this),
            dst,
            offset,
            size,
            data
        );
    }

    /// <inheritdoc cref="IResourceCommandEncoder.textureBarrier" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void textureBarrier(
        [NativeTypeName("gfx::GfxCount")] int count,
        [NativeTypeName("ITextureResource *const *")] ITextureResource** textures,
        [NativeTypeName("gfx::ResourceState")] ResourceState src,
        [NativeTypeName("gfx::ResourceState")] ResourceState dst
    )
    {
        Marshal.GetDelegateForFunctionPointer<_textureBarrier>(lpVtbl->textureBarrier)(
            (IRayTracingCommandEncoder*)Unsafe.AsPointer(ref this),
            count,
            textures,
            src,
            dst
        );
    }

    /// <inheritdoc cref="IResourceCommandEncoder.textureSubresourceBarrier" />
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
            (IRayTracingCommandEncoder*)Unsafe.AsPointer(ref this),
            texture,
            subresourceRange,
            src,
            dst
        );
    }

    /// <inheritdoc cref="IResourceCommandEncoder.bufferBarrier" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void bufferBarrier(
        [NativeTypeName("gfx::GfxCount")] int count,
        [NativeTypeName("IBufferResource *const *")] IBufferResource** buffers,
        [NativeTypeName("gfx::ResourceState")] ResourceState src,
        [NativeTypeName("gfx::ResourceState")] ResourceState dst
    )
    {
        Marshal.GetDelegateForFunctionPointer<_bufferBarrier>(lpVtbl->bufferBarrier)(
            (IRayTracingCommandEncoder*)Unsafe.AsPointer(ref this),
            count,
            buffers,
            src,
            dst
        );
    }

    /// <inheritdoc cref="IResourceCommandEncoder.clearResourceView" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void clearResourceView(
        [NativeTypeName("gfx::IResourceView *")] IResourceView* view,
        [NativeTypeName("gfx::ClearValue *")] ClearValue* clearValue,
        [NativeTypeName("gfx::ClearResourceViewFlags::Enum")] Enum flags
    )
    {
        Marshal.GetDelegateForFunctionPointer<_clearResourceView>(lpVtbl->clearResourceView)(
            (IRayTracingCommandEncoder*)Unsafe.AsPointer(ref this),
            view,
            clearValue,
            flags
        );
    }

    /// <inheritdoc cref="IResourceCommandEncoder.resolveResource" />
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
            (IRayTracingCommandEncoder*)Unsafe.AsPointer(ref this),
            source,
            sourceState,
            sourceRange,
            dest,
            destState,
            destRange
        );
    }

    /// <inheritdoc cref="IResourceCommandEncoder.resolveQuery" />
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
            (IRayTracingCommandEncoder*)Unsafe.AsPointer(ref this),
            queryPool,
            index,
            count,
            buffer,
            offset
        );
    }

    /// <inheritdoc cref="IResourceCommandEncoder.beginDebugEvent" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void beginDebugEvent(
        [NativeTypeName("const char *")] sbyte* name,
        [NativeTypeName("float[3]")] float* rgbColor
    )
    {
        Marshal.GetDelegateForFunctionPointer<_beginDebugEvent>(lpVtbl->beginDebugEvent)(
            (IRayTracingCommandEncoder*)Unsafe.AsPointer(ref this),
            name,
            rgbColor
        );
    }

    /// <inheritdoc cref="IResourceCommandEncoder.endDebugEvent" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void endDebugEvent()
    {
        Marshal.GetDelegateForFunctionPointer<_endDebugEvent>(lpVtbl->endDebugEvent)(
            (IRayTracingCommandEncoder*)Unsafe.AsPointer(ref this)
        );
    }

    /// <include file='IRayTracingCommandEncoder.xml' path='doc/member[@name="IRayTracingCommandEncoder.buildAccelerationStructure"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void buildAccelerationStructure(
        [NativeTypeName("const IAccelerationStructure::BuildDesc &")] BuildDesc* desc,
        [NativeTypeName("gfx::GfxCount")] int propertyQueryCount,
        [NativeTypeName("gfx::AccelerationStructureQueryDesc *")]
            AccelerationStructureQueryDesc* queryDescs
    )
    {
        Marshal.GetDelegateForFunctionPointer<_buildAccelerationStructure>(
            lpVtbl->buildAccelerationStructure
        )(
            (IRayTracingCommandEncoder*)Unsafe.AsPointer(ref this),
            desc,
            propertyQueryCount,
            queryDescs
        );
    }

    /// <include file='IRayTracingCommandEncoder.xml' path='doc/member[@name="IRayTracingCommandEncoder.copyAccelerationStructure"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void copyAccelerationStructure(
        [NativeTypeName("gfx::IAccelerationStructure *")] IAccelerationStructure* dest,
        [NativeTypeName("gfx::IAccelerationStructure *")] IAccelerationStructure* src,
        [NativeTypeName("gfx::AccelerationStructureCopyMode")] AccelerationStructureCopyMode mode
    )
    {
        Marshal.GetDelegateForFunctionPointer<_copyAccelerationStructure>(
            lpVtbl->copyAccelerationStructure
        )((IRayTracingCommandEncoder*)Unsafe.AsPointer(ref this), dest, src, mode);
    }

    /// <include file='IRayTracingCommandEncoder.xml' path='doc/member[@name="IRayTracingCommandEncoder.queryAccelerationStructureProperties"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void queryAccelerationStructureProperties(
        [NativeTypeName("gfx::GfxCount")] int accelerationStructureCount,
        [NativeTypeName("IAccelerationStructure *const *")]
            IAccelerationStructure** accelerationStructures,
        [NativeTypeName("gfx::GfxCount")] int queryCount,
        [NativeTypeName("gfx::AccelerationStructureQueryDesc *")]
            AccelerationStructureQueryDesc* queryDescs
    )
    {
        Marshal.GetDelegateForFunctionPointer<_queryAccelerationStructureProperties>(
            lpVtbl->queryAccelerationStructureProperties
        )(
            (IRayTracingCommandEncoder*)Unsafe.AsPointer(ref this),
            accelerationStructureCount,
            accelerationStructures,
            queryCount,
            queryDescs
        );
    }

    /// <include file='IRayTracingCommandEncoder.xml' path='doc/member[@name="IRayTracingCommandEncoder.serializeAccelerationStructure"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void serializeAccelerationStructure(
        [NativeTypeName("gfx::DeviceAddress")] ulong dest,
        [NativeTypeName("gfx::IAccelerationStructure *")] IAccelerationStructure* source
    )
    {
        Marshal.GetDelegateForFunctionPointer<_serializeAccelerationStructure>(
            lpVtbl->serializeAccelerationStructure
        )((IRayTracingCommandEncoder*)Unsafe.AsPointer(ref this), dest, source);
    }

    /// <include file='IRayTracingCommandEncoder.xml' path='doc/member[@name="IRayTracingCommandEncoder.deserializeAccelerationStructure"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void deserializeAccelerationStructure(
        [NativeTypeName("gfx::IAccelerationStructure *")] IAccelerationStructure* dest,
        [NativeTypeName("gfx::DeviceAddress")] ulong source
    )
    {
        Marshal.GetDelegateForFunctionPointer<_deserializeAccelerationStructure>(
            lpVtbl->deserializeAccelerationStructure
        )((IRayTracingCommandEncoder*)Unsafe.AsPointer(ref this), dest, source);
    }

    /// <include file='IRayTracingCommandEncoder.xml' path='doc/member[@name="IRayTracingCommandEncoder.bindPipeline"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int bindPipeline(
        [NativeTypeName("gfx::IPipelineState *")] IPipelineState* state,
        IShaderObject** outRootObject
    )
    {
        return Marshal.GetDelegateForFunctionPointer<_bindPipeline>(lpVtbl->bindPipeline)(
            (IRayTracingCommandEncoder*)Unsafe.AsPointer(ref this),
            state,
            outRootObject
        );
    }

    /// <include file='IRayTracingCommandEncoder.xml' path='doc/member[@name="IRayTracingCommandEncoder.bindPipelineWithRootObject"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int bindPipelineWithRootObject(
        [NativeTypeName("gfx::IPipelineState *")] IPipelineState* state,
        [NativeTypeName("gfx::IShaderObject *")] IShaderObject* rootObject
    )
    {
        return Marshal.GetDelegateForFunctionPointer<_bindPipelineWithRootObject>(
            lpVtbl->bindPipelineWithRootObject
        )((IRayTracingCommandEncoder*)Unsafe.AsPointer(ref this), state, rootObject);
    }

    /// <include file='IRayTracingCommandEncoder.xml' path='doc/member[@name="IRayTracingCommandEncoder.dispatchRays"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int dispatchRays(
        [NativeTypeName("gfx::GfxIndex")] int rayGenShaderIndex,
        [NativeTypeName("gfx::IShaderTable *")] IShaderTable* shaderTable,
        [NativeTypeName("gfx::GfxCount")] int width,
        [NativeTypeName("gfx::GfxCount")] int height,
        [NativeTypeName("gfx::GfxCount")] int depth
    )
    {
        return Marshal.GetDelegateForFunctionPointer<_dispatchRays>(lpVtbl->dispatchRays)(
            (IRayTracingCommandEncoder*)Unsafe.AsPointer(ref this),
            rayGenShaderIndex,
            shaderTable,
            width,
            height,
            depth
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

        [NativeTypeName(
            "void (const IAccelerationStructure::BuildDesc &, GfxCount, AccelerationStructureQueryDesc *) __attribute__((stdcall))"
        )]
        public IntPtr buildAccelerationStructure;

        [NativeTypeName(
            "void (IAccelerationStructure *, IAccelerationStructure *, AccelerationStructureCopyMode) __attribute__((stdcall))"
        )]
        public IntPtr copyAccelerationStructure;

        [NativeTypeName(
            "void (GfxCount, IAccelerationStructure *const *, GfxCount, AccelerationStructureQueryDesc *) __attribute__((stdcall))"
        )]
        public IntPtr queryAccelerationStructureProperties;

        [NativeTypeName("void (DeviceAddress, IAccelerationStructure *) __attribute__((stdcall))")]
        public IntPtr serializeAccelerationStructure;

        [NativeTypeName("void (IAccelerationStructure *, DeviceAddress) __attribute__((stdcall))")]
        public IntPtr deserializeAccelerationStructure;

        [NativeTypeName("Result (IPipelineState *, IShaderObject **) __attribute__((stdcall))")]
        public IntPtr bindPipeline;

        [NativeTypeName("Result (IPipelineState *, IShaderObject *) __attribute__((stdcall))")]
        public IntPtr bindPipelineWithRootObject;

        [NativeTypeName(
            "Result (GfxIndex, IShaderTable *, GfxCount, GfxCount, GfxCount) __attribute__((stdcall))"
        )]
        public IntPtr dispatchRays;
    }
}
