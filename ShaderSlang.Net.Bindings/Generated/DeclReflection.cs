namespace ShaderSlang.Net.Bindings.Generated;

/// <include file='DeclReflection.xml' path='doc/member[@name="DeclReflection"]/*' />
public partial struct DeclReflection
{

    /// <include file='IteratedList.xml' path='doc/member[@name="IteratedList"]/*' />
    public unsafe partial struct IteratedList
    {
        /// <include file='IteratedList.xml' path='doc/member[@name="IteratedList.count"]/*' />
        [NativeTypeName("unsigned int")]
        public uint count;

        /// <include file='IteratedList.xml' path='doc/member[@name="IteratedList.parent"]/*' />
        [NativeTypeName("slang::DeclReflection *")]
        public DeclReflection* parent;

        /// <include file='Iterator.xml' path='doc/member[@name="Iterator"]/*' />
        public unsafe partial struct Iterator
        {
            /// <include file='Iterator.xml' path='doc/member[@name="Iterator.parent"]/*' />
            [NativeTypeName("slang::DeclReflection *")]
            public DeclReflection* parent;

            /// <include file='Iterator.xml' path='doc/member[@name="Iterator.count"]/*' />
            [NativeTypeName("unsigned int")]
            public uint count;

            /// <include file='Iterator.xml' path='doc/member[@name="Iterator.index"]/*' />
            [NativeTypeName("unsigned int")]
            public uint index;
        }
    }
}
