using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace ShaderSlang.Net.Bindings.Generated;

[SuppressMessage("ReSharper", "InconsistentNaming")]
partial struct SlangUUID
{
    public static implicit operator Guid(SlangUUID uuid) => uuid.ToGuid();

    public static implicit operator SlangUUID(Guid g) => FromGuid(g);

    public static SlangUUID FromGuid(Guid g)
    {
        var uuid = new SlangUUID();

        g.TryWriteBytes(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref uuid, 1)));

        return uuid;
    }

    public Guid ToGuid()
    {
        return new(MemoryMarshal.AsBytes(MemoryMarshal.CreateReadOnlySpan(in this, 1)));
    }
}
