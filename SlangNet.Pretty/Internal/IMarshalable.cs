using System;

namespace SlangNet.Internal;

public interface IMarshalsToNative<TNative> where TNative : unmanaged
{
    /// <summary>
    /// Returns the number of bytes required to allocate the native representation of the object.
    /// This is used to pre-allocate the MarshallingAllocBuffer when converting to the native representation. 
    /// It is not required but it is recommended to implement this to avoid unnecessary allocations.
    /// </summary>
    /// <returns>The number of bytes required to allocate the native representation of this object.</returns>
    public int GetNativeAllocSize();

    /// <summary>
    /// Marshals the object to its native representation.
    /// </summary>
    public void AsNative(MarshallingAllocBuffer buffer, out TNative native);
}


public interface IMarshalsFromNative<TManaged, TNative> where TNative : unmanaged
                                                 where TManaged : IMarshalsFromNative<TManaged, TNative>
{
    public static abstract void CreateFromNative(TNative native, out TManaged managed);
}
