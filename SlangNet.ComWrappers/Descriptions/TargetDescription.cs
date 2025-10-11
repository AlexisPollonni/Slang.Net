using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers.Descriptions;

public readonly record struct TargetDescription(
    Unmanaged.CompileTarget Format = Unmanaged.CompileTarget.TargetUnknown,
    Unmanaged.ProfileID Profile = Unmanaged.ProfileID.Unknown,
    TargetFlags Flags = 0,
    Unmanaged.FloatingPointMode FloatingPointMode = Unmanaged.FloatingPointMode.Default,
    Unmanaged.LineDirectiveMode LineDirectiveMode = Unmanaged.LineDirectiveMode.Default,
    bool ForceGlslScalarBufferLayout = false,
    CompilerOptionEntry[]? CompilerOptions = null)
    : IMarshalsToNative<Unmanaged.TargetDesc>, IMarshalsFromNative<TargetDescription, Unmanaged.TargetDesc>
{
    unsafe Unmanaged.TargetDesc IMarshalsToNative<Unmanaged.TargetDesc>.AsNative(ref GrowingStackBuffer buffer) =>
        new()
        {
            structureSize = (nuint)sizeof(Unmanaged.TargetDesc),
            format = Format,
            profile = Profile,
            flags = (uint)Flags,
            floatingPointMode = FloatingPointMode,
            lineDirectiveMode = LineDirectiveMode,
            forceGLSLScalarBufferLayout = ForceGlslScalarBufferLayout,
            compilerOptionEntries = buffer.GetCollectionPtr<CompilerOptionEntry, Unmanaged.CompilerOptionEntry>(CompilerOptions, out var compilerOptionCount),
            compilerOptionEntryCount = compilerOptionCount,
        };

    public static unsafe TargetDescription CreateFromNative(Unmanaged.TargetDesc unmanaged) =>
        new(unmanaged.format,
            unmanaged.profile,
            (TargetFlags)unmanaged.flags,
            unmanaged.floatingPointMode,
            unmanaged.lineDirectiveMode,
            unmanaged.forceGLSLScalarBufferLayout,
            InteropUtils.PtrToManagedMarshal<CompilerOptionEntry, Unmanaged.CompilerOptionEntry>(
                unmanaged.compilerOptionEntries,
                (int)unmanaged.compilerOptionEntryCount));
}