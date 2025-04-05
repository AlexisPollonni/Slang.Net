using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SlangNet.Bindings.Generated;

namespace SlangNet.ComWrappers;



[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf8, Options = ComInterfaceOptions.ComObjectWrapper)]
[Guid("C140B5FD-0C78-452E-BA7C-1A1E70C7F71C")]
public partial interface IGlobalSession : IUnknown
{
    //TODO: create session
    void CreateSession(in SessionDescription desc, out ISession session);
    
    [PreserveSig]
    ProfileID FindProfile(string name);

    void SetDownstreamCompilerPath(PassThrough passThrough, string path);

    void SetDownstreamCompilerPrelude(PassThrough passThrough, string preludeText);
    
    void GetDownstreamCompilerPrelude(PassThrough passThrough, out IBlob prelude);
    
    [PreserveSig]
    //[UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    string GetBuildTagString();

    void SetDefaultDownstreamCompiler(SourceLanguage sourceLanguage, PassThrough defaultCompiler);

    [PreserveSig]
    PassThrough GetDefaultDownstreamCompiler(SourceLanguage sourceLanguage);

    void SetLanguagePrelude(SourceLanguage sourceLanguage, string preludeText);
    void GetLanguagePrelude(SourceLanguage sourceLanguage, out IBlob prelude);

    //TODO: finish methods
}