using System;
using SlangNet.Gfx.Desc;
using SlangNet.Internal;

namespace SlangNet.Gfx;

public class ResourceView : COMObject<IResourceView>
{
    internal unsafe ResourceView(IResourceView* pointer) : base(pointer)
    { }

    public unsafe SlangResult TryGetNativeHandle(out InteropHandle handle)
    {
        handle = default;
        fixed (InteropHandle* pHandle = &handle)
        {
            return Pointer->getNativeHandle(pHandle).ToSlangResult();
        }
    }

    public unsafe SlangResult TryGetViewDesc(out ResourceViewDesc? desc)
    {
        var ptr = Pointer->getViewDesc();

        if (ptr is null)
        {
            desc = null;
            return SlangResult.Fail;
        }

        ResourceViewDesc.CreateFromNative(*ptr, out var viewDesc);
        desc = viewDesc;

        return SlangResult.Ok;
    }
}
