using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using SlangNet.Enums;
using SlangNet.Internal;

namespace SlangNet;

[GenerateThrowingMethods]
public sealed unsafe partial class CompileRequest : COMObject<ICompileRequest>
{
    internal CompileRequest(ICompileRequest* pointer) : base(pointer)
    {
        DependencyFilePaths = new NativeBoundedReadOnlyList<ICompileRequest, string>
        {
            Container = Pointer,
            GetCount = compileRequest => compileRequest->getDependencyFileCount(),
            TryGetAt = (ICompileRequest* compileRequest, nint index, out string result) =>
            {
                var ptr = compileRequest->getDependencyFilePath(checked((int)index));
                result = InteropUtils.PtrToStringUTF8(ptr) ?? "";
                return ptr != null;
            }
        };
        TranslationUnits = new(pointer);
    }

    // IFileSystem FileSystem

    public CompileFlags CompileFlags
    {
        get => (CompileFlags)Pointer->getCompileFlags();
        set => Pointer->setCompileFlags((uint)value);
    }

    public bool DumpIntermediates
    {
        set => Pointer->setDumpIntermediates(value ? 1 : 0);
    }

    public string? DumpIntermediatePrefix
    {
        set
        {
            using var prefixStr = new Utf8String(value);
            Pointer->setDumpIntermediatePrefix(prefixStr);
        }
    }

    public LineDirectiveMode LineDirectiveMode
    {
        set => Pointer->setLineDirectiveMode(value);
    }

    public void SetCodeGenTarget(CompileTarget target) =>
        Pointer->setCodeGenTarget(target);

    public void AddCodeGenTarget(CompileTarget target) =>
        Pointer->addCodeGenTarget(target);

    public void SetTargetProfile(int targetIndex, ProfileID profile) =>
        Pointer->setTargetProfile(targetIndex, profile);

    public void SetTargetFlags(int targetIndex, TargetFlags flags) =>
        Pointer->setTargetFlags(targetIndex, (uint)flags);

    public void SetTargetFloatingPointMode(int targetIndex, FloatingPointMode mode) =>
        Pointer->setTargetFloatingPointMode(targetIndex, mode);

    public void SetTargetMatrixLayoutMode(int targetIndex, MatrixLayoutMode mode) =>
        Pointer->setTargetMatrixLayoutMode(targetIndex, mode);

    public MatrixLayoutMode MatrixLayoutMode
    {
        set => Pointer->setMatrixLayoutMode(value);
    }

    public DebugInfoLevel DebugInfoLevel
    {
        set => Pointer->setDebugInfoLevel(value);
    }

    public OptimizationLevel OptimizationLevel
    {
        set => Pointer->setOptimizationLevel(value);
    }

    public ContainerFormat OutputContainerFormat
    {
        set => Pointer->setOutputContainerFormat(value);
    }

    public PassThrough PassThrough
    {
        set => Pointer->setPassThrough(value);
    }

    //DiagnosticCallback
    //Writer...

    public void AddSearchPath(string searchPath)
    {
        using var searchPathStr = new Utf8String(searchPath);
        Pointer->addSearchPath(searchPathStr);
    }

    public void AddSearchPath(ReadOnlySpan<byte> searchPath)
    {
        fixed (byte* searchPathPtr = searchPath)
            Pointer->addSearchPath((sbyte*)searchPathPtr);
    }

    public void AddPreprocessorDefine(ReadOnlySpan<byte> key, ReadOnlySpan<byte> value)
    {
        fixed (byte* keyPtr = key)
        fixed (byte* valuePtr = value)
            Pointer->addPreprocessorDefine((sbyte*)keyPtr, (sbyte*)valuePtr);
    }

    public void AddPreprocessorDefine(string key, string value)
    {
        using var keyStr = new Utf8String(key);
        using var valueStr = new Utf8String(value);
        Pointer->addPreprocessorDefine(keyStr, valueStr);
    }

    public SlangResult TryProcessCommandLineArguments(IEnumerable<string> arguments)
    {
        using var argumentsArray = new Utf8StringArray(arguments);
        return new(Pointer->processCommandLineArguments(argumentsArray.Memory, argumentsArray.Count));
    }

