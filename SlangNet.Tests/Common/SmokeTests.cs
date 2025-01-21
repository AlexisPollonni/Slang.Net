using NUnit.Framework;
using SlangNet.Bindings.Generated.Slang;

namespace SlangNet.Tests;

internal unsafe class SmokeTests
{
    [Test]
    public void CanCreateGlobalSession()
    {
        IGlobalSession* globalSession = null;
        var result = SlangApi.slang_createGlobalSession(SlangApi.SLANG_API_VERSION, &globalSession);
        Assert.That(result, Is.EqualTo(SlangApi.SLANG_OK));
        Assert.True(globalSession != null, "createGlobalSession returned a null pointer");
        globalSession->release();
    }

#if SHOULD_BE_2_0 || SHOULD_BE_2_1
    [TestCase(typeof(GlobalSession))]
    [TestCase(typeof(Slang))]
    public void AssemblyRuntimeIsCorrect(Type checkType)
    {
        var runtimeAssembly = checkType.Assembly
            .GetReferencedAssemblies()
            .FirstOrDefault(a => a.Name == "netstandard");
        Assert.NotNull(runtimeAssembly);
        var runtimeVersion = runtimeAssembly.Version;
        Assert.NotNull(runtimeVersion);
        Assert.That(runtimeVersion.Major, Is.EqualTo(2));
#if SHOULD_BE_2_0
        Assert.That(runtimeVersion.Minor, Is.EqualTo(0));
#elif SHOULD_BE_2_1
        Assert.That(runtimeVersion.Minor, Is.EqualTo(1));
#endif
    }
#endif
    }
