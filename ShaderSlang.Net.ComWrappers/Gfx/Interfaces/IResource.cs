using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.Bindings;
using ShaderSlang.Net.ComWrappers.Interfaces;
using ShaderSlang.Net.ComWrappers.Tools;
using ShaderSlang.Net.ComWrappers.Tools.Internal;

namespace ShaderSlang.Net.ComWrappers.Gfx.Interfaces;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Custom,
                       StringMarshallingCustomType = typeof(UnownedUTF8StringMarshaller))]
[Guid("a0e39f34-8398-4522-95C2-EBC0F984EF3F")]
[GenerateThrowingMethods]
public partial interface IResource : IUnknown
{
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    Unmanaged.IResource.ResourceType GetType();

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetNativeResourceHandle(out Unmanaged.InteropHandle? handle);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetSharedHandle(out Unmanaged.InteropHandle? handle);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult SetDebugName(string name);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    string? GetDebugName();
}