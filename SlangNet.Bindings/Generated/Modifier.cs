using static SlangNet.Bindings.Generated.ModifierID;

namespace SlangNet.Bindings.Generated;

/// <include file='Modifier.xml' path='doc/member[@name="Modifier"]/*' />
public partial struct Modifier
{

    /// <include file='ID.xml' path='doc/member[@name="ID"]/*' />
    [NativeTypeName("SlangModifierIDIntegral")]
    public enum ID : uint
    {
        /// <include file='ID.xml' path='doc/member[@name="ID.Shared"]/*' />
        Shared = ModifierShared,

        /// <include file='ID.xml' path='doc/member[@name="ID.NoDiff"]/*' />
        NoDiff = ModifierNoDiff,

        /// <include file='ID.xml' path='doc/member[@name="ID.Static"]/*' />
        Static = ModifierStatic,

        /// <include file='ID.xml' path='doc/member[@name="ID.Const"]/*' />
        Const = ModifierConst,

        /// <include file='ID.xml' path='doc/member[@name="ID.Export"]/*' />
        Export = ModifierExport,

        /// <include file='ID.xml' path='doc/member[@name="ID.Extern"]/*' />
        Extern = ModifierExtern,

        /// <include file='ID.xml' path='doc/member[@name="ID.Differentiable"]/*' />
        Differentiable = ModifierDifferentiable,

        /// <include file='ID.xml' path='doc/member[@name="ID.Mutating"]/*' />
        Mutating = ModifierMutating,

        /// <include file='ID.xml' path='doc/member[@name="ID.In"]/*' />
        In = ModifierIn,

        /// <include file='ID.xml' path='doc/member[@name="ID.Out"]/*' />
        Out = ModifierOut,

        /// <include file='ID.xml' path='doc/member[@name="ID.InOut"]/*' />
        InOut = ModifierInout,
    }
}
