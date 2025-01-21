using System;
using System.Buffers;
using System.Diagnostics.CodeAnalysis;
using SlangNet.Internal;
using static SlangNet.InteropUtils;

namespace SlangNet;

[GenerateThrowingMethods]
public sealed unsafe partial class GlobalSession : COMObject<IGlobalSession>
{
    internal GlobalSession(IGlobalSession* pointer) : base(pointer) { }

    public static SlangResult TryCreate([NotNullWhen(true)] out GlobalSession? session)
        => TryCreate(SLANG_API_VERSION, out session);

    public static SlangResult TryCreate(long apiVersion, [NotNullWhen(true)] out GlobalSession? session)
    {
        IGlobalSession* pointer;
        var result = new SlangResult(slang_createGlobalSession((nint)apiVersion, &pointer));
        session = result.Succeeded ? new(pointer) : null;
        return result;
    }

    public SlangResult CheckCompileTargetSupport(CompileTarget target) =>
        new(Pointer->checkCompileTargetSupport(target));

    public SlangResult CheckPassThroughSupport(PassThrough passThrough) =>
        new(Pointer->checkPassThroughSupport(passThrough));

    public void AddBuiltins(ReadOnlySpan<byte> sourcePath, ReadOnlySpan<byte> sourceString)
    {
        fixed(byte* sourcePathPtr = sourcePath)
        fixed(byte* sourceStringPtr = sourceString)
            Pointer->addBuiltins((sbyte*)sourcePathPtr, (sbyte*)sourceStringPtr);
    }

    public void AddBuiltins(string sourcePath, string sourceString)
    {
        using var sourcePathStr = new Utf8String(sourcePath);
        using var sourceStringStr = new Utf8String(sourceString);
        Pointer->addBuiltins(sourcePathStr, sourceStringStr);
    }

    public ProfileID FindProfile(ReadOnlySpan<byte> name)
    {
        fixed (byte* namePtr = name)
            return Pointer->findProfile((sbyte*)namePtr);
    }

    public ProfileID FindProfile(string name)
    {
        using var nameStr = new Utf8String(name);
        return Pointer->findProfile(nameStr);
    }

    public CapabilityID FindCapability(ReadOnlySpan<byte> name)
    {
        fixed (byte* namePtr = name)
            return Pointer->findCapability((sbyte*)namePtr);
    }

    public CapabilityID FindCapability(string name)
    {
        using var nameStr = new Utf8String(name);
        return Pointer->findCapability(nameStr);
    }

    public void GetCompilerElapsedTime(out double totalTime, out double downstreamTime)
    {
        fixed (double* totalTimePtr = &totalTime)
        fixed (double* downstreamTimePtr = &downstreamTime)
            Pointer->getCompilerElapsedTime(totalTimePtr, downstreamTimePtr);
    }

    public void SetDownstreamCompilerPath(PassThrough passThrough, string path)
    {
        using var pathStr = new Utf8String(path);
        Pointer->setDownstreamCompilerPath(passThrough, pathStr);
    }

    public void SetDownstreamCompilerPath(PassThrough passThrough, ReadOnlySpan<byte> path)
    {
        fixed (byte* pathPtr = path)
            Pointer->setDownstreamCompilerPath(passThrough, (sbyte*)pathPtr);
    }

    public PassThrough GetDefaultDownstreamCompiler(SourceLanguage sourceLanguage) =>
        Pointer->getDefaultDownstreamCompiler(sourceLanguage);

    public SlangResult TrySetDefaultDownstreamCompiler(SourceLanguage sourceLanguage, PassThrough defaultCompiler) =>
        new(Pointer->setDefaultDownstreamCompiler(sourceLanguage, defaultCompiler));

    public PassThrough GetDownstreamCompilerForTransition(CompileTarget source, CompileTarget target) =>
        Pointer->getDownstreamCompilerForTransition(source, target);

    public void SetDownstreamCompilerForTransition(CompileTarget source, CompileTarget target, PassThrough compiler) =>
        Pointer->setDownstreamCompilerForTransition(source, target, compiler);

    public string? GetLanguagePrelude(SourceLanguage sourceLanguage)
    {
        using var preludeBlob = new COMPointer<ISlangBlob>();
        Pointer->getLanguagePrelude(sourceLanguage, &preludeBlob.Pointer);
        return preludeBlob.AsString();
    }

    public void SetLanguagePrelude(SourceLanguage sourceLanguage, string? prelude)
    {
        using var preludeStr = new Utf8String(prelude);
        Pointer->setLanguagePrelude(sourceLanguage, preludeStr.Memory);
    }

    public void SetLanguagePrelude(SourceLanguage sourceLanguage, ReadOnlySpan<byte> prelude)
    {
        fixed (byte* preludePtr = prelude)
            Pointer->setLanguagePrelude(sourceLanguage, (sbyte*)preludePtr);
    }

    public string? BuildTagString => PtrToStringUTF8(Pointer->getBuildTagString());

    public SlangResult TryCompileCoreModule(CompileCoreModuleFlag.Enum flags) =>
        new(Pointer->compileCoreModule((uint)flags));

    public SlangResult TryLoadCoreModule(ReadOnlySpan<byte> coreModule)
    {
        fixed (byte* coreModulePtr = coreModule)
            return new(Pointer->loadCoreModule(coreModulePtr, new((uint)coreModule.Length)));
    }

    public SlangResult TrySaveCoreModule(ArchiveType archiveType, [NotNullWhen(true)] out IMemoryOwner<byte>? coreModule)
    {
        coreModule = null;
        ISlangBlob* blob;
        var result = Pointer->saveCoreModule(archiveType, &blob);
        if (blob != null)
            coreModule = new BlobMemoryManager(blob);
        return new(result);
    }


    public SlangResult TrySetSPIRVCoreGrammar(string jsonPath)
    {
        using var jsonPathStr = new Utf8String(jsonPath);
        return new(Pointer->setSPIRVCoreGrammar(jsonPathStr));
    }

    public SlangResult TrySetSPIRVCoreGrammar(ReadOnlySpan<byte> jsonPath)
    {
        fixed (byte* jsonPathPtr = jsonPath)
            return new(Pointer->setSPIRVCoreGrammar((sbyte*)jsonPathPtr));
    }

    /*public ISharedLibraryLoader? SharedLibraryLoader
    {
        get;
        set;
    }*/

    public SlangResult TryCreateSession(SessionDescription desc, [NotNullWhen(true)] out Session? session)
    {
        session = null;
        using var nativeDesc = desc.AsNative();
        ISession* sessionPtr;
        var result = Pointer->createSession(&nativeDesc.Native, &sessionPtr);
        if (sessionPtr != null)
            session = new(sessionPtr);
        return new(result);
    }
    
    public SlangResult TryCreateCompileRequest([NotNullWhen(true)] out CompileRequest? request)
    {
        var requestPtr = SlangApi.CreateCompileRequest(Pointer);
        request = requestPtr == null ? null : new(requestPtr);
        return request is null ? SlangResult.Fail : SlangResult.Ok;
    }
}
