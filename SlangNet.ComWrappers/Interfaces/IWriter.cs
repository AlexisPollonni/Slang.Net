using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace SlangNet.ComWrappers.Interfaces;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf8)]
[Guid("EC457F0E-9ADD-4E6B-851C-D7FA716D15FD")]
public partial interface IWriter : IUnknown
{
    [PreserveSig]
    unsafe char* BeginAppendBuffer(ulong maxNumChars);
    
    [PreserveSig]
    SlangResult EndAppendBuffer(ref byte buffer, ulong numChars);

    [PreserveSig]
    SlangResult Write(in byte chars, ulong numChars);
    
    [PreserveSig]
    void Flush();

    [PreserveSig]
    [return:MarshalAs(UnmanagedType.I1)]
    bool IsConsole();

    [PreserveSig]
    SlangResult SetMode(Unmanaged.WriterMode mode);
}