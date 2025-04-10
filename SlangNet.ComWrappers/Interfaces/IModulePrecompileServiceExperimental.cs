using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Custom, StringMarshallingCustomType = typeof(UnownedUTF8StringMarshaller))]
[Guid("8E12E8E3-5FCD-433E-AFCB-13A088BC5EE5")]
public partial interface IModulePrecompileServiceExperimental
{
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult PrecompileForTarget(Unmanaged.CompileTarget target, out IBlob blob);
    
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetPrecompiledTargetCode(Unmanaged.CompileTarget target, out IBlob code, out IBlob diagnostics);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    long GetModuleDependencyCount();
    
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetModuleDependency(long dependencyIndex, out IModule module, out IBlob diagnostics);
}