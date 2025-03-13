using System;
using Nito.Disposables;
using SlangNet.Internal;

namespace SlangNet.Gfx;

public record struct ComputePipelineStateDesc(
    ShaderProgram Program,
    IntPtr D3D12RootSignatureOverride = default
) : IMarshalsToNative<Unsafe.ComputePipelineStateDesc>
{
    public readonly int GetNativeAllocSize()
    {
        return SysUnsafe.SizeOf<Unsafe.ComputePipelineStateDesc>();
    }

    public unsafe void AsNative(MarshallingAllocBuffer buffer, out Unsafe.ComputePipelineStateDesc native)
    {
        native = new Unsafe.ComputePipelineStateDesc
        {
            program = Program.Pointer,
            d3d12RootSignatureOverride = (void*)D3D12RootSignatureOverride
        };
    }
} 