using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using SlangNet.ComWrappers.Interfaces;
using SlangNet.ComWrappers.Tools.Extensions;

#pragma warning disable CA2254

namespace SlangNet.Example.Shared;

file static class StaticLoggerFactory
{
    public static readonly ILoggerFactory Instance = LoggerFactory.Create(builder => builder.AddConsole());
}

public static class SharedLogger
{
    private static readonly ILogger Logger = StaticLoggerFactory.Instance.CreateLogger("");
    
    public static void LogDiagnostics(IBlob? blobDiagnostics, LogLevel logLevel = LogLevel.Debug)
    {
        Logger.LogDiagnostics(blobDiagnostics, logLevel);
    }
    
    // ReSharper disable TemplateIsNotCompileTimeConstantProblem
    public static void Log(LogLevel level, [StructuredMessageTemplate] string template, params object?[] args) => Logger.Log(level, template, args);
    public static void LogTrace([StructuredMessageTemplate] string template, params object?[] args) => Logger.LogTrace(template, args);
    public static void LogDebug([StructuredMessageTemplate] string template, params object?[] args) => Logger.LogDebug(template, args);
    public static void LogInformation([StructuredMessageTemplate] string template, params object?[] args) => Logger.LogInformation(template, args);
    public static void LogWarning([StructuredMessageTemplate] string template, params object?[] args) => Logger.LogWarning(template, args);
    public static void LogError([StructuredMessageTemplate] string template, params object?[] args) => Logger.LogError(template, args);
    public static void LogCritical([StructuredMessageTemplate] string template, params object?[] args) => Logger.LogCritical(template, args);
    // ReSharper restore TemplateIsNotCompileTimeConstantProblem
}
public static class SharedLogger<T>
{
    private static readonly ILogger<T> Logger = StaticLoggerFactory.Instance.CreateLogger<T>();

    public static void LogDiagnostics(IBlob? blobDiagnostics, LogLevel logLevel = LogLevel.Debug)
    {
        Logger.LogDiagnostics(blobDiagnostics, logLevel);
    }

    public static void LogDiagnostics(string? diagnostics, LogLevel logLevel = LogLevel.Debug)
    {
        Logger.LogDiagnostics(diagnostics, logLevel);
    }
    
    // ReSharper disable TemplateIsNotCompileTimeConstantProblem
    public static void Log(LogLevel level, [StructuredMessageTemplate] string template, params object?[] args) => Logger.Log(level, template, args);
    public static void LogTrace([StructuredMessageTemplate] string template, params object?[] args) => Logger.LogTrace(template, args);
    public static void LogDebug([StructuredMessageTemplate] string template, params object?[] args) => Logger.LogDebug(template, args);
    public static void LogInformation([StructuredMessageTemplate] string template, params object?[] args) => Logger.LogInformation(template, args);
    public static void LogWarning([StructuredMessageTemplate] string template, params object?[] args) => Logger.LogWarning(template, args);
    public static void LogError([StructuredMessageTemplate] string template, params object?[] args) => Logger.LogError(template, args);
    public static void LogCritical([StructuredMessageTemplate] string template, params object?[] args) => Logger.LogCritical(template, args);
    // ReSharper restore TemplateIsNotCompileTimeConstantProblem
}

public static class Extensions
{
    public static void LogDiagnostics(this ILogger logger, string? diagnostics, LogLevel logLevel = LogLevel.Debug)
    {
        logger.Log(logLevel, "Diagnostics: {Diagnostics}",  diagnostics ?? "no diagnostics");
        
    }
    
    public static void LogDiagnostics(this ILogger logger, IBlob? blobDiagnostics, LogLevel logLevel = LogLevel.Debug)
    {
        logger.LogDiagnostics(blobDiagnostics?.AsString(), logLevel);
    }
}