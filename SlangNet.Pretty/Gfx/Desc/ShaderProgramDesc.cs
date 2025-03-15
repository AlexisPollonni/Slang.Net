using System;
using System.Runtime.InteropServices;
using Nito.Disposables;
using SlangNet.Internal;

namespace SlangNet.Gfx;

public record struct ShaderProgramDesc(
    IShaderProgram.LinkingStyle LinkingStyle = IShaderProgram.LinkingStyle.SingleProgram,
    ComponentType? GlobalScope = null,
    ComponentType[]? EntryPoints = null
) : IMarshalsToNative<IShaderProgram.ShaderProgramDesc>//, IMarshalsFromNative<ShaderProgramDesc, IShaderProgram.ShaderProgramDesc>
{
    public readonly int GetNativeAllocSize()
    {
        return SysUnsafe.SizeOf<IShaderProgram.ShaderProgramDesc>()
            + SysUnsafe.SizeOf<nint>() * (EntryPoints?.Length ?? 0);
    }

    public unsafe void AsNative(ref MarshallingAllocBuffer buffer, out IShaderProgram.ShaderProgramDesc native)
    {
        native = new IShaderProgram.ShaderProgramDesc
        {
            linkingStyle = LinkingStyle,
            slangGlobalScope = GlobalScope.AsNullablePtr(),
            entryPointCount = EntryPoints.CountIfNotNull(),
            slangEntryPoints = EntryPoints.MarshalToNative(ref buffer)
        };
    }
    
    // This method is not needed for the example, so we'll comment it out for now
    /*
    public static unsafe ShaderProgramDesc CreateFromNative(IShaderProgram.ShaderProgramDesc native)
    {
        ComponentType? globalScope = null;
        if (native.slangGlobalScope != null)
        {
            globalScope = new ComponentType(native.slangGlobalScope);
        }
        
        ComponentType[]? entryPoints = null;
        if (native.entryPointCount > 0 && native.slangEntryPoints != null)
        {
            entryPoints = new ComponentType[native.entryPointCount];
            for (int i = 0; i < native.entryPointCount; i++)
            {
                entryPoints[i] = new ComponentType(native.slangEntryPoints[i]);
            }
        }
        
        return new ShaderProgramDesc(
            (ShaderProgramLinkingStyle)native.linkingStyle,
            globalScope,
            entryPoints
        );
    }
    */
} 