using System.Globalization;
using ClangSharp;
using ClangSharp.Interop;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Serilog;
using Serilog.Events;
using static ClangSharp.Interop.CXTranslationUnit_Flags;

public interface IGenerateSlangBindings : INukeBuild
{
    [Parameter] AbsolutePath SrcOutputDir => RootDirectory / "SlangNet.Bindings" / "Generated";

    [Parameter] AbsolutePath XmlOutputDir => RootDirectory / "SlangNet" / "GeneratedDoc";

    [Parameter] AbsolutePath TestsOutputDir => RootDirectory / "SlangNet.Tests" / "Generated";

    [Parameter] AbsolutePath SlangRepoPath => RootDirectory / "slang";

    AbsolutePath SlangHeaderPath => SlangRepoPath / "include" / "slang.h";
    AbsolutePath SlangDeprHeaderPath => SlangRepoPath / "include" / "slang-deprecated.h";

    Target CleanSlangBindings => _ => _
        .Executes(() =>
        {
            SrcOutputDir.CreateOrCleanDirectory();
            XmlOutputDir.CreateOrCleanDirectory();
            TestsOutputDir.CreateOrCleanDirectory();
        });

    Target GenerateSlangBindings => _ => _
        .DependsOn(CleanSlangBindings)
        .Executes(Build);

    private void Build()
    {
        AbsolutePath[] files =
        [
            SlangHeaderPath
        ];

        var config = BuildConfig.SlangConfig;
        config.TraversalNames = [SlangHeaderPath, SlangDeprHeaderPath];

        Log.Information("Generating CSharp bindings...");
        Generate(files, SrcOutputDir, config);

        Log.Information("Generating XML documentation files...");
        Generate(files, XmlOutputDir, config, PInvokeGeneratorOutputMode.Xml);
    }

    private void Generate(AbsolutePath[] files,
        AbsolutePath outputDir,
        BuildConfig config,
        PInvokeGeneratorOutputMode mode = PInvokeGeneratorOutputMode.CSharp)
    {
        using var generator = new PInvokeGenerator(
            config.ToGeneratorConfiguration(outputDir, mode is PInvokeGeneratorOutputMode.CSharp ? TestsOutputDir : null,
                mode), OutputStreamFactory);

        // ReSharper disable BitwiseOperatorOnEnumWithoutFlags
        const CXTranslationUnit_Flags translationFlags = CXTranslationUnit_IncludeAttributedTypes
                                                         | CXTranslationUnit_VisitImplicitAttributes
                                                         | CXTranslationUnit_DetailedPreprocessingRecord;
        // ReSharper restore BitwiseOperatorOnEnumWithoutFlags
        var clangCmdArgs = config.GetClangCmdLineArgsForConfig();

        var error = false;
        foreach (var filePath in files)
        {
            var translationUnit
                = CreateTranslationUnitForFile(filePath, generator.IndexHandle, clangCmdArgs.ToArray(),
                    translationFlags);

            if (translationUnit is null)
            {
                Log.Warning("Skipping \'{FilePath}\' due to one or more errors listed above", filePath);
                error = true;
                continue;
            }

            var additionalRemapped = GetAdditionalRemappedNames(translationUnit);

            var remapDict = (SortedDictionary<string, string>)generator.Config.RemappedNames;

            foreach (var (before, after) in additionalRemapped)
                remapDict.TryAdd(before, after);

            try
            {
                Log.Information("Processing \'{FilePath}\'", filePath);
                generator.GenerateBindings(translationUnit, filePath, clangCmdArgs.ToArray(),
                    translationFlags);
            }
            catch (Exception e)
            {
                Log.Error(e, "Failed to generate bindings for \'{FilePath}\'", filePath);
                error = true;
            }
        }

        if (error) Assert.Fail("Bindings Generation failed, see logs for details");
    }

