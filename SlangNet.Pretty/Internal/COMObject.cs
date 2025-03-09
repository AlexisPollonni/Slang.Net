using System;
using System.Runtime.InteropServices;

namespace SlangNet.Internal;

public class COMObject<T> : SafeHandle, IEquatable<COMObject<T>> where T : unmanaged
{
    /// <summary>Returns the raw pointer underneath the wrapper</summary>
    /// <remarks>The reference counter is not incremented</remarks>
    public unsafe T* Pointer
    {
        get
        {
            ThrowIfDisposed();
            return (T*)handle;
        }
    }

    public override bool IsInvalid => handle <= nint.Zero;

    protected internal unsafe COMObject(T* pointer) : base(nint.Zero, true)
    {
        ArgumentNullException.ThrowIfNull(pointer);
        
        SetHandle((nint)pointer);
    }

    public unsafe bool Equals(COMObject<T>? other) =>
        other?.IsInvalid ?? true ? IsInvalid : other.handle == handle;

    public override bool Equals(object? obj) =>
        obj is COMObject<T> other && Equals(other);

    public static bool operator ==(COMObject<T> a, COMObject<T> b) =>
        a == null! || b == null! ? ReferenceEquals(a, b) : a.Equals(b);

    public static bool operator !=(COMObject<T> a, COMObject<T> b) =>
        !(a == b);

    public override unsafe int GetHashCode() => handle.GetHashCode();

    protected internal void ThrowIfDisposed()
    {
        ObjectDisposedException.ThrowIf(IsClosed, this);
        ObjectDisposedException.ThrowIf(IsInvalid, this);
    }

    protected unsafe override bool ReleaseHandle()
    {
        ((ISlangUnknown*)handle)->release();
        return true;
    }
}