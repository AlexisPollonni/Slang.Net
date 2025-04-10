using System.Runtime.InteropServices;

namespace SlangNet.ComWrappers;

public static partial class Slang
{
    [LibraryImport("slang", EntryPoint = "slang_createGlobalSession")]
    public static partial SlangResult CreateGlobalSession(nint apiVersion, out IGlobalSession globalSession);

    [LibraryImport("slang", EntryPoint = "slang_createGlobalSession2")]
    public static partial SlangResult CreateGlobalSession(GlobalSessionDescription desc, out IGlobalSession globalSession);

    [LibraryImport("slang", EntryPoint = "slang_createGlobalSessionWithoutCoreModule")]
    public static partial SlangResult
        CreateGlobalSessionWithoutCoreModule(nint apiVersion, out IGlobalSession globalSession);

    [LibraryImport("slang", EntryPoint = "slang_getEmbeddedCoreModule")]
    public static partial IBlob GetEmbeddedCoreModule();

    [LibraryImport("slang", EntryPoint = "slang_shutdown")]
    public static partial void Shutdown();

    [LibraryImport("slang", StringMarshalling = StringMarshalling.Utf8, EntryPoint = "slang_getLastInternalErrorMessage")]
    public static partial string? GetLastInternalErrorMessage();
}