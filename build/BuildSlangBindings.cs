using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using ClangSharp;
using ClangSharp.Interop;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Serilog;
using Serilog.Events;
using static Nuke.Common.EnvironmentInfo;
using static ClangSharp.Interop.CXTranslationUnit_Flags;

public class BuildSlangBindings
{
    public required AbsolutePath SrcOutputDir { get; init; }
    public required AbsolutePath XmlOutputDir { get; init; }
    public required AbsolutePath TestsOutputDir { get; init; }
    public required AbsolutePath SlangRepoPath { get; init; }

    readonly AbsolutePath SlangHeaderPath;
    readonly AbsolutePath SlangDeprHeaderPath;

    public BuildSlangBindings()
    {
        SlangHeaderPath = SlangRepoPath / "include" / "slang.h";
        SlangDeprHeaderPath = SlangRepoPath / "include" / "slang-deprecated.h";
    }

    public void Build()
    {
        AbsolutePath[] files =
        [
            SlangHeaderPath
        ];

        var config = new BuildConfig
        {
            GeneratedTestsDir = TestsOutputDir,
            TraversalNames = [SlangHeaderPath, SlangDeprHeaderPath]
        };

        if (!IsWin) config.Options |= PInvokeGeneratorConfigurationOptions.GenerateUnixTypes;

        Log.Information("Generating CSharp bindings...");
        GenerateSlangBindings(files, SrcOutputDir, config);

        config.GeneratedTestsDir = null;
        Log.Information("Generating XML documentation files...");
        GenerateSlangBindings(files, XmlOutputDir, config, PInvokeGeneratorOutputMode.Xml);
    }
    
    
    private void GenerateSlangBindings(AbsolutePath[] files,
                                       AbsolutePath outputDir,
                                       in BuildConfig config,
                                       PInvokeGeneratorOutputMode mode = PInvokeGeneratorOutputMode.CSharp)
    {
        using var generator = new PInvokeGenerator(config.ToGeneratorConfiguration(outputDir, mode), OutputStreamFactory);

        // ReSharper disable BitwiseOperatorOnEnumWithoutFlags
        const CXTranslationUnit_Flags translationFlags = CXTranslationUnit_IncludeAttributedTypes
                                                         | CXTranslationUnit_VisitImplicitAttributes
                                                         | CXTranslationUnit_DetailedPreprocessingRecord;
        // ReSharper restore BitwiseOperatorOnEnumWithoutFlags

        foreach (var filePath in files)
        {
            var translationUnit
                = CreateTranslationUnitForFile(filePath, generator.IndexHandle, config.ClangCmdArgs, translationFlags);

            if (translationUnit is null)
            {
                Log.Warning("Skipping \'{FilePath}\' due to one or more errors listed above", filePath);
                continue;
            }

            var additionalRemapped = GetAdditionalRemappedNames(translationUnit);

            var remapDict = (SortedDictionary<string, string>)generator.Config.RemappedNames;

            foreach (var (before, after) in additionalRemapped) 
                remapDict.TryAdd(before, after);

            try
            {
                Log.Information("Processing \'{FilePath}\'", filePath);
                generator.GenerateBindings(translationUnit, filePath, config.ClangCmdArgs, translationFlags);
            }
            catch (Exception e)
            {
                Log.Error(e, "Failed to generate bindings for \'{FilePath}\'", filePath);
            }
        }
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
            Log.Error("Parsing failed for '{FilePath}' due to '{TranslationUnitError}'", filePath, translationUnitError);
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

        var translationUnit = TranslationUnit.GetOrCreate(handle);
        Debug.Assert(translationUnit is not null);

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
        var externCur = FindFirstChildOfKind(rootCursor, CXCursorKind.CXCursor_LinkageSpec);

        Debug.Assert(externCur is not null);

        var foundEnums = FindAllChildrenOfKind(externCur, CXCursorKind.CXCursor_EnumDecl)
                         .Cast<EnumDecl>()
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
                                  .Where(decl => decl.CursorKind is CXCursorKind.CXCursor_EnumConstantDecl)
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

    private Cursor? FindFirstChildOfKind(Cursor cursor, CXCursorKind kind, bool isFromMainFile = true)
    {
        var stack = new Stack<Cursor>([cursor]);

        while (stack.TryPop(out var currentCursor))
        {
            if (currentCursor.CursorKind == kind && currentCursor.Location.IsFromMainFile == isFromMainFile)
            {
                return currentCursor;
            }

            foreach (var c in currentCursor.CursorChildren) stack.Push(c);
        }

        return null;
    }

    private IReadOnlyList<Cursor> FindAllChildrenOfKind(Cursor cursor, CXCursorKind kind, bool isFromMainFile = true)
    {
        var stack = new Stack<Cursor>([cursor]);
        var foundCursors = new List<Cursor>();

        while (stack.TryPop(out var currentCursor))
        {
            if (currentCursor.CursorKind == kind && currentCursor.Location.IsFromMainFile == isFromMainFile)
            {
                foundCursors.Add(currentCursor);
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