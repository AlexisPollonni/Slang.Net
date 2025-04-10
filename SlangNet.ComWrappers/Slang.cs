using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Tools;

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
    [return: MarshalUsing(typeof(UnownedUTF8StringMarshaller))]
    public static partial string? GetLastInternalErrorMessage();


    public static IGlobalSession CreateGlobalSession()
    {
        CreateGlobalSession(new GlobalSessionDescription(Unmanaged.SlangApi.SLANG_API_VERSION), out var globalSession)
            .ThrowIfFailed();
        return globalSession;
    }
}