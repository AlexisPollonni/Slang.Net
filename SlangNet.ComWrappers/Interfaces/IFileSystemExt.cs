using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers.Interfaces;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Custom, StringMarshallingCustomType = typeof(UnownedUTF8StringMarshaller))]
[Guid("5FB632D2-979D-4481-9FEE-663C3F1449E1")]
public partial interface IFileSystemExt : IFileSystem
{
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetFileUniqueIdentity(string path, out IBlob uniqueIdentity);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CalcCombinedPath(Unmanaged.PathType fromPathType, string fromPath, string path, out IBlob pathOut);
    
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetPathType(string path, out Unmanaged.PathType pathType);
    
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetPath(PathKind kind, string path, out IBlob pathOut);
    
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void ClearCache();

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult EnumeratePathContents(string path, 
                                      [MarshalUsing(typeof(FileSystemContentsCallBackMarshaller))]
                                      Action<Unmanaged.PathType, string, nint> callback,
                                      nint userData);
    
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    PathKind GetOsPathKind();
}