namespace SlangNet.Bindings.Generated;

/// <include file='Modifier.xml' path='doc/member[@name="Modifier"]/*' />
public partial struct Modifier
{

    /// <include file='ID.xml' path='doc/member[@name="ID"]/*' />
    [NativeTypeName("SlangModifierIDIntegral")]
    public enum ID : uint
    {
        /// <include file='ID.xml' path='doc/member[@name="ID.Shared"]/*' />
        Shared = ModifierID.SlangModifierShared,

        /// <include file='ID.xml' path='doc/member[@name="ID.NoDiff"]/*' />
        NoDiff = ModifierID.SlangModifierNoDiff,

        /// <include file='ID.xml' path='doc/member[@name="ID.Static"]/*' />
        Static = ModifierID.SlangModifierStatic,

        /// <include file='ID.xml' path='doc/member[@name="ID.Const"]/*' />
        Const = ModifierID.SlangModifierConst,

        /// <include file='ID.xml' path='doc/member[@name="ID.Export"]/*' />
        Export = ModifierID.SlangModifierExport,

        /// <include file='ID.xml' path='doc/member[@name="ID.Extern"]/*' />
        Extern = ModifierID.SlangModifierExtern,

        /// <include file='ID.xml' path='doc/member[@name="ID.Differentiable"]/*' />
        Differentiable = ModifierID.SlangModifierDifferentiable,

        /// <include file='ID.xml' path='doc/member[@name="ID.Mutating"]/*' />
        Mutating = ModifierID.SlangModifierMutating,

        /// <include file='ID.xml' path='doc/member[@name="ID.In"]/*' />
        In = ModifierID.SlangModifierIn,

        /// <include file='ID.xml' path='doc/member[@name="ID.Out"]/*' />
        Out = ModifierID.SlangModifierOut,

        /// <include file='ID.xml' path='doc/member[@name="ID.InOut"]/*' />
        InOut = ModifierID.SlangModifierInout,
    }
}
