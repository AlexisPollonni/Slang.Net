using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Interfaces;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf8)]
[Guid("5BC42BE8-5C50-4929-9E5E-D15E7C24015F")]
public partial interface IComponentType : IUnknown
{
    [PreserveSig]
    ISession GetSession();

    [PreserveSig]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<ShaderReflection>))]
    ShaderReflection? GetLayout(nint targetIndex, out IBlob diagnostics);

    [PreserveSig]
    nint GetSpecializationParamCount();

    [PreserveSig]
    SlangResult GetEntryPointCode(nint entryPointIndex, nint targetIndex, out IBlob code, out IBlob diagnostics);

    [PreserveSig]
    SlangResult GetResultAsFileSystem(nint entryPointIndex, nint targetIndex, out IMutableFileSystem fileSystem);

    [PreserveSig]
    void GetEntryPointHash(nint entryPointIndex, nint targetIndex, out IBlob hash);

    [PreserveSig]
    SlangResult Specialize(
        [MarshalUsing(CountElementName = "specializationArgCount")] Span<SpecializationArgument> specializationArgs,
        nint specializationArgCount,
        out IComponentType specializeComponentType,
        out IBlob diagnostics);

    [PreserveSig]
    SlangResult Link(out IComponentType linkedComponentType, out IBlob diagnostics);

    [PreserveSig]
    SlangResult GetEntryPointHostCallable(nint entryPointIndex,
                                          nint targetIndex,
                                          out ISlangSharedLibrary sharedLibrary,
                                          out IBlob diagnostics);

    [PreserveSig]
    SlangResult RenameEntryPoint(string newName, out IComponentType entryPoint);

    [PreserveSig]
    SlangResult LinkWithOptions(out IComponentType linkedComponentType,
                                uint compilerOptionEntryCount,
                                [MarshalUsing(CountElementName = "compilerOptionEntryCount")]
                                Span<CompilerOptionEntry> entries,
                                out IBlob diagnostics);

    [PreserveSig]
    SlangResult GetTargetCode(nint targetIndex, out IBlob code, out IBlob diagnostics);

    [PreserveSig]
    SlangResult GetTargetMetadata(nint entryPointIndex, nint targetIndex, out IMetadata metadata, out IBlob diagnostics);

    [PreserveSig]
    SlangResult GetEntryPointMetadata(nint entryPointIndex, nint targetIndex, out IMetadata metadata, out IBlob diagnostics);
}