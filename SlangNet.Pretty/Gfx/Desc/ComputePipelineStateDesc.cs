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

    public readonly unsafe void AsNative(ref MarshallingAllocBuffer buffer, out Unsafe.ComputePipelineStateDesc native)
    {
        native = new()
        {
            program = Program.Pointer,
            d3d12RootSignatureOverride = (void*)D3D12RootSignatureOverride
        };
    }
} 