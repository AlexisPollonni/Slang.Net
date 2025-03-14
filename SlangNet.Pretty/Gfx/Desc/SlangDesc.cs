using System;
using System.Collections.Generic;
using Nito.Disposables;
using SlangNet.Internal;

namespace SlangNet.Gfx.Desc;

public record struct SlangDesc(
    GlobalSession? GlobalSession = null,
    MatrixLayoutMode DefaultMatrixLayoutMode =  MatrixLayoutMode.RowMajor,
    string[]? SearchPaths =  null,
    IReadOnlyList<PreprocessorMacroDesc>? PreprocessorMacros = null,
    string? TargetProfile = null,
    FloatingPointMode FloatingPointMode = FloatingPointMode.Default,
    OptimizationLevel OptimizationLevel =  default,
    TargetFlags TargetFlags = TargetFlags.GenerateSPIRVDirectly,
    LineDirectiveMode LineDirectiveMode = LineDirectiveMode.Default
    ) : IMarshalsToNative<IDevice.SlangDesc>, IMarshalsFromNative<SlangDesc, IDevice.SlangDesc>
{
    public readonly int GetNativeAllocSize()
    {
        return SysUnsafe.SizeOf<IDevice.SlangDesc>()
        + SearchPaths?.GetNativeAllocSize() ?? 0
        + PreprocessorMacros?.GetNativeAllocSize<PreprocessorMacroDesc, Unsafe.PreprocessorMacroDesc>() ?? 0
        + TargetProfile.GetNativeAllocSize();
    }

    public unsafe void AsNative(MarshallingAllocBuffer buffer, out IDevice.SlangDesc native)
    {        
        native = new()
        {
            slangGlobalSession = GlobalSession.AsNullablePtr(),
            defaultMatrixLayoutMode = DefaultMatrixLayoutMode,
            searchPaths = SearchPaths.MarshalToNative(buffer),
            searchPathCount = SearchPaths.CountIfNotNull(),
            preprocessorMacros = PreprocessorMacros.MarshalToNative<PreprocessorMacroDesc, Unsafe.PreprocessorMacroDesc>(buffer),
            preprocessorMacroCount = PreprocessorMacros.CountIfNotNull(),
            targetProfile = TargetProfile.MarshalToNative(buffer),
            floatingPointMode = FloatingPointMode,
            optimizationLevel = OptimizationLevel,
            targetFlags = (uint)TargetFlags,
            lineDirectiveMode = LineDirectiveMode
        };
    }

    public static unsafe void CreateFromNative(IDevice.SlangDesc native, out SlangDesc managed)
    {
        var searchPaths = InteropUtils.PtrToStringArray(native.searchPaths, native.searchPathCount);
        
        var preprocessorMacros = InteropUtils.MarshalArrayToManaged<PreprocessorMacroDesc, Unsafe.PreprocessorMacroDesc>(native.preprocessorMacros, native.preprocessorMacroCount);
        
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
