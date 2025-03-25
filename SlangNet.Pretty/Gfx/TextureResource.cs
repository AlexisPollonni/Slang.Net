using SlangNet.Gfx.Desc;

namespace SlangNet.Gfx;

public class TextureResource : Resource
{
    private unsafe ITextureResource* ImplPtr => (ITextureResource*)Pointer;

    public unsafe TextureResource(ITextureResource* pointer) : base((IResource*)pointer) { }

    public unsafe TextureResourceDesc GetDesc()
    {
        var nativePtr = ImplPtr->getDesc();
        TextureResourceDesc.CreateFromNative(*nativePtr, out var managed);
        return managed;
    }
}