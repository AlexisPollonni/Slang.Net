using System;
using SlangNet.Internal;

namespace SlangNet.Gfx;

[GenerateThrowingMethods]
public partial class QueryPool : COMObject<IQueryPool>
{
    internal unsafe QueryPool(IQueryPool* pointer) : base(pointer)
    { }

    public unsafe SlangResult GetResult(int queryStartIndex, Span<ulong> data)
    {
        if (data.IsEmpty)
        {
            return SlangResult.Ok;
        }

        fixed (ulong* pData = data)
        {
            return Pointer->getResult(queryStartIndex, data.Length, pData).ToSlangResult();
        }
    }

    public unsafe SlangResult Reset()
    {
        return Pointer->reset().ToSlangResult();
    }
}
