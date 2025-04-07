using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers.Interfaces;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf8)]
[Guid("5FB632D2-979D-4481-9FEE-663C3F1449E1")]
public partial interface IFileSystemExt : IFileSystem
{
    [PreserveSig]
    SlangResult GetFileUniqueIdentity(string path, out IBlob uniqueIdentity);

    [PreserveSig]
    SlangResult CalcCombinedPath(Unmanaged.PathType fromPathType, string fromPath, string path, out IBlob pathOut);
    
    [PreserveSig]
    SlangResult GetPathType(string path, out Unmanaged.PathType pathType);
    
    [PreserveSig]
    SlangResult GetPath(PathKind kind, string path, out IBlob pathOut);
    
    [PreserveSig]
    void ClearCache();

    [PreserveSig]
    unsafe SlangResult EnumeratePathContents(string path, 
                                             [MarshalUsing(typeof(FileSystemContentsCallBackMarshaller))]
                                             Action<Unmanaged.PathType, string, nint> callback,
                                             void* userData);
    
    [PreserveSig]
    PathKind GetOsPathKind();
}