    private TranslationUnit? CreateTranslationUnitForFile(AbsolutePath filePath,
        CXIndex index,
        ReadOnlySpan<string> clangCmdArgs,
        CXTranslationUnit_Flags flags)
    {
        var translationUnitError = CXTranslationUnit.TryParse(index, filePath,
            clangCmdArgs, [], flags,
            out var handle);

        if (translationUnitError != CXErrorCode.CXError_Success)
        {
            Log.Error("Parsing failed for '{FilePath}' due to '{TranslationUnitError}'", filePath,
                translationUnitError);
            return null;
        }

        var isSkipping = false;
        if (handle.NumDiagnostics != 0)
        {
            Log.Information("Diagnostics for '{FilePath}':", filePath);

            for (uint i = 0; i < handle.NumDiagnostics; ++i)
            {
                using var diagnostic = handle.GetDiagnostic(i);

                var diagStr = diagnostic.Format(CXDiagnostic.DefaultDisplayOptions).ToString();

                var level = diagnostic.Severity switch
                {
                    CXDiagnosticSeverity.CXDiagnostic_Ignored => LogEventLevel.Debug,
                    CXDiagnosticSeverity.CXDiagnostic_Note => LogEventLevel.Information,
                    CXDiagnosticSeverity.CXDiagnostic_Warning => LogEventLevel.Warning,
                    CXDiagnosticSeverity.CXDiagnostic_Error => LogEventLevel.Error,
                    CXDiagnosticSeverity.CXDiagnostic_Fatal => LogEventLevel.Fatal,
                    _ => throw new ArgumentOutOfRangeException()
                };

                Log.Write(level, "#{Index} : {Diagnostic}", i, diagStr);

                if (diagnostic.Severity is CXDiagnosticSeverity.CXDiagnostic_Error
                    or CXDiagnosticSeverity.CXDiagnostic_Warning) isSkipping = true;
            }
        }

        if (isSkipping) return null;

        var translationUnit = TranslationUnit.GetOrCreate(handle).NotNull();

        return translationUnit;
    }

    private FileStream OutputStreamFactory(string arg)
    {
        var p = AbsolutePath.Create(arg);
        p.Parent.CreateDirectory();
        var s = new FileStream(p, FileMode.Create);

        Log.Debug("Writing file \'{FilePath}\' to disk", p);
        return s;
    }

    private Dictionary<string, string> GetAdditionalRemappedNames(TranslationUnit translationUnit)
    {
        var rootCursor = translationUnit.TranslationUnitDecl;
        var externCur = FindFirstChildOfKind<LinkageSpecDecl>(rootCursor).NotNull();

        var foundEnums = FindAllChildrenOfKind<EnumDecl>(externCur)
            .Where(decl => decl.Spelling.StartsWith("Slang"))
            .ToArray();

        var remappedEnumNames = foundEnums
            .Select(decl =>
            {
                var qualifiedName = GetFullQualifiedNameFromCursor(decl);
                var formatedName = decl.Spelling.TrimStart("Slang");

                return (qualifiedName, formatedName);
            });

        var textInfo = new CultureInfo("en-US", false).TextInfo;

        var remappedEnumMembers = foundEnums
            .SelectMany(decl => decl.CursorChildren)
            .Where(decl => decl is EnumConstantDecl)
            .Cast<EnumConstantDecl>()
            .Select(decl =>
            {
                var qualifiedName = GetFullQualifiedNameFromCursor(decl);

                var parentEnumName = decl.SemanticParentCursor?.Spelling;

                var prefixToTrim = parentEnumName.SplitCamelHumps()
                    .Select(s => s.ToUpperInvariant())
                    .JoinUnderscore() + '_';

                var trimmed = decl.Spelling.TrimStart(prefixToTrim).TrimStart("SLANG_");

                var pascalCaseTrimmed = string.Concat(trimmed
                    .Split(
                        '_',
                        StringSplitOptions.TrimEntries |
                        StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => textInfo.ToTitleCase(
                        s.ToLowerInvariant())));

                return (qualifiedName, pascalCaseTrimmed);
            });

        return remappedEnumNames.Concat(remappedEnumMembers).ToDictionary();
    }

    private T? FindFirstChildOfKind<T>(Cursor cursor, bool isFromMainFile = true) where T : Cursor
    {
        var stack = new Stack<Cursor>([cursor]);

        while (stack.TryPop(out var currentCursor))
        {
            if (currentCursor is T foundCursor && currentCursor.Location.IsFromMainFile == isFromMainFile)
            {
                return foundCursor;
            }

            foreach (var c in currentCursor.CursorChildren) stack.Push(c);
        }

        return null;
    }

    private IReadOnlyList<T> FindAllChildrenOfKind<T>(Cursor cursor, bool isFromMainFile = true) where T : Cursor
    {
        var stack = new Stack<Cursor>([cursor]);
        var foundCursors = new List<T>();

        while (stack.TryPop(out var currentCursor))
        {
            if (currentCursor is T foundCursor && currentCursor.Location.IsFromMainFile == isFromMainFile)
            {
                foundCursors.Add(foundCursor);
                continue;
            }

            foreach (var c in currentCursor.CursorChildren) stack.Push(c);
        }

        return foundCursors;
    }

    private string GetFullQualifiedNameFromCursor(Cursor cursor)
    {
        var nameParts = new Stack<string>();

        var currentCursor = cursor;

        while (currentCursor is not null && currentCursor.CursorKind != CXCursorKind.CXCursor_TranslationUnit)
        {
            if (!currentCursor.Spelling.IsNullOrWhiteSpace()) nameParts.Push(currentCursor.Spelling);

            currentCursor = currentCursor.SemanticParentCursor;
        }

        return string.Join("::", nameParts);
    }
}