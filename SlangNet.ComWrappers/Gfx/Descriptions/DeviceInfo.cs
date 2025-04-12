using System.Numerics;
using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers.Gfx.Descriptions;

[NativeMarshalling(typeof(MarshalableMarshaller.UnmanagedToManaged<DeviceInfo, Unmanaged.DeviceInfo>))]
public readonly record struct DeviceInfo(
    Unmanaged.DeviceType DeviceType,
    DeviceLimits Limits,
    Unmanaged.BindingStyle BindingStyle,
    Unmanaged.ProjectionStyle ProjectionStyle,
    Matrix4x4 IdentityProjectionMatrix,
    string ApiName,
    string AdapterName,
    ulong TimestampFrequency) : IMarshalsFromNative<DeviceInfo, Unmanaged.DeviceInfo>
{

    public static unsafe DeviceInfo CreateFromNative(Unmanaged.DeviceInfo unmanaged)
    {
        var idSpan = unmanaged.identityProjectionMatrix.AsFloatSpan();
        var limits = DeviceLimits.CreateFromNative(unmanaged.limits);
        
        return new()
        {
            DeviceType = unmanaged.deviceType,
            Limits = limits,
            BindingStyle = unmanaged.bindingStyle,
            ProjectionStyle = unmanaged.projectionStyle,
            IdentityProjectionMatrix = new(idSpan[0],
                                           idSpan[1],
                                           idSpan[2],
                                           idSpan[3],
                                           idSpan[4],
                                           idSpan[5],
                                           idSpan[6],
                                           idSpan[7],
                                           idSpan[8],
                                           idSpan[9],
                                           idSpan[10],
                                           idSpan[11],
                                           idSpan[12],
                                           idSpan[13],
                                           idSpan[14],
                                           idSpan[15]),
            ApiName = InteropUtils.PtrToStringUtf8(unmanaged.apiName) ?? "Api name unavailable",
            AdapterName = InteropUtils.PtrToStringUtf8(unmanaged.adapterName) ?? "Adapter name unavailable",
            TimestampFrequency = unmanaged.timestampFrequency
        };
    }
}

public readonly record struct DeviceLimits(
    uint MaxTextureDimension1D,
    uint MaxTextureDimension2D,
    uint MaxTextureDimension3D,
    uint MaxTextureDimensionCube,
    uint MaxTextureArrayLayers,
    uint MaxVertexInputElements,
    uint MaxVertexInputElementOffset,
    uint MaxVertexStreams,
    uint MaxVertexStreamStride,
    uint MaxComputeThreadsPerGroup,
    (uint X, uint Y, uint Z) MaxComputeThreadGroupSize,
    (uint X, uint Y, uint Z) MaxComputeDispatchThreadGroups,
    uint MaxViewports,
    (uint Width, uint Height) MaxViewportDimensions,
    (uint X, uint Y, uint Z) MaxFramebufferDimensions,
    uint MaxShaderVisibleSamplers) : IMarshalsFromNative<DeviceLimits, Unmanaged.DeviceLimits>
{
    public static DeviceLimits CreateFromNative(Unmanaged.DeviceLimits unmanaged)
    {
        var maxComputeThreadGroupSize = unmanaged.maxComputeThreadGroupSize.AsUintSpan();
        var maxComputeDispatchThreadGroups = unmanaged.maxComputeDispatchThreadGroups.AsUintSpan();
        var maxViewportDimensions = unmanaged.maxViewportDimensions.AsUintSpan();
        var maxFramebufferDimensions = unmanaged.maxFramebufferDimensions.AsUintSpan();

        return new()
        {
            MaxTextureDimension1D = unmanaged.maxTextureDimension1D,
            MaxTextureDimension2D = unmanaged.maxTextureDimension2D,
            MaxTextureDimension3D = unmanaged.maxTextureDimension3D,
            MaxTextureDimensionCube = unmanaged.maxTextureDimensionCube,
            MaxTextureArrayLayers = unmanaged.maxTextureArrayLayers,
            MaxVertexInputElements = unmanaged.maxVertexInputElements,
            MaxVertexInputElementOffset = unmanaged.maxVertexInputElementOffset,
            MaxVertexStreams = unmanaged.maxVertexStreams,
            MaxVertexStreamStride = unmanaged.maxVertexStreamStride,
            MaxComputeThreadsPerGroup = unmanaged.maxComputeThreadsPerGroup,
            MaxComputeThreadGroupSize = (maxComputeThreadGroupSize[0],
                                         maxComputeThreadGroupSize[1],
                                         maxComputeThreadGroupSize[2]),
            MaxComputeDispatchThreadGroups = (maxComputeDispatchThreadGroups[0],
                                              maxComputeDispatchThreadGroups[1],
                                              maxComputeDispatchThreadGroups[2]),
            MaxViewports = unmanaged.maxViewports,
            MaxViewportDimensions = (maxViewportDimensions[0],
                                     maxViewportDimensions[1]),
            MaxFramebufferDimensions = (maxFramebufferDimensions[0],
                                        maxFramebufferDimensions[1],
                                        maxFramebufferDimensions[2]),
            MaxShaderVisibleSamplers = unmanaged.maxShaderVisibleSamplers
        };
    }
}