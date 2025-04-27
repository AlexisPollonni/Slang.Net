using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Gfx.Descriptions;
using SlangNet.ComWrappers.Interfaces;
using SlangNet.ComWrappers.Reflection;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers.Gfx.Interfaces;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Custom,
                       StringMarshallingCustomType = typeof(UnownedUTF8StringMarshaller))]
[Guid("715bdf26-5135-11eb-AE93-0242AC130002")]
[GenerateThrowingMethods]
public partial interface IDevice : IUnknown
{
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetNativeDeviceHandles(out Unmanaged.InteropHandle handles);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    [return: MarshalAs(UnmanagedType.I1)]
    bool HasFeature(string feature);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetFeatures([MarshalUsing(CountElementName = "bufferSize")] Span<string> outFeatures,
                            nuint bufferSize,
                            out int outFeatureCount);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetFormatSupportedResourceStates(Unmanaged.Format format, out ResourceStateSet states);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetSlangSession(out ISession slangSession);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CreateTransientResourceHeap(TransientResourceHeapDescription desc, out ITransientResourceHeap heap);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CreateTextureResource(TextureResourceDescription desc,
                                      SubresourceData initData,
                                      out ITextureResource resource);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CreateTextureFromNativeHandle(Unmanaged.InteropHandle handle,
                                              TextureResourceDescription srcDesc,
                                              out ITextureResource resource);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CreateTextureFromSharedHandle(Unmanaged.InteropHandle handle,
                                              TextureResourceDescription srcDesc,
                                              nuint size,
                                              out ITextureResource resource);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CreateBufferResource(BufferResourceDescription desc, in byte initData, out IBufferResource resource);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CreateBufferFromNativeHandle(Unmanaged.InteropHandle handle,
                                             BufferResourceDescription srcDesc,
                                             out IBufferResource resource);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CreateBufferFromSharedHandle(Unmanaged.InteropHandle handle,
                                             BufferResourceDescription srcDesc,
                                             out IBufferResource resource);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CreateSamplerState(SamplerStateDescription desc, out ISamplerState sampler);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CreateTextureView(ITextureResource texture, ResourceViewDescription desc, out IResourceView view);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CreateBufferView(IBufferResource buffer,
                                 IBufferResource? counterBuffer,
                                 ResourceViewDescription desc,
                                 out IResourceView view);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CreateFramebufferLayout(FramebufferLayoutDescription desc, out IFramebufferLayout framebuffer);
    
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CreateFramebuffer(FramebufferDescription desc, out IFramebuffer framebuffer);
    
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CreateRenderPassLayout(RenderPassLayoutDescription desc, out IRenderPassLayout renderPassLayout);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CreateSwapchain(SwapchainDescription desc, Unmanaged.WindowHandle window, out ISwapchain swapchain);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CreateInputLayout(InputLayoutDescription desc, out IInputLayout inputLayout);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CreateCommandQueue(CommandQueueDescription desc, out ICommandQueue queue);
    
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CreateShaderObject(TypeReflection type, Unmanaged.ShaderObjectContainerType container, out IShaderObject shaderObject);
    
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CreateMutableShaderObject(TypeReflection type, Unmanaged.ShaderObjectContainerType container, out IShaderObject shaderObject);
    
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CreateShaderObjectFromTypeLayout(TypeLayoutReflection typeLayout, out IShaderObject shaderObject);
    
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CreateMutableShaderObjectFromTypeLayout(TypeLayoutReflection typeLayout, out IShaderObject shaderObject);
    
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CreateMutableRootShaderObject(IShaderProgram program, out IShaderObject shaderObject);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CreateShaderTable(ShaderTableDescription desc, out IShaderTable shaderTable);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CreateProgram(ShaderProgramDescription desc, out IShaderProgram program, out IBlob? diagnostics);
    
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CreateProgram2(ShaderProgramCreateDescription2 desc, out IShaderProgram program, out IBlob? diagnostics);
    
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CreateGraphicsPipelineState(GraphicsPipelineStateDescription desc, out IPipelineState pipelineState);
    
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CreateComputePipelineState(ComputePipelineStateDescription desc, out IPipelineState pipelineState);
    
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CreateRayTracingPipelineState(RayTracingPipelineStateDescription desc, out IPipelineState pipelineState);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult ReadTextureResource(ITextureResource resource,
                                    Unmanaged.ResourceState state,
                                    out IBlob blob,
                                    out nuint rowPitch,
                                    out nuint pixelSize);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult ReadBufferResource(IBufferResource buffer, nuint offset, nuint size, out IBlob blob);
    
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    DeviceInfo GetDeviceInfo();
    
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CreateQueryPool(QueryPoolDescription desc, out IQueryPool queryPool);
    
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetAccelerationStructurePrebuildInfo(
        in Unmanaged.IAccelerationStructure.BuildInputs buildInputs,
                                                            out Unmanaged.IAccelerationStructure.PrebuildInfo prebuildInfo); //TODO

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CreateAccelerationStructure(in Unmanaged.IAccelerationStructure.CreateDesc desc,
                                                   out IAccelerationStructure view); //TODO
    
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CreateFence(FenceDescription desc, out IFence fence);



    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult WaitForFences(int fenceCount,
                              [MarshalUsing(CountElementName = "fenceCount")] Span<IFence> fences,
                              [MarshalUsing(CountElementName = "fenceCount")] Span<ulong> value,
                              [MarshalAs(UnmanagedType.I1)] bool waitAll,
                              ulong timeout);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetTextureAllocationInfo(TextureResourceDescription desc, out nuint size, out nuint alignment);
    
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetTextureRowAlignment(out nuint alignment);
    
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetCooperativeVectorProperties(
        [MarshalUsing(CountElementName = "propertyCount")] 
        Span<Unmanaged.CooperativeVectorProperties> properties, ref uint propertyCount);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CreateShaderObject2(ISession slangSession,
                                    TypeReflection type,
                                    Unmanaged.ShaderObjectContainerType container,
                                    out IShaderObject shaderObject);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CreateMutableShaderObject2(ISession slangSession,
                                           TypeReflection type,
                                           Unmanaged.ShaderObjectContainerType container,
                                           out IShaderObject shaderObject);
}

public readonly record struct RayTracingPipelineStateDescription; //TODO
public readonly record struct ShaderTableDescription; //TODO