using System;
using System.Numerics;
using System.Runtime.InteropServices;
using CommunityToolkit.HighPerformance;
using SlangNet.Internal;

namespace SlangNet.Gfx.Desc;

public readonly record struct DeviceInfo(
    DeviceType DeviceType,
    DeviceLimits Limits,
    BindingStyle BindingStyle,
    ProjectionStyle ProjectionStyle,
    Matrix4x4 IdentityProjectionMatrix,
    string ApiName,
    string AdapterName,
    ulong TimestampFrequency) : IMarshalsFromNative<DeviceInfo, Unsafe.DeviceInfo>
{
    public static unsafe void CreateFromNative(Unsafe.DeviceInfo native, out DeviceInfo managed)
    {
        var idSpan = MemoryMarshal.CreateReadOnlySpan(in native.identityProjectionMatrix, 1)
                                  .Cast<Unsafe.DeviceInfo._identityProjectionMatrix_e__FixedBuffer, float>();
        DeviceLimits.CreateFromNative(native.limits, out var limits);
        managed = new()
        {
            DeviceType = native.deviceType,
            Limits = limits,
            BindingStyle = native.bindingStyle,
            ProjectionStyle = native.projectionStyle,
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
            ApiName = InteropUtils.PtrToStringUTF8(native.apiName) ?? "Api name unavailable",
            AdapterName = InteropUtils.PtrToStringUTF8(native.adapterName) ?? "Adapter name unavailable",
            TimestampFrequency = native.timestampFrequency
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
    uint MaxShaderVisibleSamplers) : IMarshalsFromNative<DeviceLimits, Unsafe.DeviceLimits>
{
    public static void CreateFromNative(Unsafe.DeviceLimits native, out DeviceLimits managed)
    {
        var maxComputeThreadGroupSize = native.maxComputeThreadGroupSize.AsUintSpan();
        var maxComputeDispatchThreadGroups = native.maxComputeDispatchThreadGroups.AsUintSpan();
        var maxViewportDimensions = native.maxViewportDimensions.AsUintSpan();
        var maxFramebufferDimensions = native.maxFramebufferDimensions.AsUintSpan();

        managed = new()
        {
            MaxTextureDimension1D = native.maxTextureDimension1D,
            MaxTextureDimension2D = native.maxTextureDimension2D,
            MaxTextureDimension3D = native.maxTextureDimension3D,
            MaxTextureDimensionCube = native.maxTextureDimensionCube,
            MaxTextureArrayLayers = native.maxTextureArrayLayers,
            MaxVertexInputElements = native.maxVertexInputElements,
            MaxVertexInputElementOffset = native.maxVertexInputElementOffset,
            MaxVertexStreams = native.maxVertexStreams,
            MaxVertexStreamStride = native.maxVertexStreamStride,
            MaxComputeThreadsPerGroup = native.maxComputeThreadsPerGroup,
            MaxComputeThreadGroupSize = (maxComputeThreadGroupSize[0],
                                        maxComputeThreadGroupSize[1],
                                        maxComputeThreadGroupSize[2]),
            MaxComputeDispatchThreadGroups = (maxComputeDispatchThreadGroups[0],
                                             maxComputeDispatchThreadGroups[1],
                                             maxComputeDispatchThreadGroups[2]),
            MaxViewports = native.maxViewports,
            MaxViewportDimensions = (maxViewportDimensions[0],
                                    maxViewportDimensions[1]),
            MaxFramebufferDimensions = (maxFramebufferDimensions[0],
                                        maxFramebufferDimensions[1],
                                        maxFramebufferDimensions[2]),
            MaxShaderVisibleSamplers = native.maxShaderVisibleSamplers
        };
    }
}