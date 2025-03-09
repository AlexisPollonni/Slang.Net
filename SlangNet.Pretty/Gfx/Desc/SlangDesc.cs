using System;
using Nito.Disposables;
using SlangNet.Internal;

namespace SlangNet.Gfx.Desc;

public record struct SlangDesc(
    GlobalSession? GlobalSession,
    MatrixLayoutMode DefaultMatrixLayoutMode,
    string[] SearchPaths,
    PreprocessorMacroDesc[]? PreprocessorMacros,
    string TargetProfile,
    FloatingPointMode FloatingPointMode,
    OptimizationLevel OptimizationLevel,
    TargetFlags TargetFlags,
    LineDirectiveMode LineDirectiveMode
    ) : IMarshalable<SlangDesc, IDevice.SlangDesc>
{
    public unsafe IDisposable AsNative(out IDevice.SlangDesc native)
    {
        var disposables = new CollectionDisposable();
        
        var searchPaths = new Utf8StringArray(SearchPaths).DisposeWith(disposables);
        
        MarshalableNativeArray<PreprocessorMacroDesc, Unsafe.PreprocessorMacroDesc>? preprocessorMacros = null;
        if (PreprocessorMacros != null && PreprocessorMacros.Length > 0)
        {
            preprocessorMacros = new MarshalableNativeArray<PreprocessorMacroDesc, Unsafe.PreprocessorMacroDesc>(PreprocessorMacros)
            .DisposeWith(disposables)   ;
        }
        
        var targetProfileUtf8 = new Utf8String(TargetProfile).DisposeWith(disposables);

        native = new()
        {
            slangGlobalSession = GlobalSession is not null ? GlobalSession.Pointer : null,
            defaultMatrixLayoutMode = DefaultMatrixLayoutMode,
            searchPaths = searchPaths.Memory,
            searchPathCount = searchPaths.Count,
            preprocessorMacros = preprocessorMacros != null ? preprocessorMacros.AsPtr() : null,
            preprocessorMacroCount = preprocessorMacros != null ? (int)PreprocessorMacros!.Length : 0,
            targetProfile = targetProfileUtf8,
            floatingPointMode = FloatingPointMode,
            optimizationLevel = OptimizationLevel,
            targetFlags = (uint)TargetFlags,
            lineDirectiveMode = LineDirectiveMode
        };
        
        return disposables;
    }

    public static unsafe SlangDesc CreateFromNative(IDevice.SlangDesc native)
    {
        var searchPaths = new string[native.searchPathCount];
        for (int i = 0; i < native.searchPathCount; i++)
        {
            searchPaths[i] = InteropUtils.PtrToStringUTF8(native.searchPaths[i])!;
        }
        
        PreprocessorMacroDesc[]? preprocessorMacros = null;
        if (native.preprocessorMacroCount > 0 && native.preprocessorMacros != null)
        {
            preprocessorMacros = new PreprocessorMacroDesc[native.preprocessorMacroCount];
            for (int i = 0; i < native.preprocessorMacroCount; i++)
            {
                preprocessorMacros[i] = PreprocessorMacroDesc.CreateFromNative(native.preprocessorMacros[i]);
            }
        }
        
        var targetProfile = InteropUtils.PtrToStringUTF8(native.targetProfile) ?? string.Empty;
        
        return new(
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
