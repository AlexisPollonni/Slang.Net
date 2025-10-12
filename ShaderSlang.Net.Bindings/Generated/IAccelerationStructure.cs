using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ShaderSlang.Net.Bindings.Generated;

/// <include file='IAccelerationStructure.xml' path='doc/member[@name="IAccelerationStructure"]/*' />
[NativeTypeName("struct IAccelerationStructure : gfx::IResourceView")]
[NativeInheritance("IResourceView")]
public unsafe partial struct IAccelerationStructure
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(IAccelerationStructure* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(IAccelerationStructure* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(IAccelerationStructure* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::IResourceView::Desc *")]
    public delegate ResourceViewDesc* _getViewDesc(IAccelerationStructure* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _getNativeHandle(IAccelerationStructure* pThis, [NativeTypeName("gfx::InteropHandle *")] InteropHandle* outNativeHandle);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::DeviceAddress")]
    public delegate ulong _getDeviceAddress(IAccelerationStructure* pThis);

    /// <include file='TypeKind.xml' path='doc/member[@name="TypeKind"]/*' />
    public enum TypeKind
    {
        /// <include file='TypeKind.xml' path='doc/member[@name="TypeKind.TopLevel"]/*' />
        TopLevel,

        /// <include file='TypeKind.xml' path='doc/member[@name="TypeKind.BottomLevel"]/*' />
        BottomLevel,
    }

    /// <include file='BuildFlags.xml' path='doc/member[@name="BuildFlags"]/*' />
    public partial struct BuildFlags
    {

        /// <include file='AccelerationStructBuildFlags.xml' path='doc/member[@name="AccelerationStructBuildFlags"]/*' />
        public enum AccelerationStructBuildFlags
        {
            /// <include file='AccelerationStructBuildFlags.xml' path='doc/member[@name="AccelerationStructBuildFlags.None"]/*' />
            None,

            /// <include file='AccelerationStructBuildFlags.xml' path='doc/member[@name="AccelerationStructBuildFlags.AllowUpdate"]/*' />
            AllowUpdate = 1,

            /// <include file='AccelerationStructBuildFlags.xml' path='doc/member[@name="AccelerationStructBuildFlags.AllowCompaction"]/*' />
            AllowCompaction = 2,

            /// <include file='AccelerationStructBuildFlags.xml' path='doc/member[@name="AccelerationStructBuildFlags.PreferFastTrace"]/*' />
            PreferFastTrace = 4,

            /// <include file='AccelerationStructBuildFlags.xml' path='doc/member[@name="AccelerationStructBuildFlags.PreferFastBuild"]/*' />
            PreferFastBuild = 8,

            /// <include file='AccelerationStructBuildFlags.xml' path='doc/member[@name="AccelerationStructBuildFlags.MinimizeMemory"]/*' />
            MinimizeMemory = 16,

            /// <include file='AccelerationStructBuildFlags.xml' path='doc/member[@name="AccelerationStructBuildFlags.PerformUpdate"]/*' />
            PerformUpdate = 32,
        }
    }

    /// <include file='GeometryType.xml' path='doc/member[@name="GeometryType"]/*' />
    public enum GeometryType
    {
        /// <include file='GeometryType.xml' path='doc/member[@name="GeometryType.Triangles"]/*' />
        Triangles,

        /// <include file='GeometryType.xml' path='doc/member[@name="GeometryType.ProcedurePrimitives"]/*' />
        ProcedurePrimitives,
    }

    /// <include file='GeometryFlags.xml' path='doc/member[@name="GeometryFlags"]/*' />
    public partial struct GeometryFlags
    {

        /// <include file='AccelerationStructGeometryFlags.xml' path='doc/member[@name="AccelerationStructGeometryFlags"]/*' />
        public enum AccelerationStructGeometryFlags
        {
            /// <include file='AccelerationStructGeometryFlags.xml' path='doc/member[@name="AccelerationStructGeometryFlags.None"]/*' />
            None,

            /// <include file='AccelerationStructGeometryFlags.xml' path='doc/member[@name="AccelerationStructGeometryFlags.Opaque"]/*' />
            Opaque = 1,

            /// <include file='AccelerationStructGeometryFlags.xml' path='doc/member[@name="AccelerationStructGeometryFlags.NoDuplicateAnyHitInvocation"]/*' />
            NoDuplicateAnyHitInvocation = 2,
        }
    }

    /// <include file='TriangleDesc.xml' path='doc/member[@name="TriangleDesc"]/*' />
    public partial struct TriangleDesc
    {
        /// <include file='TriangleDesc.xml' path='doc/member[@name="TriangleDesc.transform3x4"]/*' />
        [NativeTypeName("gfx::DeviceAddress")]
        public ulong transform3x4;

        /// <include file='TriangleDesc.xml' path='doc/member[@name="TriangleDesc.indexFormat"]/*' />
        [NativeTypeName("gfx::Format")]
        public Format indexFormat;

        /// <include file='TriangleDesc.xml' path='doc/member[@name="TriangleDesc.vertexFormat"]/*' />
        [NativeTypeName("gfx::Format")]
        public Format vertexFormat;

        /// <include file='TriangleDesc.xml' path='doc/member[@name="TriangleDesc.indexCount"]/*' />
        [NativeTypeName("gfx::GfxCount")]
        public int indexCount;

        /// <include file='TriangleDesc.xml' path='doc/member[@name="TriangleDesc.vertexCount"]/*' />
        [NativeTypeName("gfx::GfxCount")]
        public int vertexCount;

        /// <include file='TriangleDesc.xml' path='doc/member[@name="TriangleDesc.indexData"]/*' />
        [NativeTypeName("gfx::DeviceAddress")]
        public ulong indexData;

        /// <include file='TriangleDesc.xml' path='doc/member[@name="TriangleDesc.vertexData"]/*' />
        [NativeTypeName("gfx::DeviceAddress")]
        public ulong vertexData;

        /// <include file='TriangleDesc.xml' path='doc/member[@name="TriangleDesc.vertexStride"]/*' />
        [NativeTypeName("gfx::Size")]
        public nuint vertexStride;
    }

    /// <include file='ProceduralAABB.xml' path='doc/member[@name="ProceduralAABB"]/*' />
    public partial struct ProceduralAABB
    {
        /// <include file='ProceduralAABB.xml' path='doc/member[@name="ProceduralAABB.minX"]/*' />
        public float minX;

        /// <include file='ProceduralAABB.xml' path='doc/member[@name="ProceduralAABB.minY"]/*' />
        public float minY;

        /// <include file='ProceduralAABB.xml' path='doc/member[@name="ProceduralAABB.minZ"]/*' />
        public float minZ;

        /// <include file='ProceduralAABB.xml' path='doc/member[@name="ProceduralAABB.maxX"]/*' />
        public float maxX;

        /// <include file='ProceduralAABB.xml' path='doc/member[@name="ProceduralAABB.maxY"]/*' />
        public float maxY;

        /// <include file='ProceduralAABB.xml' path='doc/member[@name="ProceduralAABB.maxZ"]/*' />
        public float maxZ;
    }

    /// <include file='ProceduralAABBDesc.xml' path='doc/member[@name="ProceduralAABBDesc"]/*' />
    public partial struct ProceduralAABBDesc
    {
        /// <include file='ProceduralAABBDesc.xml' path='doc/member[@name="ProceduralAABBDesc.count"]/*' />
        [NativeTypeName("gfx::GfxCount")]
        public int count;

        /// <include file='ProceduralAABBDesc.xml' path='doc/member[@name="ProceduralAABBDesc.data"]/*' />
        [NativeTypeName("gfx::DeviceAddress")]
        public ulong data;

        /// <include file='ProceduralAABBDesc.xml' path='doc/member[@name="ProceduralAABBDesc.stride"]/*' />
        [NativeTypeName("gfx::Size")]
        public nuint stride;
    }

    /// <include file='GeometryDesc.xml' path='doc/member[@name="GeometryDesc"]/*' />
    public partial struct GeometryDesc
    {
        /// <include file='GeometryDesc.xml' path='doc/member[@name="GeometryDesc.type"]/*' />
        [NativeTypeName("gfx::IAccelerationStructure::GeometryType")]
        public GeometryType type;

        /// <include file='GeometryDesc.xml' path='doc/member[@name="GeometryDesc.flags"]/*' />
        [NativeTypeName("gfx::IAccelerationStructure::GeometryFlags::Enum")]
        public AccelerationStructGeometryFlags flags;

        /// <include file='GeometryDesc.xml' path='doc/member[@name="GeometryDesc.content"]/*' />
        [NativeTypeName("__AnonymousRecord_slang-gfx_L1038_C9")]
        public _content_e__Union content;

        /// <include file='_content_e__Union.xml' path='doc/member[@name="_content_e__Union"]/*' />
        [StructLayout(LayoutKind.Explicit)]
        public partial struct _content_e__Union
        {
            /// <include file='_content_e__Union.xml' path='doc/member[@name="_content_e__Union.triangles"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("gfx::IAccelerationStructure::TriangleDesc")]
            public TriangleDesc triangles;

            /// <include file='_content_e__Union.xml' path='doc/member[@name="_content_e__Union.proceduralAABBs"]/*' />
            [FieldOffset(0)]
            [NativeTypeName("gfx::IAccelerationStructure::ProceduralAABBDesc")]
            public ProceduralAABBDesc proceduralAABBs;
        }
    }

    /// <include file='GeometryInstanceFlags.xml' path='doc/member[@name="GeometryInstanceFlags"]/*' />
    public partial struct GeometryInstanceFlags
    {

        /// <include file='AccelerationStructGeometryInstanceFlags.xml' path='doc/member[@name="AccelerationStructGeometryInstanceFlags"]/*' />
        [NativeTypeName("uint32_t")]
        public enum AccelerationStructGeometryInstanceFlags : uint
        {
            /// <include file='AccelerationStructGeometryInstanceFlags.xml' path='doc/member[@name="AccelerationStructGeometryInstanceFlags.None"]/*' />
            None = 0,

            /// <include file='AccelerationStructGeometryInstanceFlags.xml' path='doc/member[@name="AccelerationStructGeometryInstanceFlags.TriangleFacingCullDisable"]/*' />
            TriangleFacingCullDisable = 0x00000001,

            /// <include file='AccelerationStructGeometryInstanceFlags.xml' path='doc/member[@name="AccelerationStructGeometryInstanceFlags.TriangleFrontCounterClockwise"]/*' />
            TriangleFrontCounterClockwise = 0x00000002,

            /// <include file='AccelerationStructGeometryInstanceFlags.xml' path='doc/member[@name="AccelerationStructGeometryInstanceFlags.ForceOpaque"]/*' />
            ForceOpaque = 0x00000004,

            /// <include file='AccelerationStructGeometryInstanceFlags.xml' path='doc/member[@name="AccelerationStructGeometryInstanceFlags.NoOpaque"]/*' />
            NoOpaque = 0x00000008,
        }
    }

    /// <include file='InstanceDesc.xml' path='doc/member[@name="InstanceDesc"]/*' />
    public partial struct InstanceDesc
    {
        /// <include file='InstanceDesc.xml' path='doc/member[@name="InstanceDesc.transform"]/*' />
        [NativeTypeName("float[3][4]")]
        public _transform_e__FixedBuffer transform;

        public uint _bitfield1;

        /// <include file='InstanceDesc.xml' path='doc/member[@name="InstanceDesc.instanceID"]/*' />
        [NativeTypeName("uint32_t : 24")]
        public uint instanceID
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                return _bitfield1 & 0xFFFFFFu;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                _bitfield1 = (_bitfield1 & ~0xFFFFFFu) | (value & 0xFFFFFFu);
            }
        }

        /// <include file='InstanceDesc.xml' path='doc/member[@name="InstanceDesc.instanceMask"]/*' />
        [NativeTypeName("uint32_t : 8")]
        public uint instanceMask
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                return (_bitfield1 >> 24) & 0xFFu;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                _bitfield1 = (_bitfield1 & ~(0xFFu << 24)) | ((value & 0xFFu) << 24);
            }
        }

        public uint _bitfield2;

        /// <include file='InstanceDesc.xml' path='doc/member[@name="InstanceDesc.instanceContributionToHitGroupIndex"]/*' />
        [NativeTypeName("uint32_t : 24")]
        public uint instanceContributionToHitGroupIndex
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                return _bitfield2 & 0xFFFFFFu;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                _bitfield2 = (_bitfield2 & ~0xFFFFFFu) | (value & 0xFFFFFFu);
            }
        }

        /// <include file='InstanceDesc.xml' path='doc/member[@name="InstanceDesc.flags"]/*' />
        [NativeTypeName("uint32_t : 8")]
        public uint flags
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                return (_bitfield2 >> 24) & 0xFFu;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                _bitfield2 = (_bitfield2 & ~(0xFFu << 24)) | ((value & 0xFFu) << 24);
            }
        }

        /// <include file='InstanceDesc.xml' path='doc/member[@name="InstanceDesc.accelerationStructure"]/*' />
        [NativeTypeName("gfx::DeviceAddress")]
        public ulong accelerationStructure;

        /// <include file='_transform_e__FixedBuffer.xml' path='doc/member[@name="_transform_e__FixedBuffer"]/*' />
        [InlineArray(3 * 4)]
        public partial struct _transform_e__FixedBuffer
        {
            public float e0_0;
        }
    }

    /// <include file='PrebuildInfo.xml' path='doc/member[@name="PrebuildInfo"]/*' />
    public partial struct PrebuildInfo
    {
        /// <include file='PrebuildInfo.xml' path='doc/member[@name="PrebuildInfo.resultDataMaxSize"]/*' />
        [NativeTypeName("gfx::Size")]
        public nuint resultDataMaxSize;

        /// <include file='PrebuildInfo.xml' path='doc/member[@name="PrebuildInfo.scratchDataSize"]/*' />
        [NativeTypeName("gfx::Size")]
        public nuint scratchDataSize;

        /// <include file='PrebuildInfo.xml' path='doc/member[@name="PrebuildInfo.updateScratchDataSize"]/*' />
        [NativeTypeName("gfx::Size")]
        public nuint updateScratchDataSize;
    }

    /// <include file='BuildInputs.xml' path='doc/member[@name="BuildInputs"]/*' />
    public unsafe partial struct BuildInputs
    {
        /// <include file='BuildInputs.xml' path='doc/member[@name="BuildInputs.kind"]/*' />
        [NativeTypeName("gfx::IAccelerationStructure::Kind")]
        public TypeKind kind;

        /// <include file='BuildInputs.xml' path='doc/member[@name="BuildInputs.flags"]/*' />
        [NativeTypeName("gfx::IAccelerationStructure::BuildFlags::Enum")]
        public AccelerationStructBuildFlags flags;

        /// <include file='BuildInputs.xml' path='doc/member[@name="BuildInputs.descCount"]/*' />
        [NativeTypeName("gfx::GfxCount")]
        public int descCount;

        /// <include file='BuildInputs.xml' path='doc/member[@name="BuildInputs.instanceDescs"]/*' />
        [NativeTypeName("gfx::DeviceAddress")]
        public ulong instanceDescs;

        /// <include file='BuildInputs.xml' path='doc/member[@name="BuildInputs.geometryDescs"]/*' />
        [NativeTypeName("const GeometryDesc *")]
        public GeometryDesc* geometryDescs;
    }

    /// <include file='CreateDesc.xml' path='doc/member[@name="CreateDesc"]/*' />
    public unsafe partial struct CreateDesc
    {
        /// <include file='CreateDesc.xml' path='doc/member[@name="CreateDesc.kind"]/*' />
        [NativeTypeName("gfx::IAccelerationStructure::Kind")]
        public TypeKind kind;

        /// <include file='CreateDesc.xml' path='doc/member[@name="CreateDesc.buffer"]/*' />
        [NativeTypeName("gfx::IBufferResource *")]
        public IBufferResource* buffer;

        /// <include file='CreateDesc.xml' path='doc/member[@name="CreateDesc.offset"]/*' />
        [NativeTypeName("gfx::Offset")]
        public nuint offset;

        /// <include file='CreateDesc.xml' path='doc/member[@name="CreateDesc.size"]/*' />
        [NativeTypeName("gfx::Size")]
        public nuint size;
    }

    /// <include file='BuildDesc.xml' path='doc/member[@name="BuildDesc"]/*' />
    public unsafe partial struct BuildDesc
    {
        /// <include file='BuildDesc.xml' path='doc/member[@name="BuildDesc.inputs"]/*' />
        [NativeTypeName("gfx::IAccelerationStructure::BuildInputs")]
        public BuildInputs inputs;

        /// <include file='BuildDesc.xml' path='doc/member[@name="BuildDesc.source"]/*' />
        [NativeTypeName("gfx::IAccelerationStructure *")]
        public IAccelerationStructure* source;

        /// <include file='BuildDesc.xml' path='doc/member[@name="BuildDesc.dest"]/*' />
        [NativeTypeName("gfx::IAccelerationStructure *")]
        public IAccelerationStructure* dest;

        /// <include file='BuildDesc.xml' path='doc/member[@name="BuildDesc.scratchData"]/*' />
        [NativeTypeName("gfx::DeviceAddress")]
        public ulong scratchData;
    }

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((IAccelerationStructure*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((IAccelerationStructure*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((IAccelerationStructure*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="IResourceView.getViewDesc" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::IResourceView::Desc *")]
    public ResourceViewDesc* getViewDesc()
    {
        return Marshal.GetDelegateForFunctionPointer<_getViewDesc>(lpVtbl->getViewDesc)((IAccelerationStructure*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="IResourceView.getNativeHandle" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int getNativeHandle([NativeTypeName("gfx::InteropHandle *")] InteropHandle* outNativeHandle)
    {
        return Marshal.GetDelegateForFunctionPointer<_getNativeHandle>(lpVtbl->getNativeHandle)((IAccelerationStructure*)Unsafe.AsPointer(ref this), outNativeHandle);
    }

    /// <include file='IAccelerationStructure.xml' path='doc/member[@name="IAccelerationStructure.getDeviceAddress"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::DeviceAddress")]
    public ulong getDeviceAddress()
    {
        return Marshal.GetDelegateForFunctionPointer<_getDeviceAddress>(lpVtbl->getDeviceAddress)((IAccelerationStructure*)Unsafe.AsPointer(ref this));
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr release;

        [NativeTypeName("Desc *() __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getViewDesc;

        [NativeTypeName("Result (InteropHandle *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getNativeHandle;

        [NativeTypeName("DeviceAddress () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getDeviceAddress;
    }
}
