using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.Bindings;
using ShaderSlang.Net.ComWrappers.Descriptions;
using ShaderSlang.Net.ComWrappers.Gfx.Descriptions;
using ShaderSlang.Net.ComWrappers.Reflection;
using ShaderSlang.Net.ComWrappers.Tools;
using ShaderSlang.Net.ComWrappers.Tools.Internal;

namespace ShaderSlang.Net.ComWrappers.Gfx.Interfaces;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Custom,
                       StringMarshallingCustomType = typeof(UnownedUTF8StringMarshaller))]
[Guid("c1fa997e-5CA2-45AE-9BCB-C4359E850585")]
[GenerateThrowingMethods]
public partial interface IShaderObject
{
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<TypeLayoutReflection>))]
    TypeLayoutReflection? GetElementTypeLayout();

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    Unmanaged.ShaderObjectContainerType GetContainerType();

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    int GetEntryPointCount();

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetEntryPoint(int index, out IShaderObject entryPoint);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult SetData(ShaderOffset offset, 
                        [MarshalUsing(CountElementName = "size")]
                        Span<byte> data, nuint size);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetObject(ShaderOffset offset, out IShaderObject obj);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult SetObject(ShaderOffset offset, IShaderObject obj);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult SetResource(ShaderOffset offset, IResourceView resourceView);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult SetSampler(ShaderOffset offset, ISamplerState sampler);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult SetCombinedTextureSampler(ShaderOffset offset, IResourceView textureView, ISamplerState sampler);
    
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult SetSpecializationArgs(ShaderOffset offset, 
                                      [MarshalUsing(CountElementName = "count")]
                                      Span<SpecializationArgument> args, int count);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetCurrentVersion(ITransientResourceHeap transientHeap, out IShaderObject obj);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    unsafe void* GetRawData();

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    nuint GetSize();

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult SetConstantBufferOverride(IBufferResource constantResource);
}