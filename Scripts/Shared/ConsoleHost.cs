using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace ShaderSlang.Net.Scripts.Shared;

public static class ConsoleHost
{
    public static HostApplicationBuilder Create(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);

        builder.Services.AddSharedScriptServices();

        return builder;
    }

    public static IServiceCollection AddSharedScriptServices(this IServiceCollection services)
    {
        return services
            .AddLogging(logging =>
            {
                logging.AddOpenTelemetry(op =>
                {
                    op.IncludeFormattedMessage = true;
                    op.IncludeScopes = true;
                });
            })
            .AddOpenTelemetry()
            .ConfigureResource(resource =>
            {
                resource.AddService("ConsoleAppFramework Telemetry");
            })
            .WithMetrics(metrics =>
            {
                // configure for metrics
                metrics.AddHttpClientInstrumentation();
            })
            .WithTracing(tracing =>
            {
                // configure for tracing
                tracing
                    .SetSampler(new AlwaysOnSampler())
                    .AddHttpClientInstrumentation()
                    .AddSource(ConsoleAppFrameworkActivitySource.Name);
            })
            .WithLogging(logging =>
            {
                logging.AddOtlpExporter();
            })
            .Services;
    }
}