    public string DefaultModuleName
    {
        set
        {
            using var nameStr = new Utf8String(value);
            Pointer->setDefaultModuleName(nameStr);
        }
    }

    public SlangResult TryAddLibraryReference(string basePath, ReadOnlySpan<byte> libData)
    {
        using var basePathStr = new Utf8String(basePath);
        fixed (byte* libDataPtr = libData)
            return new(Pointer->addLibraryReference(basePathStr.Memory, libDataPtr, new((uint)libData.Length)));
    }

    public SlangResult TrySetGlobalGenericArgs(IEnumerable<string> genericArgs)
    {
        using var genericArgsArray = new Utf8StringArray(genericArgs);
        return new(Pointer->setGlobalGenericArgs(genericArgsArray.Count, genericArgsArray.Memory));
    }

    public SlangResult TrySetTypeNameForGlobalExistentialTypeParam(int slotIndex, ReadOnlySpan<byte> typeName)
    {
        fixed (byte* typeNamePtr = typeName)
            return new(Pointer->setTypeNameForGlobalExistentialTypeParam(slotIndex, (sbyte*)typeNamePtr));
    }

    public SlangResult TrySetTypeNameForGlobalExistentialTypeParam(int slotIndex, string typeName)
    {
        using var typeNameStr = new Utf8String(typeName);
        return new(Pointer->setTypeNameForGlobalExistentialTypeParam(slotIndex, typeNameStr));
    }

    public SlangResult TrySetTypeNameForEntryPointExistentialTypeName(int entryPointIndex, int slotIndex, ReadOnlySpan<byte> typeName)
    {
        fixed (byte* typeNamePtr = typeName)
            return new(Pointer->setTypeNameForEntryPointExistentialTypeParam(entryPointIndex, slotIndex, (sbyte*)typeNamePtr));
    }

    public SlangResult TrySetTypeNameForEntryPointExistentialTypeName(int entryPointIndex, int slotIndex, string typeName)
    {
        using var typeNameStr = new Utf8String(typeName);
        return new(Pointer->setTypeNameForEntryPointExistentialTypeParam(entryPointIndex, slotIndex, typeNameStr));
    }

    public SlangResult TryCompile() =>
        new(Pointer->compile());

    public string? DiagnosticOutput =>
        InteropUtils.PtrToStringUTF8(Pointer->getDiagnosticOutput());

    // skipping getDiagnosticOutputBlob

    private static nint GetDependencyFileCount(ICompileRequest* compileRequest) =>
        compileRequest->getDependencyFileCount();

    public IReadOnlyList<string> DependencyFilePaths { get; }
    public TranslationUnitList TranslationUnits { get; }

    public string? GetEntryPointSource(int index) =>
        InteropUtils.PtrToStringUTF8(Pointer->getEntryPointSource(index));

    public ReadOnlySpan<byte> GetEntryPointCode(int index)
    {
        UIntPtr size = default;
        var ptr = Pointer->getEntryPointCode(index, &size);
        if (ptr == null)
            throw new NullReferenceException("CompileRequest::getEntryPointCode returned a null pointer");
        return new(ptr, checked((int)size.ToUInt64()));
    }

    public SlangResult TryGetEntryPointCodeBlob(int entryPointIndex, int targetIndex, [NotNullWhen(true)] out IMemoryOwner<byte>? blob)
    {
        ISlangBlob* blobPtr = null;
        var result = Pointer->getEntryPointCodeBlob(entryPointIndex, targetIndex, &blobPtr);
        blob = blobPtr == null ? null : new BlobMemoryManager<byte>(blobPtr);
        return new(result);
    }

    // TODO: Add CompileRequest::getEntryPointHostCallable
    // TODO: Add CompileRequest::getTargetHostCallable

    public SlangResult TryGetTargetCodeBlob(int targetIndex, [NotNullWhen(true)] out IMemoryOwner<byte>? blob)
    {
        ISlangBlob* blobPtr = null;
        var result = Pointer->getTargetCodeBlob(targetIndex, &blobPtr);
        blob = blobPtr == null ? null : new BlobMemoryManager<byte>(blobPtr);
        return new(result);
    }

