using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf8)]
[Guid("67618701-D116-468F-AB3B-474BEDCE0E3D")]
public partial interface ISession : IUnknown
{
    [PreserveSig]
    IGlobalSession GetGlobalSession();

    [PreserveSig]
    IModule? LoadModule(string moduleName, out IBlob diagnostics);

    [PreserveSig]
    IModule? LoadModuleFromSource(string moduleName, string path, IBlob source, out IBlob diagnostics);

    [PreserveSig]
    SlangResult CreateCompositeComponentType(
        [MarshalUsing(CountElementName = "componentTypeCount")]
        Span<IComponentType> componentTypes, nint componentTypeCount,
        out IComponentType compositeComponentType,
        out IBlob diagnostics);

    [PreserveSig]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<TypeReflection>))]
    TypeReflection? SpecializeType(TypeReflection type,
                                   [MarshalUsing(CountElementName = "specializationArgCount")]
                                   Span<SpecializationArgument> specializationArgs,
                                   nint specializationArgCount,
                                   out IBlob diagnostics);

    [PreserveSig]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<TypeLayoutReflection>))]
    TypeLayoutReflection? GetTypeLayout(TypeReflection type,
                                        nint targetIndex,
                                        LayoutRules rules,
                                        out IBlob diagnostics);

    [PreserveSig]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<TypeReflection>))]
    TypeReflection? GetContainerType(TypeReflection elementType, ContainerType containerType, out IBlob diagnostics);

    [PreserveSig]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<TypeReflection>))]
    TypeReflection? GetDynamicType();

    [PreserveSig]
    SlangResult GetTypeRTTIMangledName(TypeReflection type, out IBlob nameBlob);

    [PreserveSig]
    SlangResult GetTypeConformanceWitnessMangledName(TypeReflection type, TypeReflection interfaceType, out IBlob nameBlob);

    [PreserveSig]
    SlangResult GetTypeConformanceWitnessSequentialId(TypeReflection type, TypeReflection interfaceType, out uint id);

    [PreserveSig]
    SlangResult CreateCompileRequest(out ICompileRequest compileRequest);

    [PreserveSig]
    SlangResult CreateTypeConformanceComponentType(TypeReflection type,
                                                   TypeReflection interfaceType,
                                                   out ITypeConformance conformance,
                                                   nint conformanceIdOverride,
                                                   out IBlob diagnostics);

    [PreserveSig]
    IModule? LoadModuleFromIRBlob(string moduleName, string path, IBlob source, out IBlob diagnostics);

    [PreserveSig]
    nint GetLoadedModuleCount();

    [PreserveSig]
    IModule? GetLoadedModule(nint index);

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.I1)]
    bool IsBinaryModuleUpToDate(string modulePath, IBlob binaryModule);

    [PreserveSig]
    IModule? LoadModuleFromSourceString(string moduleName, string path, string content, out IBlob diagnostics);
}