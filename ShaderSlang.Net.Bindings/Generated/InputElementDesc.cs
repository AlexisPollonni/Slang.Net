namespace ShaderSlang.Net.Bindings.Generated;

/// <include file='InputElementDesc.xml' path='doc/member[@name="InputElementDesc"]/*' />
public unsafe partial struct InputElementDesc
{
    /// <include file='InputElementDesc.xml' path='doc/member[@name="InputElementDesc.semanticName"]/*' />
    [NativeTypeName("const char *")]
    public sbyte* semanticName;

    /// <include file='InputElementDesc.xml' path='doc/member[@name="InputElementDesc.semanticIndex"]/*' />
    [NativeTypeName("gfx::GfxIndex")]
    public int semanticIndex;

    /// <include file='InputElementDesc.xml' path='doc/member[@name="InputElementDesc.format"]/*' />
    [NativeTypeName("gfx::Format")]
    public Format format;

    /// <include file='InputElementDesc.xml' path='doc/member[@name="InputElementDesc.offset"]/*' />
    [NativeTypeName("gfx::Offset")]
    public nuint offset;

    /// <include file='InputElementDesc.xml' path='doc/member[@name="InputElementDesc.bufferSlotIndex"]/*' />
    [NativeTypeName("gfx::GfxIndex")]
    public int bufferSlotIndex;
}
