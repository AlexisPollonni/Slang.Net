using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using ShaderSlang.Net.Bindings.Enums;
using ShaderSlang.Net.Bindings.Generated;
using ShaderSlang.Net.ComWrappers.Gfx;
using ShaderSlang.Net.ComWrappers.Gfx.Descriptions;
using ShaderSlang.Net.ComWrappers.Gfx.Interfaces;
using ShaderSlang.Net.ComWrappers.Interfaces;
using Xunit;
using static ShaderSlang.Net.ComWrappers.Gfx.Gfx;
using static ShaderSlang.Net.ComWrappers.Slang;
using AdapterInfo = ShaderSlang.Net.ComWrappers.Gfx.Descriptions.AdapterInfo;
using IComponentType = ShaderSlang.Net.ComWrappers.Interfaces.IComponentType;
using IDevice = ShaderSlang.Net.ComWrappers.Gfx.Interfaces.IDevice;
using IGlobalSession = ShaderSlang.Net.ComWrappers.Interfaces.IGlobalSession;
using IShaderProgram = ShaderSlang.Net.ComWrappers.Gfx.Interfaces.IShaderProgram;
using ShaderReflection = ShaderSlang.Net.ComWrappers.Reflection.ShaderReflection;

namespace ShaderSlang.Net.Tests.Common.Tools;

internal static class SharedHelpers
{
    public static string RunningExePath
    {
        get
        {
            var p = Path.GetDirectoryName(typeof(Program).Assembly.Location);

            Assert.NotNull(p);
            Assert.NotEmpty(p);

            return p;
        }
    }

    public static bool IsCi => Environment.GetEnvironmentVariable("CI") is "true";

    public static IGlobalSession CreateTestGlobalSession()
    {
        var globalSession = CreateGlobalSession();

        globalSession.SetDownstreamCompilerPath(PassThrough.Llvm, RunningExePath);

        var llvmRes = globalSession.CheckPassThroughSupport(PassThrough.Llvm);
        if (!llvmRes.Succeeded)
        {
            TestContext.Current.AddWarning($"slang-llvm not available, CheckPassThroughSupport returned: {llvmRes}");
        }

        if (OperatingSystem.IsWindows())
        {
            globalSession.SetDownstreamCompilerPath(PassThrough.Dxc, RunningExePath);
            globalSession.CheckPassThroughSupportOrThrow(PassThrough.Dxc);
        }

        Assert.NotNull(globalSession);

        return globalSession;
    }

    public static IDevice CreateTestDevice(
        IGlobalSession globalSession,
        bool allowCpuDevice = true,
        DeviceType deviceType = DeviceType.Default,
        ILogger? logger = null
    )
    {
        Debug.Layer();
        if (logger is not null)
            Debug.EnableLogging(logger);

        if (deviceType is DeviceType.Default or DeviceType.Unknown)
        {
            // For now we only allow CPU devices in CI
            deviceType = IsCi ? DeviceType.CPU : FindFirstAvailable(allowCpuDevice);
        }
        else if (deviceType is not DeviceType.CPU)
        {
            SkipIfNotAvailable(deviceType);
        }

        if (IsCi && deviceType is not DeviceType.CPU)
        {
            Assert.Skip("Skipping test because non-CPU device types are not available in CI.");
        }

        if (deviceType is DeviceType.CPU && !globalSession.CheckPassThroughSupport(PassThrough.Llvm).Succeeded)
        {
            TestContext.Current.AddWarning(
                "CPU device is not available, cannot run example test. Ensure slang-llvm binary is in working directory.");
            Assert.Skip("Skipping test because CPU device is not available.");
        }

        var runningBinPath = RunningExePath;
        var devDesc = new DeviceDescription
        {
            DeviceType = deviceType,
            Slang = new()
            {
                GlobalSession = globalSession,
                TargetFlags = TargetFlags.GenerateSPIRVDirectly,
                OptimizationLevel = OptimizationLevel.None,
                DefaultMatrixLayoutMode = MatrixLayoutMode.RowMajor,
                SearchPaths = [Path.Combine(runningBinPath, "Examples", "Assets")],
            },
            ShaderCache = new() { Path = Path.Combine(runningBinPath, "ShaderCache") },
        };

        CreateDevice(devDesc, out var device).ThrowIfFailed();

        return device;
    }

    public static (IShaderProgram program, ShaderReflection programLayout) LoadShaderProgram(
        IDevice device,
        string moduleName,
        ILogger? logger = null
    )
    {
        var session = device.GetSlangSessionOrThrow();

        var module = session.LoadModule(moduleName, out var diag);
        logger?.LogDiagnostics(diag);

        Assert.NotNull(module);

        var computeEntryPoint = module.FindEntryPointByNameOrThrow("computeMain");

        var componentTypes = new IComponentType[] { module, computeEntryPoint };
        var composedProgram = session.CreateCompositeComponentTypeOrThrow(
            componentTypes,
            2,
            out var diagStr
        );
        logger?.LogDiagnostics(diagStr);

        var slangReflection = composedProgram.GetLayout(0, out diag);
        logger?.LogDiagnostics(diag);

        Assert.NotNull(slangReflection);

        var programDesc = new ShaderProgramDescription(GlobalScope: composedProgram);
        var program = device.CreateProgramOrThrow(programDesc, out diagStr);
        logger?.LogDiagnostics(diagStr);

        Assert.NotNull(program);

        return (program, slangReflection.Value);
    }

    public static void SkipIfNotAvailable(DeviceType type)
    {
        GetAdapters(type, out IReadOnlyList<AdapterInfo> adapters);

        if (adapters.Count == 0)
        {
            Assert.Skip($"Skipping test because GPU adapter for {type} is not available.");
        }
    }

    private static DeviceType FindFirstAvailable(bool includeCpu = false)
    {
        var deviceTypes = new List<DeviceType>
        {
            DeviceType.DirectX12,
            DeviceType.Metal,
            DeviceType.Vulkan,
        };

        if (includeCpu)
            deviceTypes.Add(DeviceType.CPU);

        var adapters = deviceTypes
            .SelectMany(type =>
            {
                var res = GetAdapters(type, out IReadOnlyList<AdapterInfo> adapters);

                if (res.Succeeded)
                    return adapters.Select(info => (type, info));

                TestContext.Current.SendDiagnosticMessage(
                    $"Failed to get adapters for {type}: {res}"
                );
                return [];
            })
            .ToArray();

        var firstAvailable = adapters.FirstOrDefault();

        return firstAvailable != default ? firstAvailable.type : DeviceType.Unknown;
    }
}