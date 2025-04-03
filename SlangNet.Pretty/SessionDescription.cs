using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using SlangNet.Internal;

namespace SlangNet;

public sealed record SessionDescription(IReadOnlyList<TargetDescription> Targets,
                                        SessionFlags Flags = SessionFlags.None,
                                        MatrixLayoutMode DefaultMatrixLayoutMode = MatrixLayoutMode.RowMajor,
                                        IReadOnlyList<string>? SearchPaths = null,
                                        IReadOnlyList<PreprocessorMacroDesc>? PreprocessorMacros = null,
                                        bool EnableEffectAnnotations = false,
                                        bool AllowGlslSyntax = false) : IMarshalsToNative<SessionDesc>
{
    public unsafe int GetNativeAllocSize() => sizeof(SessionDesc) 
                                              + Targets.GetNativeAllocSize<TargetDescription, TargetDesc>()
                                              + SearchPaths.GetNativeAllocSize()
                                              + PreprocessorMacros.GetNativeAllocSize<PreprocessorMacroDesc, Unsafe.PreprocessorMacroDesc>();

    public unsafe void AsNative(ref MarshallingAllocBuffer buffer, out SessionDesc native)
    {
        native = new()
        {
            structureSize = (nuint)sizeof(SessionDesc),
            targets = Targets.MarshalToNative<TargetDescription, TargetDesc>(ref buffer),
            targetCount = Targets.Count,
            flags = (uint)Flags,
            defaultMatrixLayoutMode = DefaultMatrixLayoutMode,
            searchPaths = SearchPaths.MarshalToNative(ref buffer),
            searchPathCount = SearchPaths.CountIfNotNull(),
            preprocessorMacros
                = PreprocessorMacros.MarshalToNative<PreprocessorMacroDesc, Unsafe.PreprocessorMacroDesc>(ref buffer),
            preprocessorMacroCount = PreprocessorMacros.CountIfNotNull(),
            fileSystem = null, //TODO,
            enableEffectAnnotations = EnableEffectAnnotations,
            allowGLSLSyntax = AllowGlslSyntax,
            compilerOptionEntries = null, //TODO
            compilerOptionEntryCount = 0
        };
    }
}