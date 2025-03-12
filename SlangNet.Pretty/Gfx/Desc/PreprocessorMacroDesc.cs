using System;
using Nito.Disposables;
using SlangNet.Internal;

namespace SlangNet.Gfx.Desc;

public readonly record struct PreprocessorMacroDesc(string Name, string Value) : 
    IMarshalsToNative<Unsafe.PreprocessorMacroDesc>, IMarshalsFromNative<PreprocessorMacroDesc, Unsafe.PreprocessorMacroDesc>
{
    public unsafe IDisposable AsNative(out Unsafe.PreprocessorMacroDesc native)
    {
        var disposables = new CollectionDisposable();

        native = new()
        {
            name = Name.StringToPtr(disposables),
            value = Value.StringToPtr(disposables),
        };
        
        return disposables;
    }

    public static unsafe void CreateFromNative(Unsafe.PreprocessorMacroDesc native, out PreprocessorMacroDesc managed)
    {
        var name = InteropUtils.PtrToStringUTF8(native.name);
        var value = InteropUtils.PtrToStringUTF8(native.value);
        
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(value);
        
        managed = new(name, value);
    }
}