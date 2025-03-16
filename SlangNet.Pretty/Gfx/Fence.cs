using SlangNet.Bindings.Generated;
using SlangNet.Internal;

namespace SlangNet.Gfx;

[GenerateThrowingMethods]
public partial class Fence : COMObject<IFence>
{
    internal unsafe Fence(IFence* pointer) : base(pointer)
    { }

    public unsafe SlangResult TryGetCurrentValue(out ulong value)
    {
        ulong val = 0;
        var result = Pointer->getCurrentValue(&val);
        value = val;
        return result.ToSlangResult();
    }
    
    public unsafe SlangResult TrySetCurrentValue(ulong value)
    {
        return Pointer->setCurrentValue(value).ToSlangResult();
    }

    public unsafe SlangResult TryGetSharedHandle(out InteropHandle handle)
    {
        fixed (InteropHandle* pHandle = &handle)
        {
            var result = Pointer->getSharedHandle(pHandle);
            return result.ToSlangResult();
        }
    }

    public unsafe SlangResult TryGetNativeHandle(out InteropHandle handle)
    {
        fixed (InteropHandle* pHandle = &handle)
        {
            var result = Pointer->getNativeHandle(pHandle);
            return result.ToSlangResult();
        }
    }
} 