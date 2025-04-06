using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace SlangNet.ComWrappers;

[Guid("5FB632D2-979D-4481-9FEE-663C3F1449E1")]
[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf8)]
public partial interface IFileSystem : IUnknown
{
    //TODO: Use SlangResult return type
    void LoadFile(string path, out IBlob outBlob);
}