    public ReadOnlySpan<byte> CompileRequestCode
    {
        get
        {
            nuint size = 0;
            var ptr = Pointer->getCompileRequestCode(&size);
            if (ptr == null)
                throw new NullReferenceException("CompileRequest::getCompileRequestCode returned a null pointer");
            return new(ptr, checked((int)size.ToUInt64()));
        }
    }

    // TODO: Add CompileRequest::loadRepro

    public SlangResult TrySaveRepro([NotNullWhen(true)] out IMemoryOwner<byte>? blob)
    {
        ISlangBlob* blobPtr = null;
        var result = Pointer->saveRepro(&blobPtr);
        blob = blobPtr == null ? null : new BlobMemoryManager<byte>(blobPtr);
        return new(result);
    }

    public SlangResult TryEnableReproCapture() =>
        new(Pointer->enableReproCapture());

    public SlangResult TryGetProgram([NotNullWhen(true)] out ComponentType? program)
    {
        IComponentType* programPtr = null;
        var result = Pointer->getProgram(&programPtr);
        program = ComponentType.CreateFromPointer(programPtr);
        return new(result);
    }

    public SlangResult TryGetEntryPoint(long entryPointIndex, [NotNullWhen(true)] out ComponentType? entryPoint)
    {
        IComponentType* entryPointPtr = null;
        var result = Pointer->getEntryPoint((nint)entryPointIndex, &entryPointPtr);
        entryPoint = ComponentType.CreateFromPointer(entryPointPtr);
        return new(result);
    }

    public SlangResult TryGetSession([NotNullWhen(true)] out Session? session)
    {
        ISession* sessionPtr = null;
        var result = Pointer->getSession(&sessionPtr);
        session = sessionPtr == null ? null : new(sessionPtr);
        return new(result);
    }

    public ShaderReflection? Reflection
    {
        get
        {
            var ptr = Pointer->getReflection();
            return ptr == null ? null : new(ptr);
        }
    }

    public void SetCommandLineCompilerMode() =>
        Pointer->setCommandLineCompilerMode();

    public SlangResult TryAddTargetCapability(long targetIndex, CapabilityID capability) =>
        new(Pointer->addTargetCapability((nint)targetIndex, capability));

    public SlangResult TryGetProgramWithEntryPoints([NotNullWhen(true)] out ComponentType? program)
    {
        IComponentType* programPtr = null;
        var result = Pointer->getProgramWithEntryPoints(&programPtr);
        program = ComponentType.CreateFromPointer(programPtr);
        return new(result);
    }

    public SlangResult TryIsParameterLocationUsed(
        long entryPointIndex,
        long targetIndex,
        ParameterCategory category,
        ulong spaceIndex,
        ulong registerIndex,
        out bool used)
    {
        Unsafe.Boolean usedB;
        var res = Pointer->isParameterLocationUsed((nint)entryPointIndex, (nint)targetIndex, category, (nuint)spaceIndex, (nuint)registerIndex, &usedB).ToSlangResult();
        used = usedB;
        return res;
    }

    public void SetTargetLineDirectiveMode(long targetIndex, LineDirectiveMode mode) =>
        Pointer->setTargetLineDirectiveMode((nint)targetIndex, mode);

    public void SetTargetForceGLSLScalarBufferLayout(int targetIndex, bool forceScalarLayout) =>
        Pointer->setTargetForceGLSLScalarBufferLayout(targetIndex, forceScalarLayout ? (byte)1 : (byte)0);

    public void OverrideDiagnosticSeverity(long messageID, Severity overrideSeverity) =>
        Pointer->overrideDiagnosticSeverity((nint)messageID, overrideSeverity);

    public DiagnosticFlags DiagnosticFlags
    {
        get => (DiagnosticFlags)Pointer->getDiagnosticFlags();
        set => Pointer->setDiagnosticFlags((int)value);
    }

    public DebugInfoFormat DebugInfoFormat
    {
        set => Pointer->setDebugInfoFormat(value);
    }

    public bool EnableEffectAnnotations
    {
        set => Pointer->setEnableEffectAnnotations((byte)(value ? 1 : 0));
    }

    public bool ReportDownstreamTime
    {
        set => Pointer->setReportDownstreamTime((byte)(value ? 1 : 0));
    }

    public bool ReportPerfBenchmark
    {
        set => Pointer->setReportPerfBenchmark((byte)(value ? 1 : 0));
    }
}
