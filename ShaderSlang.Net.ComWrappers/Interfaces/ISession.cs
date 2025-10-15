using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.Bindings;
using ShaderSlang.Net.ComWrappers.Descriptions;
using ShaderSlang.Net.ComWrappers.Reflection;
using ShaderSlang.Net.ComWrappers.Tools;
using ShaderSlang.Net.ComWrappers.Tools.Internal;

namespace ShaderSlang.Net.ComWrappers.Interfaces;

[GeneratedComInterface(
    StringMarshalling = StringMarshalling.Custom,
    StringMarshallingCustomType = typeof(UnownedUTF8StringMarshaller)
)]
[Guid("67618701-D116-468F-AB3B-474BEDCE0E3D")]
[GenerateThrowingMethods]
public partial interface ISession : IUnknown
{
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    IGlobalSession GetGlobalSession();

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    IModule? LoadModule(string moduleName, out IBlob diagnostics);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    IModule? LoadModuleFromSource(
        string moduleName,
        string path,
        IBlob source,
        out IBlob diagnostics
    );

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CreateCompositeComponentType(
        [MarshalUsing(CountElementName = "componentTypeCount")] Span<IComponentType> componentTypes,
        nint componentTypeCount,
        out IComponentType compositeComponentType,
        out IBlob diagnostics
    );

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<TypeReflection>))]
    TypeReflection? SpecializeType(
        TypeReflection type,
        [MarshalUsing(CountElementName = "specializationArgCount")]
            Span<SpecializationArgument> specializationArgs,
        nint specializationArgCount,
        out IBlob diagnostics
    );

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<TypeLayoutReflection>))]
    TypeLayoutReflection? GetTypeLayout(
        TypeReflection type,
        nint targetIndex,
        LayoutRules rules,
        out IBlob diagnostics
    );

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<TypeReflection>))]
    TypeReflection? GetContainerType(
        TypeReflection elementType,
        ContainerType containerType,
        out IBlob diagnostics
    );

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<TypeReflection>))]
    TypeReflection? GetDynamicType();

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetTypeRTTIMangledName(TypeReflection type, out IBlob nameBlob);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetTypeConformanceWitnessMangledName(
        TypeReflection type,
        TypeReflection interfaceType,
        out IBlob nameBlob
    );

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetTypeConformanceWitnessSequentialId(
        TypeReflection type,
        TypeReflection interfaceType,
        out uint id
    );

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CreateCompileRequest(out ICompileRequest compileRequest);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CreateTypeConformanceComponentType(
        TypeReflection type,
        TypeReflection interfaceType,
        out ITypeConformance conformance,
        nint conformanceIdOverride,
        out IBlob diagnostics
    );

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    IModule? LoadModuleFromIRBlob(
        string moduleName,
        string path,
        IBlob source,
        out IBlob diagnostics
    );

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    nint GetLoadedModuleCount();

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    IModule? GetLoadedModule(nint index);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    [return: MarshalAs(UnmanagedType.I1)]
    bool IsBinaryModuleUpToDate(string modulePath, IBlob binaryModule);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    IModule? LoadModuleFromSourceString(
        string moduleName,
        string path,
        string content,
        out IBlob diagnostics
    );

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetDynamicObjectRTTIBytes(
        TypeReflection type,
        TypeReflection interfaceType,
        [MarshalUsing(CountElementName = "bufferSizeInBytes")] Span<byte> outRTTIDataBuffer,
        uint bufferSizeInBytes
    );

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult LoadModuleInfoFromIRBlob(
        IBlob source,
        out nint moduleVersion,
        out string? moduleCompilerVersion,
        out string? moduleName
    );
}
