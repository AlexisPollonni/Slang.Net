using System;
using SlangNet.Internal;

namespace SlangNet.Gfx.Desc;

public record struct CommandQueueDesc(ICommandQueue.QueueType Type) : 
    IMarshalsToNative<ICommandQueue.CommandQueueDesc>, IMarshalsFromNative<CommandQueueDesc, ICommandQueue.CommandQueueDesc>
{
    public readonly int GetNativeAllocSize() => SysUnsafe.SizeOf<ICommandQueue.CommandQueueDesc>();

    public void AsNative(ref MarshallingAllocBuffer buffer, out ICommandQueue.CommandQueueDesc native)
    {
        native = new() { type = Type };
    }

    public static void CreateFromNative(ICommandQueue.CommandQueueDesc native, out CommandQueueDesc managed)
    {
        managed = new(native.type);
    }
}
