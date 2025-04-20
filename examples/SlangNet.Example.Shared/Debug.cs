using System.Diagnostics;
using Microsoft.Extensions.Logging;
using SlangNet.Bindings.Generated;
using SlangNet.ComWrappers.Gfx;
using IDevice = SlangNet.ComWrappers.Gfx.Interfaces.IDevice;

namespace SlangNet.Example.Shared;

public static class Debug
{
    private static readonly Lock LoggingLock = new();

    [Conditional("DEBUG")]
    public static void Layer() => Gfx.EnableDebugLayer();

    public static void EnableLogging()
    {
        Gfx.SetDebugCallback((type, source, message) =>
           {
               var level = type switch
               {
                   DebugMessageType.Info => LogLevel.Information,
                   DebugMessageType.Warning => LogLevel.Warning,
                   DebugMessageType.Error => LogLevel.Error,
                   _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
               };
               
               lock (LoggingLock) 
                   SharedLogger<IDevice>.Log(level, "{Source}: {Message}", source, message);
           })
           .ThrowIfFailed();
    }
}