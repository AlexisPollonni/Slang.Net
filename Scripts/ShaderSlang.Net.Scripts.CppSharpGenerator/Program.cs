// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices.Marshalling;
using ConsoleAppFramework;
using CppSharp;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging.Console;
using ShaderSlang.Net.Scripts.CppSharpGenerator;
using ShaderSlang.Net.Scripts.Shared;
using Shouldly;
using TruePath;
using TruePath.SystemIo;

#if DEBUG
Diagnostics.Level = DiagnosticKind.Debug;
#endif

var hostBuilder = ConsoleHost.Create(args);

hostBuilder
    .Logging.AddConsole(options => options.FormatterName = "indented")
    .AddConsoleFormatter<IndentedConsoleFormatter, SimpleConsoleFormatterOptions>()
    .SetMinimumLevel(LogLevel.Debug);

var app = hostBuilder.ToConsoleAppBuilder();

await app.RunAsync(args);

[RegisterCommands]
internal sealed class CliBindingsGenerator(ILogger<CliBindingsGenerator> logger)
{
    [Command("")]
    public void GenerateBindings([Argument] string slangRepoPath, [Argument] string outputDirPath)
    {
        Diagnostics.Implementation = new LoggerDiagnostics(logger);

        var slangRepo = new LocalPath(slangRepoPath).ResolveToCurrentDirectory();
        var outputDir = new LocalPath(outputDirPath).ResolveToCurrentDirectory();

        slangRepo
            .ExistsDirectory()
            .ShouldBeTrue($"Slang repository path does not exist: {slangRepo}");
        outputDir
            .ExistsDirectory()
            .ShouldBeTrue($"Output directory path does not exist: {outputDir}");

        ConsoleDriver.Run(new SlangLibrary(slangRepo, outputDir));
    }
}

internal sealed partial class LoggerDiagnostics(ILogger logger) : IDiagnostics
{
    public DiagnosticKind Level { get; set; }

    private readonly Stack<int> _indentStack = new();
    private int _currentIndentLevel;

    public void Emit(DiagnosticInfo info)
    {
        var level = info.Kind switch
        {
            DiagnosticKind.Debug => LogLevel.Debug,
            DiagnosticKind.Message => LogLevel.Information,
            DiagnosticKind.Warning => LogLevel.Warning,
            DiagnosticKind.Error => LogLevel.Error,
            _ => throw new ArgumentOutOfRangeException(),
        };

        LogIndentCompilerMessage(
            level,
            info.Message,
            logger.IsEnabled(level)
                ? new(_currentIndentLevel, info.File, info.Line, info.Column)
                : null
        );
    }

    public void PushIndent(int level = 4)
    {
        _currentIndentLevel += level;
        _indentStack.Push(level);
    }

    public void PopIndent()
    {
        if (!_indentStack.TryPop(out var poppedIndent))
            return;

        _currentIndentLevel -= poppedIndent;
    }

    [LoggerMessage("{CompilerMessage}")]
    partial void LogIndentCompilerMessage(
        LogLevel level,
        string compilerMessage,
        [LogProperties(OmitReferenceName = true)] IndentedCompilerLogContext? context
    );

    internal sealed record IndentedCompilerLogContext(
        int IndentLevel,
        string FileName,
        int Line,
        int Column
    );
}

public sealed class IndentedConsoleFormatter() : ConsoleFormatter("indented")
{
    public override void Write<TState>(
        in LogEntry<TState> logEntry,
        IExternalScopeProvider? scopeProvider,
        TextWriter textWriter
    )
    {
        var message = logEntry.Formatter(logEntry.State, logEntry.Exception);

        // Extract properties from state
        var indentLevel = 0;

        if (logEntry.State is IReadOnlyList<KeyValuePair<string, object?>> stateList)
        {
            // this is not particularly efficient, but for a console app will be enough
            indentLevel = stateList
                .Where(kvp =>
                    kvp.Key == nameof(LoggerDiagnostics.IndentedCompilerLogContext.IndentLevel)
                )
                .Select(kvp => kvp.Value)
                .OfType<int>()
                .FirstOrDefault(0);
        }

        var indent = new string(' ', indentLevel);
        textWriter.WriteLine($"{indent}{message}");

        if (logEntry.Exception != null)
            textWriter.WriteLine($"{indent}{logEntry.Exception}");
    }
}
