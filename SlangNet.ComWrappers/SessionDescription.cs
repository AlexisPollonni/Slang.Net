using System.Runtime.InteropServices.Marshalling;
using SlangNet.Bindings.Generated;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers;

[NativeMarshalling(typeof(SessionDescriptionMarshaller))]
public readonly record struct SessionDescription(TargetDescription[]? Targets = null,
                                                SessionFlags Flags = SessionFlags.None,
                                                MatrixLayoutMode DefaultMatrixLayoutMode = MatrixLayoutMode.RowMajor,
                                                string[]? SearchPaths = null,
                                                PreprocessorMacroDescription[]? PreprocessorMacros = null,
                                                IFileSystem? FileSystem = null,
                                                bool EnableEffectAnnotations = false,
                                                bool AllowGlslSyntax = false,
                                                CompilerOptionEntry[]? CompilerOptions = null);

public readonly record struct TargetDescription(CompileTarget Format = CompileTarget.TargetUnknown,
                                                ProfileID Profile = ProfileID.ProfileUnknown,
                                                TargetFlags Flags = 0,
                                                FloatingPointMode FloatingPointMode = FloatingPointMode.Default,
                                                LineDirectiveMode LineDirectiveMode = LineDirectiveMode.Default,
                                                bool ForceGlslScalarBufferLayout = false,
                                                CompilerOptionEntry[]? CompilerOptions = null);




public readonly record struct CompilerOptionEntry(
    CompilerOptionName Name,
    CompilerOptionValueKind Kind,
    int IntValue0,
    int IntValue1,
    string? StringValue0,
    string? StringValue1);

public readonly record struct PreprocessorMacroDescription(string Name, string Value);