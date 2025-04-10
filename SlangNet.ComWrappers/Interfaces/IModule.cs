using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Reflection;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Custom, StringMarshallingCustomType = typeof(UnownedUTF8StringMarshaller))]
[Guid("0C720E64-8722-4D31-8990-638A98B1C279")]
public partial interface IModule : IComponentType
{
    [PreserveSig]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult FindEntryPointByName(string name, out IEntryPoint entryPoint);

    [PreserveSig]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    int GetDefinedEntryPointCount();

    [PreserveSig]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetDefinedEntryPoint(int index, out IEntryPoint entryPoint);

    [PreserveSig]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult Serialize(out IBlob serialized);

    [PreserveSig]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult WriteToFile(string filename);

    [PreserveSig]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    string? GetName();

    [PreserveSig]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    [return: MarshalUsing(typeof(UnownedUTF8StringMarshaller))]
    string? GetFilePath();

    [PreserveSig]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    string? GetUniqueIdentity();

    [PreserveSig]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult FindAndCheckEntryPoint(string name,
                                       Unmanaged.Stage stage,
                                       out IEntryPoint entryPoint,
                                       out IBlob diagnostics);

    [PreserveSig]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    int GetDependencyFileCount();

    [PreserveSig]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    string? GetDependencyFilePath(int index);


    [PreserveSig]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<DeclReflection>))]
    DeclReflection? GetModuleReflection();

    [PreserveSig]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult Disassemble(out IBlob disassembled);
}