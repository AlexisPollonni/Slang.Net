using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace SlangNet.ComWrappers;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf8)]
[Guid("8E12E8E3-5FCD-433E-AFCB-13A088BC5EE5")]
public partial interface IModulePrecompileServiceExperimental
{
    [PreserveSig]
    SlangResult PrecompileForTarget(Unmanaged.CompileTarget target, out IBlob blob);
    
    [PreserveSig]
    SlangResult GetPrecompiledTargetCode(Unmanaged.CompileTarget target, out IBlob code, out IBlob diagnostics);

    [PreserveSig]
    long GetModuleDependencyCount();
    
    [PreserveSig]
    SlangResult GetModuleDependency(long dependencyIndex, out IModule module, out IBlob diagnostics);
}