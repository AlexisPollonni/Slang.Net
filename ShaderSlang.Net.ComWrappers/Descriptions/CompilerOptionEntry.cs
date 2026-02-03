using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.ComWrappers.Tools;

namespace ShaderSlang.Net.ComWrappers.Descriptions;

[NativeMarshalling(
    typeof(BidirectionalMarshaller<CompilerOptionEntry, Unmanaged.CompilerOptionEntry>)
)]
public readonly record struct CompilerOptionEntry(
    Unmanaged.CompilerOptionName Name,
    Unmanaged.CompilerOptionValueKind Kind,
    int IntValue0,
    int IntValue1,
    string? StringValue0,
    string? StringValue1
)
    : IMarshalsToNative<Unmanaged.CompilerOptionEntry>,
        IMarshalsFromNative<CompilerOptionEntry, Unmanaged.CompilerOptionEntry>
{
    unsafe Unmanaged.CompilerOptionEntry IMarshalsToNative<Unmanaged.CompilerOptionEntry>.AsNative(
        ref GrowingStackBuffer buffer
    ) =>
        new()
        {
            name = Name,
            value = new()
            {
                kind = Kind,
                intValue0 = IntValue0,
                intValue1 = IntValue1,
                stringValue0 = buffer.GetStringPtr(StringValue0),
                stringValue1 = buffer.GetStringPtr(StringValue1),
            },
        };

    public static unsafe CompilerOptionEntry CreateFromNative(
        Unmanaged.CompilerOptionEntry unmanaged
    ) =>
        new(
            unmanaged.name,
            unmanaged.value.kind,
            unmanaged.value.intValue0,
            unmanaged.value.intValue1,
            InteropUtils.PtrToStringUtf8(unmanaged.value.stringValue0),
            InteropUtils.PtrToStringUtf8(unmanaged.value.stringValue1)
        );
}
