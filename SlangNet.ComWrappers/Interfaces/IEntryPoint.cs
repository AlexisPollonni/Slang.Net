using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf8)]
[Guid("8F241361-F5BD-4CA0-A3AC-02F7FA2402B8")]
public partial interface IEntryPoint : IComponentType
{
    [PreserveSig]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<FunctionReflection>))]
    FunctionReflection? GetFunctionReflection();
}