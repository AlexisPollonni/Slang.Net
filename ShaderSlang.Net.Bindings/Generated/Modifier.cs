namespace ShaderSlang.Net.Bindings.Generated;

/// <include file='Modifier.xml' path='doc/member[@name="Modifier"]/*' />
public partial struct Modifier
{
    /// <include file='ID.xml' path='doc/member[@name="ID"]/*' />
    [NativeTypeName("SlangModifierIDIntegral")]
    public enum ID : uint
    {
        /// <include file='ID.xml' path='doc/member[@name="ID.Shared"]/*' />
        Shared = ModifierID.Shared,

        /// <include file='ID.xml' path='doc/member[@name="ID.NoDiff"]/*' />
        NoDiff = ModifierID.NoDiff,

        /// <include file='ID.xml' path='doc/member[@name="ID.Static"]/*' />
        Static = ModifierID.Static,

        /// <include file='ID.xml' path='doc/member[@name="ID.Const"]/*' />
        Const = ModifierID.Const,

        /// <include file='ID.xml' path='doc/member[@name="ID.Export"]/*' />
        Export = ModifierID.Export,

        /// <include file='ID.xml' path='doc/member[@name="ID.Extern"]/*' />
        Extern = ModifierID.Extern,

        /// <include file='ID.xml' path='doc/member[@name="ID.Differentiable"]/*' />
        Differentiable = ModifierID.Differentiable,

        /// <include file='ID.xml' path='doc/member[@name="ID.Mutating"]/*' />
        Mutating = ModifierID.Mutating,

        /// <include file='ID.xml' path='doc/member[@name="ID.In"]/*' />
        In = ModifierID.In,

        /// <include file='ID.xml' path='doc/member[@name="ID.Out"]/*' />
        Out = ModifierID.Out,

        /// <include file='ID.xml' path='doc/member[@name="ID.InOut"]/*' />
        InOut = ModifierID.Inout,
    }
}
