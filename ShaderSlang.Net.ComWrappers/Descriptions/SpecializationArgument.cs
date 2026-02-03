using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.ComWrappers.Reflection;
using ShaderSlang.Net.ComWrappers.Tools;

namespace ShaderSlang.Net.ComWrappers.Descriptions;

[NativeMarshalling(
    typeof(BidirectionalMarshaller<SpecializationArgument, Unmanaged.SpecializationArg>)
)]
public readonly record struct SpecializationArgument(
    Unmanaged.SpecializationArg.TypeKind Kind,
    TypeReflection Type
)
    : IMarshalsToNative<Unmanaged.SpecializationArg>,
        IMarshalsFromNative<SpecializationArgument, Unmanaged.SpecializationArg>
{
    unsafe Unmanaged.SpecializationArg IMarshalsToNative<Unmanaged.SpecializationArg>.AsNative(
        ref GrowingStackBuffer buffer
    ) =>
        new()
        {
            kind = Kind,
            Anonymous = new() { type = (Unmanaged.TypeReflection*)Type.Pointer },
        };

    public static unsafe SpecializationArgument CreateFromNative(
        Unmanaged.SpecializationArg unmanaged
    ) => new(unmanaged.kind, TypeReflection.CreateFromHandle((nint)unmanaged.type));
}
