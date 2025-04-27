using NUnit.Framework;
using SlangNet.Bindings.Generated;
using SlangNet.ComWrappers;
using IGlobalSession = SlangNet.ComWrappers.Interfaces.IGlobalSession;

namespace SlangNet.Tests;

internal unsafe class SmokeTests
{
    [Test]
    public void CanCreateGlobalSession()
    {
        IGlobalSession? globalSession = null;
        var result = Slang.CreateGlobalSession(SlangApi.SLANG_API_VERSION, out globalSession);
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.EqualTo(SlangResult.Ok));
            Assert.That(globalSession, Is.Not.Null, "createGlobalSession returned a null pointer");
        });
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
