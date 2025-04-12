using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Interfaces;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers.Gfx.Descriptions;

[NativeMarshalling(
    typeof(MarshalableMarshaller.Bidirectional<ShaderProgramDescription, Unmanaged.IShaderProgram.ShaderProgramDesc>))]
public readonly record struct ShaderProgramDescription(
    Unmanaged.IShaderProgram.LinkingStyle LinkingStyle = Unmanaged.IShaderProgram.LinkingStyle.SingleProgram,
    IComponentType? GlobalScope = null,
    IComponentType[]? EntryPoints = null,
    Unmanaged.IShaderProgram.DownstreamLinkMode LinkMode = Unmanaged.IShaderProgram.DownstreamLinkMode.None)
    : IMarshalsToNative<Unmanaged.IShaderProgram.ShaderProgramDesc>,
      IMarshalsFromNative<ShaderProgramDescription, Unmanaged.IShaderProgram.ShaderProgramDesc>,
      IFreeAfterMarshal<Unmanaged.IShaderProgram.ShaderProgramDesc>
{
    unsafe Unmanaged.IShaderProgram.ShaderProgramDesc IMarshalsToNative<Unmanaged.IShaderProgram.ShaderProgramDesc>.AsNative(
        ref GrowingStackBuffer buffer) =>
        new()
        {
            linkingStyle = LinkingStyle,
            slangGlobalScope
                = (Unmanaged.IComponentType*)ComInterfaceMarshaller<IComponentType>.ConvertToUnmanaged(GlobalScope),
            slangEntryPoints
                = buffer.GetComCollectionPtr<IComponentType, Unmanaged.IComponentType>(EntryPoints, out var entryCount),
            entryPointCount = checked((int)entryCount),
            downstreamLinkMode = LinkMode
        };

    public static unsafe ShaderProgramDescription CreateFromNative(Unmanaged.IShaderProgram.ShaderProgramDesc unmanaged)
    {
        return new(unmanaged.linkingStyle,
                   ComInterfaceMarshaller<IComponentType>.ConvertToManaged(unmanaged.slangGlobalScope),
                   InteropUtils.ComPtrToManagedMarshal<IComponentType, Unmanaged.IComponentType>(
                       unmanaged.slangEntryPoints,
                       unmanaged.entryPointCount),
                   unmanaged.downstreamLinkMode);
    }

    public unsafe void Free(Unmanaged.IShaderProgram.ShaderProgramDesc* unmanaged)
    {
        ComInterfaceMarshaller<IComponentType>.Free(unmanaged->slangGlobalScope);
        for (var i = 0; i < unmanaged->entryPointCount; i++)
        {
            ComInterfaceMarshaller<IComponentType>.Free(unmanaged->slangEntryPoints[i]);
        }
    }
}