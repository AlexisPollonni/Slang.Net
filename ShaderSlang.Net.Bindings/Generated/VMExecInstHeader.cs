using System;

namespace ShaderSlang.Net.Bindings.Generated;

/// <include file='VMExecInstHeader.xml' path='doc/member[@name="VMExecInstHeader"]/*' />
public partial struct VMExecInstHeader
{
    /// <include file='VMExecInstHeader.xml' path='doc/member[@name="VMExecInstHeader.functionPtr"]/*' />
    [NativeTypeName("slang::VMExtFunction")]
    public IntPtr functionPtr;

    /// <include file='VMExecInstHeader.xml' path='doc/member[@name="VMExecInstHeader.opcodeExtension"]/*' />
    [NativeTypeName("uint32_t")]
    public uint opcodeExtension;

    /// <include file='VMExecInstHeader.xml' path='doc/member[@name="VMExecInstHeader.operandCount"]/*' />
    [NativeTypeName("uint32_t")]
    public uint operandCount;
}
