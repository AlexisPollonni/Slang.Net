using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.Bindings;
using ShaderSlang.Net.ComWrappers.Descriptions;
using ShaderSlang.Net.ComWrappers.Tools;
using ShaderSlang.Net.ComWrappers.Tools.Internal;

namespace ShaderSlang.Net.ComWrappers.Interfaces;

[GeneratedComInterface(
    StringMarshalling = StringMarshalling.Custom,
    StringMarshallingCustomType = typeof(UnownedUTF8StringMarshaller)
)]
[Guid("C140B5FD-0C78-452E-BA7C-1A1E70C7F71C")]
[GenerateThrowingMethods]
public partial interface IGlobalSession : IUnknown
{
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CreateSession(SessionDescription desc, out ISession session);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    Unmanaged.ProfileID FindProfile(string name);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetDownstreamCompilerPath(Unmanaged.PassThrough passThrough, string path);

    [Obsolete("Use SetLanguagePrelude instead")]
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetDownstreamCompilerPrelude(Unmanaged.PassThrough passThrough, string preludeText);

    [Obsolete("Use GetLanguagePrelude instead")]
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void GetDownstreamCompilerPrelude(Unmanaged.PassThrough passThrough, out IBlob prelude);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    string GetBuildTagString();

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetDefaultDownstreamCompiler(
        Unmanaged.SourceLanguage sourceLanguage,
        Unmanaged.PassThrough defaultCompiler
    );

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    Unmanaged.PassThrough GetDefaultDownstreamCompiler(Unmanaged.SourceLanguage sourceLanguage);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetLanguagePrelude(Unmanaged.SourceLanguage sourceLanguage, string preludeText);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void GetLanguagePrelude(Unmanaged.SourceLanguage sourceLanguage, out IBlob prelude);

    [Obsolete]
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void CreateCompileRequest(out ICompileRequest compileRequest);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void AddBuiltins(string sourcePath, string sourceString);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetSharedLibraryLoader(ISlangSharedLibraryLoader loader);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    ISlangSharedLibraryLoader GetSharedLibraryLoader();

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CheckCompileTargetSupport(Unmanaged.CompileTarget target);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CheckPassThroughSupport(Unmanaged.PassThrough passThrough);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CompileCoreModule(Unmanaged.CompileCoreModuleFlag flags);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult LoadCoreModule(
        [MarshalUsing(CountElementName = "coreModuleSizeInBytes")] Span<byte> coreModule,
        ulong coreModuleSizeInBytes
    );

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult SaveCoreModule(Unmanaged.ArchiveType archiveType, out IBlob outBlob);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    Unmanaged.CapabilityID FindCapability(string name);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetDownstreamCompilerForTransition(
        Unmanaged.CompileTarget source,
        Unmanaged.CompileTarget target,
        Unmanaged.PassThrough passThrough
    );

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    Unmanaged.PassThrough GetDownstreamCompilerForTransition(
        Unmanaged.CompileTarget source,
        Unmanaged.CompileTarget target
    );

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void GetCompilerElapsedTime(out double totalTime, out double downstreamTime);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult SetSPIRVCoreGrammar(string path);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult ParseCommandLineArguments(
        int argc,
        [MarshalUsing(CountElementName = "argc")] string[] argv,
        out SessionDescription sessionDesc,
        out IUnknown auxAllocation
    );

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetSessionDescDigest(SessionDescription sessionDesc, out IBlob outBlob);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CompileBuiltInModule(
        Unmanaged.BuiltinModuleName module,
        Unmanaged.CompileCoreModuleFlag flags
    );

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult LoadBuiltinModule(
        Unmanaged.BuiltinModuleName module,
        [MarshalUsing(CountElementName = "sizeInBytes")] Span<byte> builtinModule,
        ulong sizeInBytes
    );

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult SaveBuiltInModule(
        Unmanaged.BuiltinModuleName module,
        Unmanaged.ArchiveType archiveType,
        out IBlob blob
    );
}
