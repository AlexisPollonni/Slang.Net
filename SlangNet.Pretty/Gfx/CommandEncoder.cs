using System;
using SlangNet.Internal;

namespace SlangNet.Gfx;

public abstract class CommandEncoder : COMObject<ICommandEncoder>
{
    internal unsafe CommandEncoder(ICommandEncoder* pointer) : base(pointer)
    { }

    public unsafe void EndEncoding()
    {
        Pointer->endEncoding();
    }

    public unsafe void WriteTimestamp(QueryPool queryPool, int queryIndex)
    {
        Pointer->writeTimestamp(queryPool.Pointer, queryIndex);
    }
}
