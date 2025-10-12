using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.ComWrappers.Tools;

namespace ShaderSlang.Net.ComWrappers.Gfx.Descriptions;

[NativeMarshalling(typeof(MarshalableMarshaller.Bidirectional<QueryPoolDescription, Unmanaged.IQueryPool.QueryPoolDesc>))]
public readonly record struct QueryPoolDescription(Unmanaged.QueryType QueryType, int QueryCount)
    : IMarshalsToNative<Unmanaged.IQueryPool.QueryPoolDesc>,
      IMarshalsFromNative<QueryPoolDescription, Unmanaged.IQueryPool.QueryPoolDesc>
{
    Unmanaged.IQueryPool.QueryPoolDesc IMarshalsToNative<Unmanaged.IQueryPool.QueryPoolDesc>.AsNative(ref GrowingStackBuffer buffer) =>
        new()
        {
            type = QueryType,
            count = QueryCount,
        };

    public static QueryPoolDescription CreateFromNative(Unmanaged.IQueryPool.QueryPoolDesc unmanaged) =>
        new(unmanaged.type, unmanaged.count);
}
