using SlangNet.Internal;

namespace SlangNet.Gfx;

[GenerateThrowingMethods]
public abstract partial class Resource : COMObject<IResource>
{
    protected unsafe Resource(IResource* pointer) : base(pointer) { }

    public unsafe IResource.ResourceType Type => Pointer->getType();

    public unsafe string? DebugName
    {
        get => InteropUtils.PtrToStringUTF8(Pointer->getDebugName());
        set => TrySetDebugName(value).ThrowIfFailed();
    }

    public unsafe SlangResult TrySetDebugName(string? name)
    {
        return name.MarshalToNative(ptrName => Pointer->setDebugName(ptrName).ToSlangResult());
    }

    public unsafe SlangResult TryGetNativeResourceHandle(out InteropHandle handle)
    {
        fixed (InteropHandle* pHandle = &handle)
        {
            return Pointer->getNativeResourceHandle(pHandle).ToSlangResult();
        }
    }

    public unsafe SlangResult TryGetSharedHandle(out InteropHandle handle)
    {
        fixed (InteropHandle* pHandle = &handle)
        {
            return Pointer->getSharedHandle(pHandle).ToSlangResult();
        }
    }

}