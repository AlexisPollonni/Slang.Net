using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated;

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void FileSystemContentsCallBack([NativeTypeName("SlangPathType")] PathType pathType, [NativeTypeName("const char *")] sbyte* name, void* userData);
