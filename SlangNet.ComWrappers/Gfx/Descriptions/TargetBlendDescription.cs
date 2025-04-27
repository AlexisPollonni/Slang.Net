using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers.Gfx.Descriptions;

public readonly record struct TargetBlendDescription(
    Unmanaged.AspectBlendDesc Color,
    Unmanaged.AspectBlendDesc Alpha,
    bool EnableBlend = false,
    Unmanaged.LogicOp LogicOp = Unmanaged.LogicOp.NoOp,
    RenderTargetWriteMaskT WriteMask = RenderTargetWriteMaskT.EnableAll)
    : IMarshalsToNative<Unmanaged.TargetBlendDesc>,
      IMarshalsFromNative<TargetBlendDescription, Unmanaged.TargetBlendDesc> 
{
    private readonly Unmanaged.TargetBlendDesc _unmanaged = new()
    {
        color = Color,
        alpha = Alpha,
        enableBlend = EnableBlend,
        logicOp = LogicOp,
        writeMask = (byte)WriteMask,
    };

    Unmanaged.TargetBlendDesc IMarshalsToNative<Unmanaged.TargetBlendDesc>.AsNative(ref GrowingStackBuffer buffer) =>
        _unmanaged;

    public static TargetBlendDescription CreateFromNative(Unmanaged.TargetBlendDesc unmanaged) =>
        new(unmanaged.color, unmanaged.alpha, unmanaged.enableBlend, unmanaged.logicOp, (RenderTargetWriteMaskT)unmanaged.writeMask);

    public Unmanaged.AspectBlendDesc Color
    {
        get => _unmanaged.color;
        init => _unmanaged.color = value;
    }
    
    public Unmanaged.AspectBlendDesc Alpha
    {
        get => _unmanaged.alpha;
        init => _unmanaged.alpha = value;
    }
    
    public bool EnableBlend
    {
        get => _unmanaged.enableBlend;
        init => _unmanaged.enableBlend = value;
    }

    public Unmanaged.LogicOp LogicOp
    {
        get => _unmanaged.logicOp;
        init => _unmanaged.logicOp = value;
    }
    
    public RenderTargetWriteMaskT WriteMask
    {
        get => (RenderTargetWriteMaskT)_unmanaged.writeMask;
        init => _unmanaged.writeMask = (byte)value;
    }
}