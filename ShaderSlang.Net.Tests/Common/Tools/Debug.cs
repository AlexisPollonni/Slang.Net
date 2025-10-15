using System.Diagnostics;
using Microsoft.Extensions.Logging;
using ShaderSlang.Net.Bindings.Generated;
using static ShaderSlang.Net.ComWrappers.Gfx.Gfx;

namespace ShaderSlang.Net.Tests.Common.Tools;

public static class Debug
{
    private static readonly Lock LoggingLock = new();

    [Conditional("DEBUG")]
    public static void Layer() => EnableDebugLayer();

    public static void EnableLogging(ILogger logger)
    {
        SetDebugCallback(
                (type, source, message) =>
                {
                    var level = type switch
                    {
                        DebugMessageType.Info => LogLevel.Information,
                        DebugMessageType.Warning => LogLevel.Warning,
                        DebugMessageType.Error => LogLevel.Error,
                        _ => throw new ArgumentOutOfRangeException(nameof(type), type, null),
                    };

                    lock (LoggingLock)
                        logger.Log(level, "{Source}: {Message}", source, message);
                }
            )
            .ThrowIfFailed();
    }
}
