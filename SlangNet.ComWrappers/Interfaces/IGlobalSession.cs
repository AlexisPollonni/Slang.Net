using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SlangNet.Bindings.Generated;

namespace SlangNet.ComWrappers;



[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf8, Options = ComInterfaceOptions.ComObjectWrapper)]
[Guid("C140B5FD-0C78-452E-BA7C-1A1E70C7F71C")]
public partial interface IGlobalSession : IUnknown
{
    void CreateSession(SessionDescription desc, out ISession session);
    
    [PreserveSig]
    ProfileID FindProfile(string name);

    void SetDownstreamCompilerPath(PassThrough passThrough, string path);

    [Obsolete("Use SetLanguagePrelude instead")]
    void SetDownstreamCompilerPrelude(PassThrough passThrough, string preludeText);
    
    [Obsolete("Use GetLanguagePrelude instead")]
    void GetDownstreamCompilerPrelude(PassThrough passThrough, out IBlob prelude);
    
    [PreserveSig]
    string GetBuildTagString();

    void SetDefaultDownstreamCompiler(SourceLanguage sourceLanguage, PassThrough defaultCompiler);

    [PreserveSig]
    PassThrough GetDefaultDownstreamCompiler(SourceLanguage sourceLanguage);

    void SetLanguagePrelude(SourceLanguage sourceLanguage, string preludeText);
    void GetLanguagePrelude(SourceLanguage sourceLanguage, out IBlob prelude);

    [Obsolete]
    void CreateCompileRequest(out ICompileRequest compileRequest);
    
    [PreserveSig]
    void AddBuiltins(string sourcePath, string sourceString);

    [PreserveSig]
    void SetSharedLibraryLoader(ISlangSharedLibraryLoader loader);
    
    [PreserveSig]
    ISlangSharedLibraryLoader GetSharedLibraryLoader();


    [PreserveSig]
    SlangResult CheckCompileTargetSupport(CompileTarget target);
    [PreserveSig]
    SlangResult CheckPassThroughSupport(PassThrough passThrough);

    [PreserveSig]
    SlangResult CompileCoreModule(CompileCoreModuleFlag flags);

    [PreserveSig]
    SlangResult LoadCoreModule(ReadOnlySpan<byte> coreModule, ulong coreModuleSizeInBytes);

    [PreserveSig]
    SlangResult SaveCoreModule(ArchiveType archiveType, out IBlob outBlob);

    [PreserveSig]
    CapabilityID FindCapability(string name);

    [PreserveSig]
    void SetDownstreamCompilerForTransition(CompileTarget source, CompileTarget target, PassThrough passThrough);

    [PreserveSig]
    PassThrough GetDownstreamCompilerForTransition(CompileTarget source, CompileTarget target);

    [PreserveSig]
    void GetCompilerElapsedTime(out double totalTime, out double downstreamTime);

    [PreserveSig]
    SlangResult SetSPIRVCoreGrammar(string path);

    [PreserveSig]
    SlangResult ParseCommandLineArguments(int argc, string[] argv, out SessionDescription sessionDesc, out IUnknown auxAllocation);

    [PreserveSig]
    SlangResult GetSessionDescDigest(SessionDescription sessionDesc, out IBlob outBlob);
}