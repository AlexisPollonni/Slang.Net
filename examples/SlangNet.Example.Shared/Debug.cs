using System.Diagnostics;
using Microsoft.Extensions.Logging;
using SlangNet.Bindings.Generated;
using IDevice = SlangNet.ComWrappers.Gfx.Interfaces.IDevice;

using static SlangNet.ComWrappers.Gfx.Gfx;

namespace SlangNet.Example.Shared;

public static class Debug
{
    private static readonly Lock LoggingLock = new();

    [Conditional("DEBUG")]
    public static void Layer() =>
        EnableDebugLayer();

    public static void EnableLogging()
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

                lock (LoggingLock) SharedLogger<IDevice>.Log(level, "{Source}: {Message}", source, message);
            })
            .ThrowIfFailed();
    }
}