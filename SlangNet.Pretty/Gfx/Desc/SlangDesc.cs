using System;
using System.Collections.Generic;
using Nito.Disposables;
using SlangNet.Internal;

namespace SlangNet.Gfx.Desc;

public record struct SlangDesc(
    GlobalSession? GlobalSession,
    MatrixLayoutMode DefaultMatrixLayoutMode,
    string[]? SearchPaths,
    IReadOnlyList<PreprocessorMacroDesc>? PreprocessorMacros,
    string TargetProfile,
    FloatingPointMode FloatingPointMode,
    OptimizationLevel OptimizationLevel,
    TargetFlags TargetFlags,
    LineDirectiveMode LineDirectiveMode
    ) : IMarshalsToNative<IDevice.SlangDesc>, IMarshalsFromNative<SlangDesc, IDevice.SlangDesc>
{
    public unsafe IDisposable AsNative(out IDevice.SlangDesc native)
    {
        var disposables = new CollectionDisposable();

        native = new()
        {
            slangGlobalSession = GlobalSession.AsNullablePtr(),
            defaultMatrixLayoutMode = DefaultMatrixLayoutMode,
            searchPaths = SearchPaths.StringArrayToPtr(disposables),
            searchPathCount = SearchPaths.CountIfNotNull(),
            preprocessorMacros = PreprocessorMacros.MarshalArrayToNative<PreprocessorMacroDesc, Unsafe.PreprocessorMacroDesc>(disposables),
            preprocessorMacroCount = PreprocessorMacros.CountIfNotNull(),
            targetProfile = TargetProfile.StringToPtr(disposables),
            floatingPointMode = FloatingPointMode,
            optimizationLevel = OptimizationLevel,
            targetFlags = (uint)TargetFlags,
            lineDirectiveMode = LineDirectiveMode
        };
        
        return disposables;
    }

    public static unsafe void CreateFromNative(IDevice.SlangDesc native, out SlangDesc managed)
    {
        var searchPaths = InteropUtils.PtrToStringArray(native.searchPaths, native.searchPathCount);
        
        var preprocessorMacros = InteropUtils.AsMarshalableNativeArray<PreprocessorMacroDesc, Unsafe.PreprocessorMacroDesc>(native.preprocessorMacros, native.preprocessorMacroCount);
        
        var targetProfile = InteropUtils.PtrToStringUTF8(native.targetProfile) ?? string.Empty;
        
        managed = new(
            native.slangGlobalSession != null ? new GlobalSession(native.slangGlobalSession) : null,
            native.defaultMatrixLayoutMode,
            searchPaths,
            preprocessorMacros,
            targetProfile,
            native.floatingPointMode,
            native.optimizationLevel,
            (TargetFlags)native.targetFlags,
            native.lineDirectiveMode
        );
    }
}
