using System.Diagnostics;
using ConsoleAppFramework;

namespace Slang.Net.Scripts.Shared;

public static class ConsoleAppFrameworkActivitySource
{
    public const string Name = "ConsoleAppFramework";

    public static ActivitySource Instance { get; } = new ActivitySource(Name);
}

public class CommandTracingFilter(ConsoleAppFilter next) : ConsoleAppFilter(next)
{
    public override async Task InvokeAsync(ConsoleAppContext context, CancellationToken cancellationToken)
    {
        using var activity = ConsoleAppFrameworkActivitySource.Instance.StartActivity("CommandStart");

        if (activity == null) // Telemetry is not listened
        {
            await Next.InvokeAsync(context, cancellationToken);
        }
        else
        {
            activity.SetTag("console_app.command_name", context.CommandName);
            activity.SetTag("console_app.command_args", string.Join(" ", context.EscapedArguments));

            try
            {
                await Next.InvokeAsync(context, cancellationToken);
                activity.SetStatus(ActivityStatusCode.Ok);
            }
            catch (Exception ex)
            {
                if (ex is OperationCanceledException)
                {
                    activity.SetStatus(ActivityStatusCode.Error, "Canceled");
                }
                else
                {
                    activity.AddException(ex);
                    activity.SetStatus(ActivityStatusCode.Error);
                }
                throw;
            }
        }
    }
}