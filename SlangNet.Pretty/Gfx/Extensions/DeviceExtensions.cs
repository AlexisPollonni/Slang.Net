using System;
using CommunityToolkit.HighPerformance;
using SlangNet.Bindings.Generated;
using SlangNet.ComWrappers.Gfx.Descriptions;
using SlangNet.Gfx.Tools;
using IBufferResource = SlangNet.ComWrappers.Gfx.Interfaces.IBufferResource;
using IDevice = SlangNet.ComWrappers.Gfx.Interfaces.IDevice;

namespace SlangNet.Gfx.Extensions;

public static class DeviceExtensions
{
    public static SlangResult CreateBufferResource(this IDevice device,
                                                   out IBufferResource resource,
                                                   in ResourceDescriptionBase baseDesc,
                                                   ReadOnlySpan<byte> initData,
                                                   int elementSize,
                                                   Format format = Format.Unknown)
    {
        return device.CreateBufferResource(new(baseDesc, (nuint)initData.Length, (nuint)elementSize, format), in initData.DangerousGetReference(), out resource);
    }

    public static unsafe SlangResult CreateBufferResource<T>(this IDevice device,
                                                      out IBufferResource resource,
                                                      in ResourceDescriptionBase baseDesc,
                                                      ReadOnlySpan<T> initData,
                                                      Format format = Format.Unknown) where T : unmanaged
    {
        return device.CreateBufferResource(out resource, in baseDesc, initData.AsBytes(), sizeof(T), format);
    }

    public static SlangResult CreateBufferResource<T>(this IDevice device,
                                                      out IBufferResource resource,
                                                      ReadOnlySpan<T> initData,
                                                      Format format = Format.Unknown) where T : unmanaged
    {
        return device.CreateBufferResource(out resource, new(), initData, format);
    }



    
    public static unsafe SlangResult ReadBufferResource<T>(this IDevice device,
                                                    IBufferResource resource,
                                                    Range range,
                                                    out BlobMemory<T> data) where T : unmanaged
    {
        var sizeCount = resource.GetDesc().SizeInBytes / (ulong)sizeof(T);
        var (offset, length) = range.GetOffsetAndLength((int)sizeCount);;

        var res = device.ReadBufferResource(resource, (nuint)(offset * sizeof(T)), (nuint)(length * sizeof(T)), out var dataBlob);

        data = new(dataBlob);
        return res;
    }
}