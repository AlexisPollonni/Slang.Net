using System;
using Nito.Disposables;
using SlangNet.Internal;

namespace SlangNet.Gfx.Desc;

public readonly record struct PreprocessorMacroDesc(string Name, string Value) : IMarshalable<PreprocessorMacroDesc, Unsafe.PreprocessorMacroDesc>
{
    public IDisposable AsNative(out Unsafe.PreprocessorMacroDesc native)
    {
        var nameNative = new Utf8String(Name);
        var valueNative = new Utf8String(Value);

        native = new()
        {
            name = nameNative,
            value = valueNative,
        };
        
        return CollectionDisposable.Create(nameNative, valueNative);
    }

    public static unsafe PreprocessorMacroDesc CreateFromNative(Unsafe.PreprocessorMacroDesc native)
    {
        var name = InteropUtils.PtrToStringUTF8(native.name);
        var value = InteropUtils.PtrToStringUTF8(native.value);
        
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(value);
        
        return new(name, value);
    }
}