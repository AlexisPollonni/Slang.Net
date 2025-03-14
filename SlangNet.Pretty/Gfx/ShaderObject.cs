using System;
using SlangNet.Internal;

namespace SlangNet.Gfx;

[GenerateThrowingMethods]
public partial class ShaderObject : COMObject<IShaderObject>
{
    internal unsafe ShaderObject(IShaderObject* pointer) : base(pointer)
    { }
    
    public unsafe TypeLayoutReflection GetElementTypeLayout()
    {
        var typeLayout = Pointer->getElementTypeLayout();
        if (typeLayout == null)
            throw new InvalidOperationException("Failed to get element type layout");
        
        return new TypeLayoutReflection(typeLayout);
    }
    
    public unsafe ShaderObjectContainerType GetContainerType()
    {
        return (ShaderObjectContainerType)Pointer->getContainerType();
    }
    
    public unsafe int GetEntryPointCount()
    {
        return Pointer->getEntryPointCount();
    }
    
    public unsafe SlangResult TryGetEntryPoint(int index, out ShaderObject? entryPoint)
    {
        IShaderObject* nativeEntryPoint = null;
        var result = Pointer->getEntryPoint(index, &nativeEntryPoint).ToSlangResult();
        entryPoint = result ? new ShaderObject(nativeEntryPoint) : null;
        return result;
    }
    
    // public unsafe SlangResult TrySetData<T>(in ShaderOffset offset, in T data) where T : unmanaged
    // {
    //     fixed (T* pData = &data)
    //     fixed (ShaderOffset* pOffset = &offset)
    //     {
    //         return Pointer->setData(pOffset, pData, (nuint)sizeof(T)).ToSlangResult();
    //     }
    // }
    
    public unsafe SlangResult TryGetObject(in ShaderOffset offset, out ShaderObject? shaderObject)
    {
        fixed (ShaderOffset* pOffset = &offset)
        {
            IShaderObject* nativeObject = null;
            var result = Pointer->getObject(pOffset, &nativeObject).ToSlangResult();
            shaderObject = result ? new ShaderObject(nativeObject) : null;
            return result;
        }
    }
    
    public unsafe SlangResult TrySetObject(in ShaderOffset offset, ShaderObject? shaderObject)
    {
        fixed (ShaderOffset* pOffset = &offset)
        {
            return Pointer->setObject(pOffset, shaderObject.AsNullablePtr()).ToSlangResult();
        }
    }
    
    // ResourceView and SamplerState methods are commented out for now
    // They will be implemented when those classes are created
    /*
    public unsafe SlangResult TrySetResource(in ShaderOffset offset, ResourceView? resourceView)
    {
        fixed (ShaderOffset* pOffset = &offset)
        {
            return Pointer->setResource(pOffset, resourceView?.Pointer ?? null).ToSlangResult();
        }
    }
    
    public unsafe SlangResult TrySetSampler(in ShaderOffset offset, SamplerState? sampler)
    {
        fixed (ShaderOffset* pOffset = &offset)
        {
            return Pointer->setSampler(pOffset, sampler?.Pointer ?? null).ToSlangResult();
        }
    }
    
    public unsafe SlangResult TrySetCombinedTextureSampler(in ShaderOffset offset, ResourceView? textureView, SamplerState? sampler)
    {
        fixed (ShaderOffset* pOffset = &offset)
        {
            return Pointer->setCombinedTextureSampler(pOffset, textureView?.Pointer ?? null, sampler?.Pointer ?? null).ToSlangResult();
        }
    }
    */
    
    public unsafe SlangResult TryGetCurrentVersion(TransientResourceHeap transientHeap, out ShaderObject? currentVersion)
    {
        IShaderObject* nativeObject = null;
        var result = Pointer->getCurrentVersion(transientHeap.Pointer, &nativeObject).ToSlangResult();
        currentVersion = result ? new ShaderObject(nativeObject) : null;
        return result;
    }
    
    public unsafe IntPtr GetRawData()
    {
        return (IntPtr)Pointer->getRawData();
    }
    
    public unsafe nuint GetSize()
    {
        return Pointer->getSize();
    }
    
    public unsafe SlangResult TrySetConstantBufferOverride(BufferResource? constantBuffer)
    {
        return Pointer->setConstantBufferOverride(constantBuffer.AsNullablePtr()).ToSlangResult();
    }
}