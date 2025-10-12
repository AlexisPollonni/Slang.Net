using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Logs;
using Xunit;
using Xunit.Microsoft.DependencyInjection;
using Xunit.Microsoft.DependencyInjection.Abstracts;
using Xunit.Microsoft.DependencyInjection.Attributes;

namespace ShaderSlang.Net.Tests;

public class DefaultTestFixture : TestBedFixture
{
    protected override void AddServices(IServiceCollection services, IConfiguration? configuration)
    {
        services.AddLogging(builder =>
            builder
                .SetMinimumLevel(LogLevel.Debug)
                .AddOpenTelemetry(options => options.AddOtlpExporter())
        );
    }

    protected override IEnumerable<TestAppSettings> GetTestAppSettings() => [];

    protected override ValueTask DisposeAsyncCore() => ValueTask.CompletedTask;
}

public class TestBase<TTest>(ITestOutputHelper testOutputHelper, DefaultTestFixture fixture)
    : TestBedWithDI<DefaultTestFixture>(testOutputHelper, fixture)
{
    [Inject]
    public required ILogger<TTest> Logger { get; set; }
}
