using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ShaderSlang.Net.Bindings.Generated;

/// <include file='IDebugCallback.xml' path='doc/member[@name="IDebugCallback"]/*' />
public unsafe partial struct IDebugCallback
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _handleMessage(
        IDebugCallback* pThis,
        [NativeTypeName("gfx::DebugMessageType")] DebugMessageType type,
        [NativeTypeName("gfx::DebugMessageSource")] DebugMessageSource source,
        [NativeTypeName("const char *")] sbyte* message
    );

    /// <include file='IDebugCallback.xml' path='doc/member[@name="IDebugCallback.handleMessage"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void handleMessage(
        [NativeTypeName("gfx::DebugMessageType")] DebugMessageType type,
        [NativeTypeName("gfx::DebugMessageSource")] DebugMessageSource source,
        [NativeTypeName("const char *")] sbyte* message
    )
    {
        Marshal.GetDelegateForFunctionPointer<_handleMessage>(lpVtbl->handleMessage)(
            (IDebugCallback*)Unsafe.AsPointer(ref this),
            type,
            source,
            message
        );
    }

    public partial struct Vtbl
    {
        [NativeTypeName(
            "void (DebugMessageType, DebugMessageSource, const char *) __attribute__((stdcall))"
        )]
        public IntPtr handleMessage;
    }
}
