using System;

namespace SlangNet.Internal;

interface IMarshalable<TManaged, TNative> where TNative : unmanaged 
                                          where TManaged : IMarshalable<TManaged, TNative>
{
    public IDisposable AsNative(out TNative native);
    
    public static TManaged CreateFromNative(TNative native) =>
        throw new NotImplementedException();
}
