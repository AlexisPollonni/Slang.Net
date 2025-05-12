using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated;

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void VMExtFunction([NativeTypeName("slang::IByteCodeRunner *")] IByteCodeRunner* context, [NativeTypeName("slang::VMExecInstHeader *")] VMExecInstHeader* inst, void* userData);
