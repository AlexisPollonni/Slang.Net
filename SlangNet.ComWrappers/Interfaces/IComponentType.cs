using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Descriptions;
using SlangNet.ComWrappers.Reflection;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers.Interfaces;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Custom, StringMarshallingCustomType = typeof(UnownedUTF8StringMarshaller))]
[Guid("5BC42BE8-5C50-4929-9E5E-D15E7C24015F")]
public partial interface IComponentType : IUnknown
{
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    ISession GetSession();

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<ShaderReflection>))]
    ShaderReflection? GetLayout(nint targetIndex, out IBlob diagnostics);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    nint GetSpecializationParamCount();

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetEntryPointCode(nint entryPointIndex, nint targetIndex, out IBlob code, out IBlob diagnostics);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetResultAsFileSystem(nint entryPointIndex, nint targetIndex, out IMutableFileSystem fileSystem);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void GetEntryPointHash(nint entryPointIndex, nint targetIndex, out IBlob hash);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult Specialize(
        [MarshalUsing(CountElementName = "specializationArgCount")] Span<SpecializationArgument> specializationArgs,
        nint specializationArgCount,
        out IComponentType specializeComponentType,
        out IBlob diagnostics);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult Link(out IComponentType linkedComponentType, out IBlob diagnostics);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetEntryPointHostCallable(nint entryPointIndex,
                                          nint targetIndex,
                                          out ISlangSharedLibrary sharedLibrary,
                                          out IBlob diagnostics);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult RenameEntryPoint(string newName, out IComponentType entryPoint);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult LinkWithOptions(out IComponentType linkedComponentType,
                                uint compilerOptionEntryCount,
                                [MarshalUsing(CountElementName = "compilerOptionEntryCount")]
                                Span<CompilerOptionEntry> entries,
                                out IBlob diagnostics);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetTargetCode(nint targetIndex, out IBlob code, out IBlob diagnostics);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetTargetMetadata(nint entryPointIndex, nint targetIndex, out IMetadata metadata, out IBlob diagnostics);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetEntryPointMetadata(nint entryPointIndex, nint targetIndex, out IMetadata metadata, out IBlob diagnostics);
}