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
        return Pointer->getContainerType();
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
    
    public unsafe SlangResult TrySetData(in Tools.ShaderOffset offset, ReadOnlySpan<byte> data)
    {
        return offset.MarshalToNative<Tools.ShaderOffset, Unsafe.ShaderOffset, ReadOnlySpan<byte>, SlangResult>(data, 
        (native, dataSpan) =>
        {
            fixed (byte* pData = dataSpan)
            {
                return Pointer->setData(native, pData, (nuint)dataSpan.Length).ToSlangResult();
            }
        });
    }
    
    public unsafe SlangResult TryGetObject(in Tools.ShaderOffset offset, out ShaderObject? shaderObject)
    {
        return offset.MarshalToNative<Tools.ShaderOffset, Unsafe.ShaderOffset, ShaderObject?>(out shaderObject, native => 
        {
            IShaderObject* nativeObject = null;
            var result = Pointer->getObject(native, &nativeObject).ToSlangResult();

            return (result, result ? new ShaderObject(nativeObject) : null);
        });
    }
    
    public unsafe SlangResult TrySetObject(in Tools.ShaderOffset offset, ShaderObject? shaderObject)
    {
        return offset.MarshalToNative<Tools.ShaderOffset, Unsafe.ShaderOffset, ShaderObject?, SlangResult>(shaderObject,
        (native, shaderObject) =>
        {
            var result = Pointer->setObject(native, shaderObject.AsNullablePtr()).ToSlangResult();
            return result;
        });
    }

    public unsafe SlangResult TrySetResource(in Tools.ShaderOffset offset, ResourceView? resourceView)
    {
        return offset.MarshalToNative<Tools.ShaderOffset, Unsafe.ShaderOffset, ResourceView?, SlangResult>(resourceView,
        (native, resourceView) =>
        {
            return Pointer->setResource(native, resourceView.AsNullablePtr()).ToSlangResult();
        });
    }
    
    //TODO: Implement when SamplerState is implemented
    // public unsafe SlangResult TrySetSampler(in ShaderOffset offset, SamplerState? sampler)
    // {
    //     fixed (ShaderOffset* pOffset = &offset)
    //     {
    //         return Pointer->setSampler(pOffset, sampler?.Pointer ?? null).ToSlangResult();
    //     }
    // }
    
    //TODO: Implement when SamplerState is implemented
    // public unsafe SlangResult TrySetCombinedTextureSampler(in ShaderOffset offset, ResourceView? textureView, SamplerState? sampler)
    // {
    //     fixed (ShaderOffset* pOffset = &offset)
    //     {
    //         return Pointer->setCombinedTextureSampler(pOffset, textureView?.Pointer ?? null, sampler?.Pointer ?? null).ToSlangResult();
    //     }
    // }
    
    /// <summary>
    /// Manually overrides the specialization argument for the sub-object binding at `offset`.
    /// Specialization arguments are passed to the shader compiler to specialize the type
    /// of interface-typed shader parameters.
    /// </summary>
    public unsafe SlangResult TrySetSpecializationArgs(in Tools.ShaderOffset offset, ReadOnlySpan<SpecializationArg> args)
    {
        return offset.MarshalToNative<Tools.ShaderOffset, Unsafe.ShaderOffset, ReadOnlySpan<SpecializationArg>, SlangResult>(args,
        (native, argsSpan) =>
        {
            fixed (SpecializationArg* pArgs = argsSpan)
            {
                return Pointer->setSpecializationArgs(native, pArgs, argsSpan.Length).ToSlangResult();
            }
        });
    }

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

    /// <summary>
    /// Use the provided constant buffer instead of the internally created one.
    /// </summary>
    public unsafe SlangResult TrySetConstantBufferOverride(BufferResource? constantBuffer)
    {
        return Pointer->setConstantBufferOverride(constantBuffer.AsNullablePtr()).ToSlangResult();
    }   
}