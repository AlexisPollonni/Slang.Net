using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.Bindings;
using ShaderSlang.Net.ComWrappers.Descriptions;
using ShaderSlang.Net.ComWrappers.Interfaces;
using ShaderSlang.Net.ComWrappers.Tools;

namespace ShaderSlang.Net.ComWrappers;

public static partial class Slang
{
    [LibraryImport("slang", EntryPoint = "slang_createGlobalSession")]
    public static partial SlangResult CreateGlobalSession(int apiVersion, out IGlobalSession globalSession);

    [LibraryImport("slang", EntryPoint = "slang_createGlobalSession2")]
    public static partial SlangResult CreateGlobalSession(GlobalSessionDescription desc, out IGlobalSession globalSession);

    [LibraryImport("slang", EntryPoint = "slang_createGlobalSessionWithoutCoreModule")]
    public static partial SlangResult CreateGlobalSessionWithoutCoreModule(int apiVersion, out IGlobalSession globalSession);

    [LibraryImport("slang", EntryPoint = "slang_getEmbeddedCoreModule")]
    public static partial IBlob GetEmbeddedCoreModule();

    [LibraryImport("slang", EntryPoint = "slang_shutdown")]
    public static partial void Shutdown();

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "slang_getLastInternalErrorMessage")]
    [return: MarshalUsing(typeof(UnownedUTF8StringMarshaller))]
    public static partial string? GetLastInternalErrorMessage();

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "slang_createByteCodeRunner")]
    public static partial SlangResult CreateByteCodeRunner(in Unmanaged.ByteCodeRunnerDesc desc,
                                                           out IByteCodeRunner outByteCodeRunner);

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "slang_disassembleByteCode")]
    public static partial SlangResult DisassembleByteCode(IBlob moduleBlob, out IBlob outDisassemblyBlob);

    [LibraryImport("slang", EntryPoint = "slang_createBlob")]
    public static partial IBlob? CreateBlob([MarshalUsing(CountElementName = "size")] ReadOnlySpan<byte> data, nuint size);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "slang_loadModuleFromSource")]
    public static partial IModule? LoadModuleFromSource(ISession session, string moduleName, string path, [MarshalUsing(CountElementName = "sourceSize")] string source, nuint sourceSize, out IBlob? diagnostics);
    
    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "slang_loadModuleFromIRBlob")]
    public static partial IModule? LoadModuleFromIRBlob(ISession session, string moduleName, string path, [MarshalUsing(CountElementName = "sourceSize")] ReadOnlySpan<byte> source, nuint sourceSize, out IBlob? diagnostics);

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "slang_loadModuleInfoFromIRBlob")]
    public static partial SlangResult LoadModuleInfoFromIRBlob(ISession session, [MarshalUsing(CountElementName = "sourceSize")] ReadOnlySpan<byte> source, nuint sourceSize, out nint moduleVersion, out string moduleCompilerVersion, out string moduleName);
    
    
    public static IGlobalSession CreateGlobalSession()
    {
        CreateGlobalSession(new GlobalSessionDescription(Unmanaged.SlangApi.SLANG_API_VERSION), out var globalSession)
            .ThrowIfFailed();
        return globalSession;
    }
}