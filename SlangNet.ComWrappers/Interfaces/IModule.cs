using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Reflection;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf8)]
[Guid("0C720E64-8722-4D31-8990-638A98B1C279")]
public partial interface IModule : IComponentType
{
    [PreserveSig]
    SlangResult FindEntryPointByName(string name, out IEntryPoint entryPoint);

    [PreserveSig]
    int GetDefinedEntryPointCount();

    [PreserveSig]
    SlangResult GetDefinedEntryPoint(int index, out IEntryPoint entryPoint);

    [PreserveSig]
    SlangResult Serialize(out IBlob serialized);

    [PreserveSig]
    SlangResult WriteToFile(string filename);

    [PreserveSig]
    string? GetName();

    [PreserveSig]
    string? GetFilePath();

    [PreserveSig]
    string? GetUniqueIdentity();

    [PreserveSig]
    SlangResult FindAndCheckEntryPoint(string name,
                                       Unmanaged.Stage stage,
                                       out IEntryPoint entryPoint,
                                       out IBlob diagnostics);

    [PreserveSig]
    int GetDependencyFileCount();

    [PreserveSig]
    string? GetDependencyFilePath(int index);


    [PreserveSig]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<DeclReflection>))]
    DeclReflection? GetModuleReflection();

    [PreserveSig]
    SlangResult Disassemble(out IBlob disassembled);
}