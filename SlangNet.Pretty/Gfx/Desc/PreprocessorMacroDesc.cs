using System;
using Nito.Disposables;
using SlangNet.Internal;

namespace SlangNet.Gfx.Desc;

public readonly record struct PreprocessorMacroDesc(string Name, string Value) : 
    IMarshalsToNative<Unsafe.PreprocessorMacroDesc>, IMarshalsFromNative<PreprocessorMacroDesc, Unsafe.PreprocessorMacroDesc>
{
    public readonly int GetNativeAllocSize()
    {
        return Name.GetNativeAllocSize() + Value.GetNativeAllocSize();
    }

    public unsafe void AsNative(ref MarshallingAllocBuffer buffer, out Unsafe.PreprocessorMacroDesc native)
    {
        native = new()
        {
            name = Name.MarshalToNative(ref buffer),
            value = Value.MarshalToNative(ref buffer),
        };
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