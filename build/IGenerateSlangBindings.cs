using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using ClangSharp;
using ClangSharp.Interop;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Serilog;
using Serilog.Events;
using static ClangSharp.Interop.CXTranslationUnit_Flags;

public interface IGenerateSlangBindings : INukeBuild
{
    [Parameter]
    AbsolutePath SrcOutputDir => RootDirectory / "SlangNet.Bindings" / "Generated";

    [Parameter]
    AbsolutePath XmlOutputDir => RootDirectory / "SlangNet" / "GeneratedDoc";

    [Parameter]
    AbsolutePath TestsOutputDir => RootDirectory / "SlangNet.Tests" / "Generated";

    [Parameter]
    AbsolutePath SlangRepoPath => RootDirectory / "slang";

    AbsolutePath SlangHeaderPath => SlangRepoPath / "include" / "slang.h";
    AbsolutePath SlangGfxHeaderPath => SlangRepoPath / "include" / "slang-gfx.h";
    AbsolutePath SlangDeprHeaderPath => SlangRepoPath / "include" / "slang-deprecated.h";

    Target CleanSlangBindings =>
        _ => _
            .Executes(() =>
            {
                SrcOutputDir.CreateOrCleanDirectory();
                XmlOutputDir.CreateOrCleanDirectory();
                TestsOutputDir.CreateOrCleanDirectory();
            });

    Target GenerateSlangBindings =>
        _ => _
             .DependsOn(CleanSlangBindings)
             .Executes(Build);

    private void Build()
    {
        if (EnvironmentInfo.IsLinux)
        {
            var apt = ToolResolver.GetEnvironmentOrPathTool("apt");

            apt.Invoke("install libc++-dev libc++abi-dev", exitHandler: p =>
            {
                if (p.ExitCode != 0)
                    Log.Warning(
                        "Failed to install packages libc++-dev and libc++abi-dev, binding generation might not succeed. File not found errors might occur");
            });
        }

        var slangConfig = BuildConfig.SlangConfig;
        slangConfig.TraversalNames = [SlangDeprHeaderPath, SlangHeaderPath];
        
        var gfxConfig = BuildConfig.GfxConfig;
        gfxConfig.TraversalNames = [SlangGfxHeaderPath];


        using var ver = clang.getClangVersion();
        using var ver2 = clangsharp.getVersion();

        Log.Information("Generating CSharp bindings...");
        Log.Information("CLANG VERSION: {Version}", ver);
        Log.Information("CLANGSHARP VERSION: {Version}", ver2);
        
        
        var genFiles = Generate([SlangHeaderPath], SrcOutputDir, slangConfig);
        WriteFilesToDisk(genFiles);
        
        genFiles = Generate([SlangGfxHeaderPath], SrcOutputDir, gfxConfig);
        WriteFilesToDisk(genFiles);
        
        Log.Information("Generating XML documentation files...");
        genFiles = Generate([SlangHeaderPath], XmlOutputDir, slangConfig, PInvokeGeneratorOutputMode.Xml);
        WriteFilesToDisk(genFiles);
        
        genFiles = Generate([SlangGfxHeaderPath], XmlOutputDir, gfxConfig,  PInvokeGeneratorOutputMode.Xml);
        WriteFilesToDisk(genFiles);
    }

    private Dictionary<AbsolutePath, string> Generate(AbsolutePath[] files,
                                                      AbsolutePath outputDir,
                                                      BuildConfig config,
                                                      PInvokeGeneratorOutputMode mode = PInvokeGeneratorOutputMode.CSharp)
    {
        var outputStreamDictionary = new Dictionary<string, StreamToStringWrapper>();

        {
            using var generator = new PInvokeGenerator(
                config.ToGeneratorConfiguration(outputDir,
                                                mode is PInvokeGeneratorOutputMode.CSharp ? TestsOutputDir : null,
                                                mode), s =>
                {
                    var stringStream = new StreamToStringWrapper();

                    outputStreamDictionary.Add(s, stringStream);

                    return stringStream;
                });

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
                foreach (var (before, after) in additionalRemapped) remapDict.TryAdd(before, after);

                var additionalGuids = GetComStyleClassUuids(translationUnit);

                var withGuidsDict = (SortedDictionary<string, Guid>)generator.Config.WithGuids;
                foreach (var (typeName, guid) in additionalGuids) withGuidsDict.TryAdd(typeName, guid);

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

        return outputStreamDictionary
               .Select(pair => (AbsolutePath.Create(pair.Key), pair.Value.ToString().ReplaceLineEndings("\r\n")))
               .ToDictionary();
    }

    private void WriteFilesToDisk(IDictionary<AbsolutePath, string> outputFiles)
    {
        foreach (var (path, textBody) in outputFiles)
        {
            Log.Debug("Writing file \'{FilePath}\' to disk", path);

            path.WriteAllText(textBody, Encoding.Default, false);
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

                if (diagnostic.Severity is CXDiagnosticSeverity.CXDiagnostic_Error) isSkipping = true;
            }
        }

        if (isSkipping) return null;

        var translationUnit = TranslationUnit.GetOrCreate(handle).NotNull();

        return translationUnit;
    }

