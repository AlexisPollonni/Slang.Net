using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace SlangNet.ComWrappers;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf8)]
[Guid("6264AB2B-A3E8-4A06-97F1-49BC2D2AB14D")]
public partial interface ISlangSharedLibraryLoader : IUnknown
{
    void LoadSharedLibrary(string path, out ISlangSharedLibrary sharedLibrary);
}
