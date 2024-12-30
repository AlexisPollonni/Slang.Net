using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated;

/// <include file='SlangTerminatedChars.xml' path='doc/member[@name="SlangTerminatedChars"]/*' />
public partial struct SlangTerminatedChars
{
    /// <include file='SlangTerminatedChars.xml' path='doc/member[@name="SlangTerminatedChars.chars"]/*' />
    [NativeTypeName("char[1]")]
    public _chars_e__FixedBuffer chars;

    /// <include file='_chars_e__FixedBuffer.xml' path='doc/member[@name="_chars_e__FixedBuffer"]/*' />
    public partial struct _chars_e__FixedBuffer
    {
        public sbyte e0;

        [UnscopedRef]
        public ref sbyte this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return ref Unsafe.Add(ref e0, index);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [UnscopedRef]
        public Span<sbyte> AsSpan(int length) => MemoryMarshal.CreateSpan(ref e0, length);
    }
}
