using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.Bindings;
using ShaderSlang.Net.ComWrappers.Gfx.Interfaces;
using ShaderSlang.Net.ComWrappers.Tools;

namespace ShaderSlang.Net.ComWrappers.Gfx.Descriptions;

[NativeMarshalling(typeof(MarshalableMarshaller.Bidirectional<SwapchainDescription, Unmanaged.ISwapchain.SwapchainDesc>))]
public readonly record struct SwapchainDescription(
    Unmanaged.Format Format,
    int Width,
    int Height,
    int ImageCount,
    ICommandQueue Queue,
    bool EnableVSync) : IMarshalsToNative<Unmanaged.ISwapchain.SwapchainDesc>,
                        IMarshalsFromNative<SwapchainDescription, Unmanaged.ISwapchain.SwapchainDesc>,
                        IFreeAfterMarshal<Unmanaged.ISwapchain.SwapchainDesc>
{
    unsafe Unmanaged.ISwapchain.SwapchainDesc IMarshalsToNative<Unmanaged.ISwapchain.SwapchainDesc>.AsNative(
        ref GrowingStackBuffer buffer) =>
        new()
        {
            format = Format,
            width = Width,
            height = Height,
            imageCount = ImageCount,
            queue = Queue.InterfaceToPtr<ICommandQueue, Unmanaged.ICommandQueue>(),
            enableVSync = EnableVSync ? (byte)1 : (byte)0,
        };

    public static unsafe SwapchainDescription CreateFromNative(Unmanaged.ISwapchain.SwapchainDesc unmanaged) =>
        new(unmanaged.format,
            unmanaged.width,
            unmanaged.height,
            unmanaged.imageCount,
            ComInterfaceMarshaller<ICommandQueue>.ConvertToManaged(unmanaged.queue) ?? throw new SlangException("Returned swapchain command queue was null, this should not happen!"),
            unmanaged.enableVSync != 0);

    public unsafe void Free(Unmanaged.ISwapchain.SwapchainDesc* unmanaged)
    {
        ComInterfaceMarshaller<ICommandQueue>.Free(unmanaged->queue);
    }
}