using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;

namespace SlangNet.ComWrappers;

internal static unsafe class ManagedToUnmanagedConverters
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Unmanaged.SessionDesc SessionDescConverter(in SessionDescription desc, ref GrowingStackBuffer buffer)
    {
        return new()
        {
            structureSize = (nuint)sizeof(Unmanaged.SessionDesc),
            targets = buffer.GetCollectionPtr(desc.Targets, TargetConverter, out var targetCount),
            targetCount = targetCount,
            flags = (uint)desc.Flags,
            defaultMatrixLayoutMode = desc.DefaultMatrixLayoutMode,
            searchPaths = buffer.GetCollectionPtr(desc.SearchPaths, out var searchPathCount),
            searchPathCount = searchPathCount,
            preprocessorMacros
                = buffer.GetCollectionPtr(desc.PreprocessorMacros,
                                          PreprocessorMacroConverter,
                                          out var preprocessorMacroCount),
            preprocessorMacroCount = preprocessorMacroCount,
            fileSystem
                = (Unmanaged.ISlangFileSystem*)ComInterfaceMarshaller<IFileSystem>.ConvertToUnmanaged(desc.FileSystem),
            enableEffectAnnotations = desc.EnableEffectAnnotations,
            allowGLSLSyntax = desc.AllowGlslSyntax,
            compilerOptionEntries
                = buffer.GetCollectionPtr(desc.CompilerOptions, CompilerOptionConverter, out var compilerOptionCount),
            compilerOptionEntryCount = compilerOptionCount
        };
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Unmanaged.TargetDesc TargetConverter(in TargetDescription managed, ref GrowingStackBuffer buffer)
    {
        return new()
        {
            structureSize = (nuint)sizeof(Unmanaged.TargetDesc),
            format = managed.Format,
            profile = managed.Profile,
            flags = (uint)managed.Flags,
            floatingPointMode = managed.FloatingPointMode,
            lineDirectiveMode = managed.LineDirectiveMode,
            forceGLSLScalarBufferLayout = managed.ForceGlslScalarBufferLayout,
            compilerOptionEntries = buffer.GetCollectionPtr(managed.CompilerOptions, CompilerOptionConverter, out var compilerOptionCount),
            compilerOptionEntryCount = compilerOptionCount,
        };
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Unmanaged.CompilerOptionEntry CompilerOptionConverter(in CompilerOptionEntry managed, ref GrowingStackBuffer buffer)
    {
        return new()
        {
            name = managed.Name,
            value = new()
            {
                kind = managed.Kind,
                intValue0 = managed.IntValue0,
                intValue1 = managed.IntValue1,
                stringValue0 = buffer.GetStringPtr(managed.StringValue0),
                stringValue1 = buffer.GetStringPtr(managed.StringValue1)
            }
        };
    }


    public static Unmanaged.PreprocessorMacroDesc PreprocessorMacroConverter(in PreprocessorMacroDescription managed, ref GrowingStackBuffer buffer)
    {
        return new()
        {
            name = buffer.GetStringPtr(managed.Name),
            value = buffer.GetStringPtr(managed.Value)
        };
    }
}