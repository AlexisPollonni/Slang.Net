using System.Numerics;
using System.Runtime.InteropServices.Marshalling;
using CommunityToolkit.HighPerformance;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers.Gfx.Descriptions;

[NativeMarshalling(typeof(MarshalableMarshaller.Bidirectional<DeviceInfo, Unmanaged.DeviceInfo>))]
public readonly record struct DeviceInfo(
    Unmanaged.DeviceType DeviceType,
    DeviceLimits Limits,
    Unmanaged.BindingStyle BindingStyle,
    Unmanaged.ProjectionStyle ProjectionStyle,
    Matrix4x4 IdentityProjectionMatrix,
    string ApiName,
    string AdapterName,
    ulong TimestampFrequency) : IMarshalsToNative<Unmanaged.DeviceInfo>,
                                IMarshalsFromNative<DeviceInfo, Unmanaged.DeviceInfo>
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

    unsafe Unmanaged.DeviceInfo IMarshalsToNative<Unmanaged.DeviceInfo>.AsNative(ref GrowingStackBuffer buffer)
    {
        var res = new Unmanaged.DeviceInfo
        {
            adapterName = buffer.GetStringPtr(AdapterName),
            apiName = buffer.GetStringPtr(ApiName),
            bindingStyle = BindingStyle,
            deviceType = DeviceType,
            identityProjectionMatrix = new(),
            limits = ((IMarshalsToNative<Unmanaged.DeviceLimits>)Limits).AsNative(ref buffer),
            projectionStyle = ProjectionStyle,
            timestampFrequency = TimestampFrequency
        };
        var mat = IdentityProjectionMatrix;
        mat.AsReadOnlySpan().AsBytes().CopyTo(res.identityProjectionMatrix.AsSpan().AsBytes());
        
        return res;
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
    uint MaxShaderVisibleSamplers) : IMarshalsFromNative<DeviceLimits, Unmanaged.DeviceLimits>,
                                     IMarshalsToNative<Unmanaged.DeviceLimits>
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
            MaxComputeThreadGroupSize = (maxComputeThreadGroupSize[0], maxComputeThreadGroupSize[1],
                                         maxComputeThreadGroupSize[2]),
            MaxComputeDispatchThreadGroups = (maxComputeDispatchThreadGroups[0], maxComputeDispatchThreadGroups[1],
                                              maxComputeDispatchThreadGroups[2]),
            MaxViewports = unmanaged.maxViewports,
            MaxViewportDimensions = (maxViewportDimensions[0], maxViewportDimensions[1]),
            MaxFramebufferDimensions = (maxFramebufferDimensions[0],
                                        maxFramebufferDimensions[1], maxFramebufferDimensions[2]),
            MaxShaderVisibleSamplers = unmanaged.maxShaderVisibleSamplers
        };
    }

    Unmanaged.DeviceLimits IMarshalsToNative<Unmanaged.DeviceLimits>.AsNative(ref GrowingStackBuffer buffer)
    {
        var res = new Unmanaged.DeviceLimits()
        {
            maxTextureDimension1D = MaxTextureDimension1D,
            maxTextureDimension2D = MaxTextureDimension2D,
            maxTextureDimension3D = MaxTextureDimension3D,
            maxTextureDimensionCube = MaxTextureDimensionCube,
            maxTextureArrayLayers = MaxTextureArrayLayers,
            maxVertexInputElements = MaxVertexInputElements,
            maxVertexInputElementOffset = MaxVertexInputElementOffset,
            maxVertexStreams = MaxVertexStreams,
            maxVertexStreamStride = MaxVertexStreamStride,
            maxComputeThreadsPerGroup = MaxComputeThreadsPerGroup,
            maxComputeThreadGroupSize = new(),
            maxComputeDispatchThreadGroups = new(),
            maxViewports = MaxViewports,
            maxViewportDimensions = new(),
            maxFramebufferDimensions = new(),
            maxShaderVisibleSamplers = MaxShaderVisibleSamplers
        };
        
        var maxComputeThreadGroupSize = MaxComputeThreadGroupSize;
        var maxComputeDispatchThreadGroups = MaxComputeDispatchThreadGroups;
        var maxViewportDimensions = MaxViewportDimensions;
        var maxFramebufferDimensions = MaxFramebufferDimensions;
        
        maxComputeThreadGroupSize.AsSpan().AsBytes().CopyTo(res.maxComputeThreadGroupSize.AsSpan().AsBytes());
        maxComputeDispatchThreadGroups.AsSpan().AsBytes().CopyTo(res.maxComputeDispatchThreadGroups.AsSpan().AsBytes());
        maxViewportDimensions.AsSpan().AsBytes().CopyTo(res.maxViewportDimensions.AsSpan().AsBytes());
        maxFramebufferDimensions.AsSpan().AsBytes().CopyTo(res.maxFramebufferDimensions.AsSpan().AsBytes());
        
        return res;
    }
}