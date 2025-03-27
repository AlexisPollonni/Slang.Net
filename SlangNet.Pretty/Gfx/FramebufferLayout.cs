using System.Buffers;
using System.Collections.Generic;
using SlangNet.Internal;

namespace SlangNet.Gfx;

public sealed class FramebufferLayout : COMObject<IFramebufferLayout>
{
    internal unsafe FramebufferLayout(IFramebufferLayout* pointer) : base(pointer) { }

    public readonly record struct FramebufferLayoutDesc(
        IReadOnlyList<IFramebufferLayout.TargetLayout> RenderTargets,
        IFramebufferLayout.TargetLayout? DepthStencil) : IMarshalsToNative<IFramebufferLayout.FramebufferLayoutDesc>
    {
        public int GetNativeAllocSize() =>
            SysUnsafe.SizeOf<IFramebufferLayout.FramebufferLayoutDesc>() +
            RenderTargets.Count * SysUnsafe.SizeOf<IFramebufferLayout.TargetLayout>() +
            (DepthStencil is null ? 0 : SysUnsafe.SizeOf<IFramebufferLayout.TargetLayout>());

        public unsafe void AsNative(ref MarshallingAllocBuffer buffer, out IFramebufferLayout.FramebufferLayoutDesc native)
        {
            var ptrTargets = stackalloc IFramebufferLayout.TargetLayout[RenderTargets.Count];

            for (var i = 0; i < RenderTargets.Count; i++) ptrTargets[i] = RenderTargets[i];

            var depthStencil = DepthStencil;
            native = new()
            {
                renderTargets = ptrTargets,
                renderTargetCount = RenderTargets.Count,
                depthStencil = depthStencil.AsNullablePtr(),
            };
        }
    }
}