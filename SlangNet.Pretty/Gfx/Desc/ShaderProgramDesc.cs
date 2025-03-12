using System;
using System.Runtime.InteropServices;
using Nito.Disposables;
using SlangNet.Internal;

namespace SlangNet.Gfx;

public record struct ShaderProgramDesc(
    ShaderProgramLinkingStyle LinkingStyle = ShaderProgramLinkingStyle.SingleProgram,
    ComponentType? GlobalScope = null,
    ComponentType[]? EntryPoints = null
) : IMarshalsToNative<IShaderProgram.ShaderProgramDesc>//, IMarshalsFromNative<ShaderProgramDesc, IShaderProgram.ShaderProgramDesc>
{
    public unsafe IDisposable AsNative(out IShaderProgram.ShaderProgramDesc native)
    {
        var disposables = new CollectionDisposable();
        
        native = new IShaderProgram.ShaderProgramDesc
        {
            linkingStyle = (IShaderProgram.LinkingStyle)LinkingStyle,
            slangGlobalScope = GlobalScope.AsNullablePtr(),
            entryPointCount = EntryPoints.CountIfNotNull(),
            slangEntryPoints = EntryPoints.ToPtrArray(disposables)
        };
        
        return disposables;
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