using ShaderSlang.Net.ComWrappers.Tools;

namespace ShaderSlang.Net.ComWrappers.Descriptions;

public readonly record struct PreprocessorMacroDescription(string Name, string Value)
    : IMarshalsToNative<Unmanaged.PreprocessorMacroDesc>, IMarshalsFromNative<PreprocessorMacroDescription, Unmanaged.PreprocessorMacroDesc>
{
    unsafe Unmanaged.PreprocessorMacroDesc IMarshalsToNative<Unmanaged.PreprocessorMacroDesc>.AsNative(ref GrowingStackBuffer buffer) =>
        new()
        {
            name = buffer.GetStringPtr(Name),
            value = buffer.GetStringPtr(Value)
        };

    public static unsafe PreprocessorMacroDescription CreateFromNative(Unmanaged.PreprocessorMacroDesc unmanaged) =>
        new(InteropUtils.PtrToStringUtf8(unmanaged.name)!, InteropUtils.PtrToStringUtf8(unmanaged.value)!);
}