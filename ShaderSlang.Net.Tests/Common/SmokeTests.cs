using ShaderSlang.Net.Bindings;
using ShaderSlang.Net.Bindings.Generated;
using ShaderSlang.Net.ComWrappers;
using ShaderSlang.Net.Tests.Common.Tools;
using Xunit;

namespace ShaderSlang.Net.Tests.Common;

public class SmokeTests(ITestOutputHelper testOutputHelper, DefaultTestFixture fixture)
    : TestBase<SmokeTests>(testOutputHelper, fixture)
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
        _ = SharedHelpers.CreateTestDevice(globalSession, logger: Logger);
    }
}
