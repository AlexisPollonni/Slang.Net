using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace SlangNet.ComWrappers.Interfaces;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf8)]
[Guid("A058675C-1D65-452A-8458-CCDED1427105")]
public partial interface IMutableFileSystem : IFileSystemExt
{
    [PreserveSig]
    SlangResult SaveFile(string path, [MarshalUsing(CountElementName = "size")]Span<byte> data, ulong size);

    [PreserveSig]
    SlangResult SaveFileBlob(string path, IBlob blob);

    [PreserveSig]
    SlangResult Remove(string path);
    
    [PreserveSig]
    SlangResult CreateDirectory(string path);
}