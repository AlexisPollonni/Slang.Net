using Microsoft.Extensions.Logging;
using SlangNet.ComWrappers.Interfaces;
using SlangNet.ComWrappers.Tools.Extensions;

#pragma warning disable CA2254

namespace SlangNet.Tests.Common.Tools;

public static class LoggerExtensions
{
    public static void LogDiagnostics(this ILogger logger, IBlob? blobDiagnostics, LogLevel logLevel = LogLevel.Debug)
    {
        if (blobDiagnostics is null) return;
        LogDiagnostics(logger, blobDiagnostics.AsString(), logLevel);
    }
    
    public static void LogDiagnostics(this ILogger logger, string? diagString, LogLevel logLevel = LogLevel.Debug)
    {
        if (diagString.IsWhiteSpace()) return;
        logger.Log(logLevel, "Diagnostics: {Diagnostics}", diagString ?? "no diagnostics");
    }
}