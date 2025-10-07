using CommunityToolkit.HighPerformance;
using SlangNet.Bindings.Generated;
using SlangNet.ComWrappers.Gfx.Descriptions;
using SlangNet.Gfx.Tools;
using IBufferResource = SlangNet.ComWrappers.Gfx.Interfaces.IBufferResource;
using IDevice = SlangNet.ComWrappers.Gfx.Interfaces.IDevice;

namespace SlangNet.Gfx.Extensions;

public static class DeviceExtensions
{
    extension(IDevice device)
    {
        public unsafe SlangResult CreateBufferResource<T>(out IBufferResource resource,
                                                          in ResourceDescriptionBase baseDesc,
                                                          ReadOnlySpan<T> initData,
                                                          Format format = Format.Unknown) where T : unmanaged
        {
            return device.CreateBufferResource(out resource, in baseDesc, initData.AsBytes(), sizeof(T), format);
        }

        public SlangResult CreateBufferResource<T>(out IBufferResource resource,
                                                   ReadOnlySpan<T> initData,
                                                   Format format = Format.Unknown) where T : unmanaged
        {
            return device.CreateBufferResource(out resource, new(), initData, format);
        }

        public unsafe SlangResult ReadBufferResource<T>(IBufferResource resource,
                                                        Range range,
                                                        out BlobMemory<T> data) where T : unmanaged
        {
            var sizeCount = resource.GetDesc().SizeInBytes / (ulong)sizeof(T);
            var (offset, length) = range.GetOffsetAndLength((int)sizeCount);;

            var res = device.ReadBufferResource(resource, (nuint)(offset * sizeof(T)), (nuint)(length * sizeof(T)), out var dataBlob);

            data = new(dataBlob);
            return res;
        }

        public SlangResult CreateBufferResource(out IBufferResource resource,
                                                in ResourceDescriptionBase baseDesc,
                                                ReadOnlySpan<byte> initData,
                                                int elementSize,
                                                Format format = Format.Unknown)
        {
            return device.CreateBufferResource(new(baseDesc, (nuint)initData.Length, (nuint)elementSize, format), in initData.DangerousGetReference(), out resource);
        }
    }
}