using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SlangNet.Gfx;

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
    public void AsNative(ref MarshallingAllocBuffer buffer, out TNative native);
}


public interface IMarshalsFromNative<TManaged, in TNative> where TNative : unmanaged
                                                           where TManaged : IMarshalsFromNative<TManaged, TNative>
{
    public static abstract void CreateFromNative(TNative native, out TManaged managed);
}




//TODO: Built in interop source gen does not support automatic custom struct generation. Reconsider when https://github.com/dotnet/runtime/issues/81656 is implemented

partial class Test
{
    [LibraryImport("slang")]
    public static partial void TestInterop(
        [MarshalUsing(typeof(TestMarshaller))]
        BufferResourceDesc desc);
}