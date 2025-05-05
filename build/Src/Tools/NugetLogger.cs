using System;
using System.Threading.Tasks;
using NuGet.Common;
using Serilog.Events;

namespace SlangNet.Build.Tools;

class NugetLogger : LoggerBase
{
    public override void Log(ILogMessage message) =>
        Serilog.Log.Logger.Write(message.Level switch
        {
            LogLevel.Debug => LogEventLevel.Debug,
            LogLevel.Verbose => LogEventLevel.Verbose,
            LogLevel.Information => LogEventLevel.Information,
            LogLevel.Minimal => LogEventLevel.Verbose,
            LogLevel.Warning => LogEventLevel.Warning,
            LogLevel.Error => LogEventLevel.Error,
            _ => throw new ArgumentOutOfRangeException()
            // ReSharper disable once TemplateIsNotCompileTimeConstantProblem
#pragma warning disable CA2254
        }, message.FormatWithCode());
#pragma warning restore CA2254

    public override Task LogAsync(ILogMessage message)
    {
        Log(message);

        return Task.CompletedTask;
    }
}