using System.Runtime.InteropServices;

namespace ShaderSlang.Net.Bindings.Generated;

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void VMPrintFunc(
    [NativeTypeName("const char *")] sbyte* message,
    void* userData
);
