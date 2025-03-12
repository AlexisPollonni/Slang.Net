using System;

namespace SlangNet.Internal;

internal interface IMarshalsToNative<TNative> where TNative : unmanaged
{
    public IDisposable AsNative(out TNative native);
}


internal interface IMarshalsFromNative<TManaged, TNative> where TNative : unmanaged
                                                 where TManaged : IMarshalsFromNative<TManaged, TNative>
{
    public static abstract void CreateFromNative(TNative native, out TManaged managed);
}
