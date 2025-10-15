using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.Bindings;
using ShaderSlang.Net.ComWrappers.Tools;
using ShaderSlang.Net.ComWrappers.Tools.Internal;

namespace ShaderSlang.Net.ComWrappers.Interfaces;

[GeneratedComInterface(
    StringMarshalling = StringMarshalling.Custom,
    StringMarshallingCustomType = typeof(UnownedUTF8StringMarshaller)
)]
[Guid("EC457F0E-9ADD-4E6B-851C-D7FA716D15FD")]
[GenerateThrowingMethods]
public partial interface IWriter : IUnknown
{
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    unsafe char* BeginAppendBuffer(ulong maxNumChars);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult EndAppendBuffer(ref byte buffer, ulong numChars);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult Write(in byte chars, ulong numChars);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void Flush();

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    [return: MarshalAs(UnmanagedType.I1)]
    bool IsConsole();

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult SetMode(Unmanaged.WriterMode mode);
}
