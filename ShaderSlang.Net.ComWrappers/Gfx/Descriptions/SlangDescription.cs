using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.Bindings.Enums;
using ShaderSlang.Net.ComWrappers.Descriptions;
using ShaderSlang.Net.ComWrappers.Interfaces;
using ShaderSlang.Net.ComWrappers.Tools;

namespace ShaderSlang.Net.ComWrappers.Gfx.Descriptions;

[NativeMarshalling(
    typeof(MarshalableMarshaller.Bidirectional<SlangDescription, Unmanaged.IDevice.SlangDesc>)
)]
public readonly record struct SlangDescription(
    IGlobalSession? GlobalSession = null,
    Unmanaged.MatrixLayoutMode DefaultMatrixLayoutMode = Unmanaged.MatrixLayoutMode.RowMajor,
    string[]? SearchPaths = null,
    IReadOnlyList<PreprocessorMacroDescription>? PreprocessorMacros = null,
    string? TargetProfile = null,
    Unmanaged.FloatingPointMode FloatingPointMode = Unmanaged.FloatingPointMode.Default,
    Unmanaged.OptimizationLevel OptimizationLevel = default,
    TargetFlags TargetFlags = TargetFlags.GenerateSPIRVDirectly,
    Unmanaged.LineDirectiveMode LineDirectiveMode = Unmanaged.LineDirectiveMode.Default
)
    : IMarshalsToNative<Unmanaged.IDevice.SlangDesc>,
        IMarshalsFromNative<SlangDescription, Unmanaged.IDevice.SlangDesc>,
        IFreeAfterMarshal<Unmanaged.IDevice.SlangDesc>
{
    unsafe Unmanaged.IDevice.SlangDesc IMarshalsToNative<Unmanaged.IDevice.SlangDesc>.AsNative(
        ref GrowingStackBuffer buffer
    ) =>
        new()
        {
            slangGlobalSession = GlobalSession.InterfaceToPtr<
                IGlobalSession,
                Unmanaged.IGlobalSession
            >(),
            defaultMatrixLayoutMode = DefaultMatrixLayoutMode,
            searchPaths = buffer.GetCollectionPtr(SearchPaths, out var searchPathCount),
            searchPathCount = (int)searchPathCount,
            preprocessorMacros = buffer.GetCollectionPtr<
                PreprocessorMacroDescription,
                Unmanaged.PreprocessorMacroDesc
            >(PreprocessorMacros, out var macroCount),
            preprocessorMacroCount = (int)macroCount,
            targetProfile = buffer.GetStringPtr(TargetProfile),
            floatingPointMode = FloatingPointMode,
            optimizationLevel = OptimizationLevel,
            targetFlags = (uint)TargetFlags,
            lineDirectiveMode = LineDirectiveMode,
        };

    public static unsafe SlangDescription CreateFromNative(Unmanaged.IDevice.SlangDesc unmanaged) =>
        new(
            ComInterfaceMarshaller<IGlobalSession>.ConvertToManaged(unmanaged.slangGlobalSession),
            unmanaged.defaultMatrixLayoutMode,
            InteropUtils.PtrToStringArray(unmanaged.searchPaths, unmanaged.searchPathCount),
            InteropUtils.PtrToManagedMarshal<
                PreprocessorMacroDescription,
                Unmanaged.PreprocessorMacroDesc
            >(unmanaged.preprocessorMacros, unmanaged.preprocessorMacroCount),
            InteropUtils.PtrToStringUtf8(unmanaged.targetProfile),
            unmanaged.floatingPointMode,
            unmanaged.optimizationLevel,
            (TargetFlags)unmanaged.targetFlags,
            unmanaged.lineDirectiveMode
        );

    public unsafe void Free(Unmanaged.IDevice.SlangDesc* unmanaged)
    {
        ComInterfaceMarshaller<IGlobalSession>.Free(unmanaged->slangGlobalSession);
    }
}
