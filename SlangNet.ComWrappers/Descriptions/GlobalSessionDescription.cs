using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers.Descriptions;

[NativeMarshalling(
    typeof(MarshalableMarshaller.ManagedToUnmanaged<GlobalSessionDescription, Unmanaged.SlangGlobalSessionDesc>))]
public readonly unsafe record struct GlobalSessionDescription(
    uint ApiVersion,
    Unmanaged.SlangLanguageVersion LanguageVersion = Unmanaged.SlangLanguageVersion.SLANG_LANGUAGE_VERSION_2025,
    bool EnableGlsl = false) : IMarshalsToNative<Unmanaged.SlangGlobalSessionDesc>
{
    Unmanaged.SlangGlobalSessionDesc IMarshalsToNative<Unmanaged.SlangGlobalSessionDesc>.AsNative(
        ref GrowingStackBuffer buffer) =>
        new()
        {
            structureSize = (uint)sizeof(Unmanaged.SlangGlobalSessionDesc),
            apiVersion = ApiVersion,
            languageVersion = (uint)LanguageVersion,
            enableGLSL = EnableGlsl
        };
}