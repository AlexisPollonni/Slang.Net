using System;
using System.Collections.Generic;
using SlangNet.Internal;

namespace SlangNet;

//TODO: Implement compiler option entries
public readonly record struct TargetDescription(CompileTarget Format = CompileTarget.TargetUnknown,
                                                ProfileID Profile = ProfileID.ProfileUnknown,
                                                TargetFlags Flags = TargetFlags.GenerateSPIRVDirectly,
                                                FloatingPointMode FloatingPointMode = FloatingPointMode.Default,
                                                LineDirectiveMode LineDirectiveMode = LineDirectiveMode.Default,
                                                bool ForceGlslScalarBufferLayout =  false)
    : IMarshalsToNative<TargetDesc>
{
    public unsafe int GetNativeAllocSize() => sizeof(TargetDesc);

    public unsafe void AsNative(ref MarshallingAllocBuffer _, out TargetDesc native)
    {
        native = new()
        {
            structureSize = (nuint)sizeof(TargetDesc),
            format = Format,
            profile = Profile,
            flags = (uint)Flags,
            floatingPointMode = FloatingPointMode,
            lineDirectiveMode = LineDirectiveMode,
            forceGLSLScalarBufferLayout = ForceGlslScalarBufferLayout,
        };
    }
}
