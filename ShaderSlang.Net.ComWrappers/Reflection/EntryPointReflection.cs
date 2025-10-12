using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.ComWrappers.Tools;

namespace ShaderSlang.Net.ComWrappers.Reflection;

[NativeMarshalling(typeof(HandleStructMarshaller<EntryPointReflection>))]
public readonly unsafe struct EntryPointReflection
    : IEquatable<EntryPointReflection>,
        INativeHandleMarshallable<EntryPointReflection>
{
    internal Unmanaged.SlangEntryPointLayout* Pointer { get; }
    nint INativeHandleMarshallable<EntryPointReflection>.Handle => (nint)Pointer;

    public static EntryPointReflection CreateFromHandle(nint handle) =>
        new((Unmanaged.SlangEntryPointLayout*)handle);

    internal EntryPointReflection(Unmanaged.SlangEntryPointLayout* pointer)
    {
        ArgumentNullException.ThrowIfNull(pointer);
        Pointer = pointer;
        Parameters = new NativeBoundedReadOnlyList<EntryPointReflection, VariableLayoutReflection>
        {
            Container = this,
            GetCount = container =>
                (nint)ReflectionApi.ReflectionEntryPoint_getParameterCount(container),
            TryGetAt = (@this, index) =>
                ReflectionApi.ReflectionEntryPoint_getParameterByIndex(@this, checked((uint)index)),
        };
    }

    public bool Equals(EntryPointReflection other) => Pointer == other.Pointer;

    public override bool Equals(object? obj) => obj is EntryPointReflection other && Equals(other);

    public static bool operator ==(EntryPointReflection a, EntryPointReflection b) =>
        a.Pointer == b.Pointer;

    public static bool operator !=(EntryPointReflection a, EntryPointReflection b) =>
        a.Pointer != b.Pointer;

    public override int GetHashCode() => new nint(Pointer).GetHashCode();

    public string? Name => ReflectionApi.ReflectionEntryPoint_getName(this);
    public string? OverrideName => ReflectionApi.ReflectionEntryPoint_getNameOverride(this);
    public IReadOnlyList<VariableLayoutReflection> Parameters { get; }
    public FunctionReflection? Function => ReflectionApi.ReflectionEntryPoint_getFunction(this);
    public Unmanaged.Stage Stage => ReflectionApi.ReflectionEntryPoint_getStage(this);

    private const int MaxComputeAxes = 3;
    public nuint[] ComputeThreadGroupSize
    {
        get
        {
            var axes = new ulong[MaxComputeAxes];
            ReflectionApi.ReflectionEntryPoint_getComputeThreadGroupSize(
                this,
                MaxComputeAxes,
                axes
            );
            return axes.Select(arg => checked((nuint)arg)).ToArray();
        }
    }

    public nuint WaveSize
    {
        get
        {
            ReflectionApi.ReflectionEntryPoint_getComputeWaveSize(this, out var waveSize);
            return waveSize;
        }
    }

    public bool UsesAnySampleRateInput =>
        ReflectionApi.ReflectionEntryPoint_usesAnySampleRateInput(this) != 0;

    public VariableLayoutReflection? VarLayout =>
        ReflectionApi.ReflectionEntryPoint_getVarLayout(this);
    public TypeLayoutReflection? TypeLayout => VarLayout?.TypeLayout;
    public VariableLayoutReflection? ResultVarLayout =>
        ReflectionApi.ReflectionEntryPoint_getResultVarLayout(this);
    public bool HasDefaultConstantBuffer =>
        ReflectionApi.ReflectionEntryPoint_hasDefaultConstantBuffer(this) != 0;
}
