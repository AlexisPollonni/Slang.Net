using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated;

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void SlangDiagnosticCallback([NativeTypeName("const char *")] sbyte* message, void* userData);
