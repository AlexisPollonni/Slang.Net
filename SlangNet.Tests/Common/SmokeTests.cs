using Microsoft.Extensions.Logging;
using SlangNet.Bindings.Generated;
using SlangNet.ComWrappers;
using SlangNet.Tests.Common.Tools;
using Xunit;

namespace SlangNet.Tests;

public class SmokeTests(ILogger<SmokeTests> logger)
{
    [Fact]
    public void CanCreateBasicGlobalSession()
    {
        var result = Slang.CreateGlobalSession(SlangApi.SLANG_API_VERSION, out var globalSession);

        Assert.Multiple(() =>
        {
            Assert.Equal(result, SlangResult.Ok);
            Assert.NotNull(globalSession);
        });
    }

    [Fact]
    public void CanCreateTestGlobalSession()
    {
        _ = SharedHelpers.CreateTestGlobalSession();
    }

    [Fact]
    public void CanCreateTestDevice()
    {
        var globalSession = SharedHelpers.CreateTestGlobalSession();
        _ = SharedHelpers.CreateTestDevice(globalSession, logger: logger);
    }
}