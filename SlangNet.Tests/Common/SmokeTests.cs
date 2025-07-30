using SlangNet.Bindings.Generated;
using SlangNet.ComWrappers;
using Xunit;

namespace SlangNet.Tests;

public class SmokeTests
{
    [Fact]
    public void CanCreateGlobalSession()
    {
        var result = Slang.CreateGlobalSession(SlangApi.SLANG_API_VERSION, out var globalSession);

        Assert.Multiple(() =>
        {
            Assert.Equal(result, SlangResult.Ok);
            Assert.NotNull(globalSession);
        });
    }
}