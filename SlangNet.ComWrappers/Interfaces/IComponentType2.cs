using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers.Interfaces;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Custom,
                       StringMarshallingCustomType = typeof(UnownedUTF8StringMarshaller))]
[Guid("9c2a4b3d-7f68-4e91-A52C-8B193E457A9F")]
[GenerateThrowingMethods]
public partial interface IComponentType2 : IUnknown
{
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetTargetCompileResult(nint targetIndex, out ICompileResult compileResult, out IBlob diagnostics);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetEntryPointCompileResult(nint entryPointIndex,
                                           nint targetIndex,
                                           out ICompileResult compileResult,
                                           out IBlob diagnostics);
}