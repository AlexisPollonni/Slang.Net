using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using CommunityToolkit.HighPerformance;
using ShaderSlang.Net.ComWrappers.Tools;
using ShaderSlang.Net.ComWrappers.Tools.Internal;

namespace ShaderSlang.Net.ComWrappers.Gfx.Descriptions;

[NativeMarshalling(
    typeof(BidirectionalMarshaller<
        ShaderProgramCreateDescription2,
        Unmanaged.IShaderProgram.CreateDesc2
    >)
)]
public record struct ShaderProgramCreateDescription2(
    Unmanaged.ShaderModuleSourceType SourceType,
    Memory<byte> SourceData,
    IReadOnlyCollection<string> EntryPointNames
)
    : IMarshalsToNative<Unmanaged.IShaderProgram.CreateDesc2>,
        IMarshalsFromNative<ShaderProgramCreateDescription2, Unmanaged.IShaderProgram.CreateDesc2>,
        IFreeAfterMarshal<Unmanaged.IShaderProgram.CreateDesc2>
{
    public Unmanaged.ShaderModuleSourceType SourceType { get; init; } = SourceType;
    public Memory<byte> SourceData { get; init; } = SourceData;
    public IReadOnlyCollection<string> EntryPointNames { get; init; } = EntryPointNames;

    unsafe Unmanaged.IShaderProgram.CreateDesc2 IMarshalsToNative<Unmanaged.IShaderProgram.CreateDesc2>.AsNative(
        ref GrowingStackBuffer buffer
    )
    {
        return new()
        {
            sourceType = SourceType,
            entryPointNames = buffer.GetCollectionPtr(
                EntryPointNames,
                out var entryPointNamesCount
            ),
            entryPointCount = (int)entryPointNamesCount,
            sourceData = SourceData.AllocAndCopyToNativeMemory(),
            sourceDataSize = (UIntPtr)SourceData.Length
        };
    }

    public static unsafe ShaderProgramCreateDescription2 CreateFromNative(
        Unmanaged.IShaderProgram.CreateDesc2 unmanaged
    )
    {
        var dataOwner = new NativeOwnedMemoryManager(
            (byte*)unmanaged.sourceData,
            (int)unmanaged.sourceDataSize
        );
        return new(
            unmanaged.sourceType,
            dataOwner.Memory,
            InteropUtils.PtrToStringArray(unmanaged.entryPointNames, unmanaged.entryPointCount)!
        );
    }

    public static unsafe void Free(scoped ref readonly Unmanaged.IShaderProgram.CreateDesc2 unmanaged)
    {
        NativeMemory.Free(unmanaged.sourceData);
    }
}
