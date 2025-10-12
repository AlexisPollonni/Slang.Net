using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.ComWrappers.Tools;

namespace ShaderSlang.Net.ComWrappers.Gfx.Descriptions;

[NativeMarshalling(typeof(MarshalableMarshaller.Bidirectional<CommandQueueDescription, Unmanaged.ICommandQueue.CommandQueueDesc>))]
public readonly record struct CommandQueueDescription(Unmanaged.ICommandQueue.QueueType Type) : 
    IMarshalsToNative<Unmanaged.ICommandQueue.CommandQueueDesc>, IMarshalsFromNative<CommandQueueDescription, Unmanaged.ICommandQueue.CommandQueueDesc>
{
    Unmanaged.ICommandQueue.CommandQueueDesc IMarshalsToNative<Unmanaged.ICommandQueue.CommandQueueDesc>.AsNative(ref GrowingStackBuffer buffer) =>
        new() { type = Type };

    public static CommandQueueDescription CreateFromNative(Unmanaged.ICommandQueue.CommandQueueDesc unmanaged) =>
        new(unmanaged.type);
}
