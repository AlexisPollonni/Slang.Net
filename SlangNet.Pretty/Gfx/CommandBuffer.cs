using System;
using SlangNet.Internal;

namespace SlangNet.Gfx;

[GenerateThrowingMethods]
public partial class CommandBuffer : COMObject<ICommandBuffer>
{
    internal unsafe CommandBuffer(ICommandBuffer* pointer) : base(pointer)
    { }
    
    public unsafe void Close()
    {
        Pointer->close();
    }
    
    
    // The following methods will be implemented when the corresponding encoder classes are created
    
    /*
    public unsafe void EncodeRenderCommands(RenderPassLayout renderPass, Framebuffer framebuffer, out RenderCommandEncoder encoder)
    {
        IRenderCommandEncoder* nativeEncoder = null;
        Pointer->encodeRenderCommands(renderPass.Pointer, framebuffer.Pointer, &nativeEncoder);
        encoder = new RenderCommandEncoder(nativeEncoder);
    }
    
    public unsafe void EncodeComputeCommands(out ComputeCommandEncoder encoder)
    {
        IComputeCommandEncoder* nativeEncoder = null;
        Pointer->encodeComputeCommands(&nativeEncoder);
        encoder = new ComputeCommandEncoder(nativeEncoder);
    }
    
    public unsafe void EncodeResourceCommands(out ResourceCommandEncoder encoder)
    {
        IResourceCommandEncoder* nativeEncoder = null;
        Pointer->encodeResourceCommands(&nativeEncoder);
        encoder = new ResourceCommandEncoder(nativeEncoder);
    }
    
    public unsafe void EncodeRayTracingCommands(out RayTracingCommandEncoder encoder)
    {
        IRayTracingCommandEncoder* nativeEncoder = null;
        Pointer->encodeRayTracingCommands(&nativeEncoder);
        encoder = new RayTracingCommandEncoder(nativeEncoder);
    }
    */
} 