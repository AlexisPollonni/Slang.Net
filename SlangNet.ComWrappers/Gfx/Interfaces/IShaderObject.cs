using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Descriptions;
using SlangNet.ComWrappers.Reflection;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers.Gfx.Interfaces;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Custom,
                       StringMarshallingCustomType = typeof(UnownedUTF8StringMarshaller))]
[Guid("c1fa997e-5CA2-45AE-9BCB-C4359E850585")]
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
    SlangResult SetData(in Unmanaged.ShaderOffset offset, 
                        [MarshalUsing(CountElementName = "size")]
                        Span<byte> data, nuint size);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetObject(in Unmanaged.ShaderOffset offset, out IShaderObject obj);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult SetObject(in Unmanaged.ShaderOffset offset, IShaderObject obj);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult SetResource(in Unmanaged.ShaderOffset offset, IResourceView resourceView);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult SetSampler(in Unmanaged.ShaderOffset offset, ISamplerState sampler);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult SetSpecializationArgs(in Unmanaged.ShaderOffset offset, 
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