    private Dictionary<string, string> GetAdditionalRemappedNames(TranslationUnit translationUnit)
    {
        var rootCursor = translationUnit.TranslationUnitDecl;
        var externCursors = FindAllChildrenOfKind<LinkageSpecDecl>(rootCursor).NotNull().ToArray();

        return GetEnumAdditionalRemappedNames(externCursors)
               .Concat(GetDisambiguatedRemappedNames(rootCursor))
               .ToDictionary();
    }

    private IEnumerable<(string, string)> GetEnumAdditionalRemappedNames(IEnumerable<LinkageSpecDecl> linkageSpecDecls)
    {
        var foundEnums = linkageSpecDecls.SelectMany(FindAllChildrenOfKind<EnumDecl>)
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

        return remappedEnumNames.Concat(remappedEnumMembers);
    }

    private IEnumerable<(string, string)> GetDisambiguatedRemappedNames(TranslationUnitDecl translationUnit)
    {
        var gfxNamespace = FindAllChildrenOfKind<NamespaceDecl>(translationUnit)
                           .Where(decl => decl.Spelling == "gfx")
                           .ToArray();

        var comInterfaces = gfxNamespace.SelectMany(FindAllChildrenOfKind<RecordDecl>)
                                        .Where(decl => decl.IsClass && decl.Spelling.StartsWith('I'))
                                        .ToArray(); //Find all the COM interfaces

        var childStructs = comInterfaces
                           .SelectMany(FindAllChildrenOfKind<RecordDecl>)
                           .ToArray();

        var descStructs = childStructs
                          .Where(decl => decl.IsStruct && decl.Spelling == "Desc")
                          .ToArray();

        return descStructs
            .Select(decl =>
            {
                var qualifiedName = GetFullQualifiedNameFromCursor(decl);

                var parentInterfaceName = decl.SemanticParentCursor?.Spelling;

                var trimmedParentName = parentInterfaceName![1..];

                return (qualifiedName, $"{trimmedParentName}Desc");
            });
    }

    private Dictionary<string, Guid> GetComStyleClassUuids(TranslationUnit translationUnit)
    {
        var comStructs = FindAllChildrenOfKind<RecordDecl>(translationUnit.TranslationUnitDecl);

        var guidMethods = comStructs.SelectMany(FindAllChildrenOfKind<CXXMethodDecl>)
                                    .Where(m => m.Name == "getTypeGuid")
                                    .ToArray();

        var guids = guidMethods.Select(m => (m.Parent.NotNull()!.Name, GetGuidFromTypeGuidMethod(m))).ToDictionary();

        return guids;

        Guid GetGuidFromTypeGuidMethod(CXXMethodDecl method)
        {
            var l = FindAllChildrenOfKind<IntegerLiteral>(method)
                    .Select(l => l.Value)
                    .Reverse()
                    .ToArray();

            Assert.Count(l, 11, "Parsed interface type UUID invalid!");

            var guid = new Guid((uint)l[0],
                                (ushort)l[1],
                                (ushort)l[2],
                                (byte)l[3],
                                (byte)l[4],
                                (byte)l[5],
                                (byte)l[6],
                                (byte)l[7],
                                (byte)l[8],
                                (byte)l[9],
                                (byte)l[10]);

            return guid;
        }
    }

    private T? FindFirstChildOfKind<T>(Cursor cursor) where T : Cursor
    {
        return FindAllChildrenOfKind<T>(cursor).FirstOrDefault();
    }

    private IEnumerable<T> FindAllChildrenOfKind<T>(Cursor cursor) where T : Cursor
    {
        var stack = new Stack<Cursor>(cursor.CursorChildren);

        while (stack.TryPop(out var currentCursor))
        {
            if (currentCursor is T foundCursor && !currentCursor.Location.IsInSystemHeader)
            {
                yield return foundCursor;
                continue;
            }

            foreach (var c in currentCursor.CursorChildren) stack.Push(c);
        }
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