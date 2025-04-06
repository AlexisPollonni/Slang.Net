using System.Runtime.InteropServices.Marshalling;
using SlangNet.Bindings.Generated;

namespace SlangNet.ComWrappers;

[NativeMarshalling(typeof(ManagedToUnmanagedIn))]
public readonly record struct SessionDescription(TargetDescription[]? Targets = null,
                                                SessionFlags Flags = SessionFlags.None,
                                                MatrixLayoutMode DefaultMatrixLayoutMode = MatrixLayoutMode.RowMajor,
                                                string[]? SearchPaths = null,
                                                PreprocessorMacroDescription[]? PreprocessorMacros = null,
                                                IFileSystem? FileSystem = null,
                                                bool EnableEffectAnnotations = false,
                                                bool AllowGlslSyntax = false,
                                                CompilerOptionEntry[]? CompilerOptions = null)
{
    [CustomMarshaller(typeof(SessionDescription), MarshalMode.ManagedToUnmanagedIn, typeof(ManagedToUnmanagedIn))]
    internal unsafe ref struct ManagedToUnmanagedIn
    {
        public static int BufferSize => 1024;

        private GrowingStackBuffer _buffer;
        private SessionDesc* _unmanaged;

        public void FromManaged(SessionDescription managed, Span<byte> unmanaged)
        {
            _buffer = new(unmanaged);

            _unmanaged = _buffer.GetStructPtr(ManagedToUnmanagedConverters.SessionDescConverter(in managed, ref _buffer));
        }
        
        public readonly SessionDesc* ToUnmanaged() => _unmanaged;

        public void Free()
        {
            //Do not forget to free the filesystem interface
            ComInterfaceMarshaller<IFileSystem>.Free(_unmanaged->fileSystem);
            _buffer.Free();
        }
    }
}

public readonly record struct TargetDescription(CompileTarget Format = CompileTarget.TargetUnknown,
                                                ProfileID Profile = ProfileID.ProfileUnknown,
                                                TargetFlags Flags = 0,
                                                FloatingPointMode FloatingPointMode = FloatingPointMode.Default,
                                                LineDirectiveMode LineDirectiveMode = LineDirectiveMode.Default,
                                                bool ForceGlslScalarBufferLayout = false,
                                                CompilerOptionEntry[]? CompilerOptions = null);




public readonly record struct CompilerOptionEntry(
    CompilerOptionName Name,
    CompilerOptionValueKind Kind,
    int IntValue0,
    int IntValue1,
    string? StringValue0,
    string? StringValue1);

public readonly record struct PreprocessorMacroDescription(string Name, string Value);