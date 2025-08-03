using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace SlangNet.Tests;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddLogging(builder => builder.AddConsole()
#if DEBUG
                                              .AddDebug()
                                              .SetMinimumLevel(LogLevel.Debug)
#endif
                                              );
    }
}