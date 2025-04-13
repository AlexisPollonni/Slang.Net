using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Interfaces;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers.Descriptions;

[NativeMarshalling(typeof(MarshalableMarshaller.Bidirectional<SessionDescription, Unmanaged.SessionDesc>))]
public readonly record struct SessionDescription(
    TargetDescription[]? Targets = null,
    SessionFlags Flags = SessionFlags.None,
    Unmanaged.MatrixLayoutMode DefaultMatrixLayoutMode = Unmanaged.MatrixLayoutMode.RowMajor,
    string[]? SearchPaths = null,
    PreprocessorMacroDescription[]? PreprocessorMacros = null,
    IFileSystem? FileSystem = null,
    bool EnableEffectAnnotations = false,
    bool AllowGlslSyntax = false,
    CompilerOptionEntry[]? CompilerOptions = null) : IMarshalsToNative<Unmanaged.SessionDesc>,
                                                     IMarshalsFromNative<SessionDescription, Unmanaged.SessionDesc>,
                                                     IFreeAfterMarshal<Unmanaged.SessionDesc>
{
    unsafe Unmanaged.SessionDesc IMarshalsToNative<Unmanaged.SessionDesc>.AsNative(ref GrowingStackBuffer buffer) =>
        new()
        {
            structureSize = (nuint)sizeof(Unmanaged.SessionDesc),
            targets = buffer.GetCollectionPtr<TargetDescription, Unmanaged.TargetDesc>(Targets, out var targetCount),
            targetCount = (nint)targetCount,
            flags = (uint)Flags,
            defaultMatrixLayoutMode = DefaultMatrixLayoutMode,
            searchPaths = buffer.GetCollectionPtr(SearchPaths, out var searchPathCount),
            searchPathCount = (nint)searchPathCount,
            preprocessorMacros
                = buffer.GetCollectionPtr<PreprocessorMacroDescription, Unmanaged.PreprocessorMacroDesc>(PreprocessorMacros,
                                                                                                         out
                                                                                                         var preprocessorMacroCount),
            preprocessorMacroCount = (nint)preprocessorMacroCount,
            fileSystem = (Unmanaged.ISlangFileSystem*)ComInterfaceMarshaller<IFileSystem>.ConvertToUnmanaged(FileSystem),
            enableEffectAnnotations = EnableEffectAnnotations,
            allowGLSLSyntax = AllowGlslSyntax,
            compilerOptionEntries
                = buffer.GetCollectionPtr<CompilerOptionEntry, Unmanaged.CompilerOptionEntry>(
                    CompilerOptions,
                    out var compilerOptionCount),
            compilerOptionEntryCount = compilerOptionCount
        };

    public static unsafe SessionDescription CreateFromNative(Unmanaged.SessionDesc unmanaged) =>
        new(InteropUtils.PtrToManagedMarshal<TargetDescription, Unmanaged.TargetDesc>(unmanaged.targets, (int)unmanaged.targetCount),
            (SessionFlags)unmanaged.flags,
            unmanaged.defaultMatrixLayoutMode,
            InteropUtils.PtrToStringArray(unmanaged.searchPaths, (int)unmanaged.searchPathCount),
            InteropUtils.PtrToManagedMarshal<PreprocessorMacroDescription, Unmanaged.PreprocessorMacroDesc>(
                unmanaged.preprocessorMacros,
                (int)unmanaged.preprocessorMacroCount),
            ComInterfaceMarshaller<IFileSystem>.ConvertToManaged(unmanaged.fileSystem),
            unmanaged.enableEffectAnnotations,
            unmanaged.allowGLSLSyntax,
            InteropUtils.PtrToManagedMarshal<CompilerOptionEntry, Unmanaged.CompilerOptionEntry>(
                unmanaged.compilerOptionEntries,
                (int)unmanaged.compilerOptionEntryCount));

    public unsafe void Free(Unmanaged.SessionDesc* unmanaged) =>
        ComInterfaceMarshaller<IFileSystem>.Free(unmanaged->fileSystem);
}