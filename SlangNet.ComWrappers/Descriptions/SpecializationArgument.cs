using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Reflection;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers.Descriptions;

[NativeMarshalling(typeof(MarshalableMarshaller.Bidirectional<SpecializationArgument, Unmanaged.SpecializationArg>))]
public readonly record struct SpecializationArgument(Unmanaged.SpecializationArg.TypeKind Kind, TypeReflection Type) : IMarshalsToNative<Unmanaged.SpecializationArg>, IMarshalsFromNative<SpecializationArgument, Unmanaged.SpecializationArg> {
    unsafe Unmanaged.SpecializationArg IMarshalsToNative<Unmanaged.SpecializationArg>.AsNative(ref GrowingStackBuffer buffer) =>
        new()
        {
            kind = Kind,
            Anonymous = new()
            {
                type = (Unmanaged.TypeReflection*)Type.Pointer
            }
        };

    public static unsafe SpecializationArgument CreateFromNative(Unmanaged.SpecializationArg unmanaged) =>
        new(unmanaged.kind, TypeReflection.CreateFromHandle((nint)unmanaged.type));
}