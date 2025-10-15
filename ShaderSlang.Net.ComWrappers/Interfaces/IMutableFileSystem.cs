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
[Guid("A058675C-1D65-452A-8458-CCDED1427105")]
[GenerateThrowingMethods]
public partial interface IMutableFileSystem : IFileSystemExt
{
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult SaveFile(
        string path,
        [MarshalUsing(CountElementName = "size")] Span<byte> data,
        ulong size
    );

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult SaveFileBlob(string path, IBlob blob);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult Remove(string path);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CreateDirectory(string path);
}
