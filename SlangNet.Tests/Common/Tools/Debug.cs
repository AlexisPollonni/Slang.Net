using System.Diagnostics;
using Microsoft.Extensions.Logging;
using SlangNet.Bindings.Generated;
using static SlangNet.ComWrappers.Gfx.Gfx;

namespace SlangNet.Tests.Common.Tools;

public static class Debug
{
    private static readonly Lock LoggingLock = new();

    [Conditional("DEBUG")]
    public static void Layer() =>
        EnableDebugLayer();

    public static void EnableLogging(ILogger logger)
    {
        SetDebugCallback((type, source, message) =>
            {
                var level = type switch
                {
                    DebugMessageType.Info => LogLevel.Information,
                    DebugMessageType.Warning => LogLevel.Warning,
                    DebugMessageType.Error => LogLevel.Error,
                    _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
                };

                lock (LoggingLock) logger.Log(level, "{Source}: {Message}", source, message);
            })
            .ThrowIfFailed();
    }
}