using System;
using SlangNet.Internal;

namespace SlangNet.Gfx.Desc;

public record struct QueryPoolDesc(QueryType QueryType, int QueryCount)
    : IMarshalsToNative<IQueryPool.QueryPoolDesc>
{
    public void AsNative(ref MarshallingAllocBuffer buffer, out IQueryPool.QueryPoolDesc native)
    {
        native = new()
        {
            type = QueryType,
            count = QueryCount,
        };
    }

    public readonly int GetNativeAllocSize()
    {
        return SysUnsafe.SizeOf<IQueryPool.QueryPoolDesc>();
    }
}
