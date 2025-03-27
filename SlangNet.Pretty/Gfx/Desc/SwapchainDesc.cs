using SlangNet.Internal;

namespace SlangNet.Gfx.Desc;

public readonly record struct SwapchainDesc(Format Format,
                                            int Width, int Height,
                                            int ImageCount,
                                            CommandQueue Queue,
                                            bool EnableVSync) : IMarshalsToNative<ISwapchain.SwapchainDesc>, IMarshalsFromNative<SwapchainDesc, ISwapchain.SwapchainDesc>
{
    public int GetNativeAllocSize() => SysUnsafe.SizeOf<ISwapchain>();

    public unsafe void AsNative(ref MarshallingAllocBuffer buffer, out ISwapchain.SwapchainDesc native)
    {
        native = new()
        {
            format = Format,
            width = Width,
            height = Height,
            imageCount = ImageCount,
            queue = Queue.Pointer,
            enableVSync = EnableVSync ? (byte)1 : (byte)0,
        };
    }
    public static unsafe void CreateFromNative(ISwapchain.SwapchainDesc native, out SwapchainDesc managed)
    {
        managed = new(native.format, native.width, native.height, native.imageCount, new(native.queue), native.enableVSync != 0);
    }
}