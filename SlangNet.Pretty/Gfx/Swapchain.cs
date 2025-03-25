using SlangNet.Gfx.Desc;
using SlangNet.Internal;

namespace SlangNet.Gfx;

[GenerateThrowingMethods]
public partial class Swapchain : COMObject<ISwapchain>
{
    protected internal unsafe Swapchain(ISwapchain* pointer) : base(pointer) { }

    public unsafe SwapchainDesc GetDesc()
    {
        var nativePtr = Pointer->getDesc();

        SwapchainDesc.CreateFromNative(*nativePtr, out var managed);
        return managed;
    }

    public unsafe SlangResult TryGetImage(int index, out TextureResource? resource)
    {
        ITextureResource* resourcePtr;
        var res = Pointer->getImage(index, &resourcePtr).ToSlangResult();

        resource = res ? new(resourcePtr) : null;
        return res;
    }

    public unsafe SlangResult TryPresent() => Pointer->present().ToSlangResult();

    /// <summary>
    /// Returns the index of next back buffer image that will be presented in the next
    /// present call. If the swapchain is invalid/out-of-date, this method returns -1.
    /// </summary>
    /// <returns></returns>
    public unsafe int AcquireNextImage() => Pointer->acquireNextImage();

    public unsafe SlangResult TryResize(int width, int height) => Pointer->resize(width, height).ToSlangResult();

    public unsafe bool IsOccluded() => Pointer->isOccluded();

    public unsafe SlangResult TrySetFullScreenMode(bool mode) => Pointer->setFullScreenMode((byte)(mode ? 1 : 0)).ToSlangResult();
}