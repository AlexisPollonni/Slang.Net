using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.Bindings;
using ShaderSlang.Net.ComWrappers.Tools;
using ShaderSlang.Net.ComWrappers.Tools.Internal;

namespace ShaderSlang.Net.ComWrappers.Interfaces;

[GeneratedComInterface(
    StringMarshalling = StringMarshalling.Custom,
    StringMarshallingCustomType = typeof(UnownedUTF8StringMarshaller)
)]
[Guid("8E12E8E3-5FCD-433E-AFCB-13A088BC5EE5")]
[GenerateThrowingMethods]
public partial interface IModulePrecompileServiceExperimental
{
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult PrecompileForTarget(Unmanaged.CompileTarget target, out IBlob blob);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetPrecompiledTargetCode(
        Unmanaged.CompileTarget target,
        out IBlob code,
        out IBlob diagnostics
    );

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    long GetModuleDependencyCount();

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetModuleDependency(
        long dependencyIndex,
        out IModule module,
        out IBlob diagnostics
    );
}
