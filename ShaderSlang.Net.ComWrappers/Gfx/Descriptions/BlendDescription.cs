using ShaderSlang.Net.ComWrappers.Tools;

namespace ShaderSlang.Net.ComWrappers.Gfx.Descriptions;

public readonly record struct BlendDescription(
    TargetBlendDescription[] Targets,
    bool AlphaToCoverageEnable
)
    : IMarshalsToNative<Unmanaged.BlendDesc>,
        IMarshalsFromNative<BlendDescription, Unmanaged.BlendDesc>
{
    Unmanaged.BlendDesc IMarshalsToNative<Unmanaged.BlendDesc>.AsNative(
        ref GrowingStackBuffer buffer
    )
    {
        var res = new Unmanaged.BlendDesc
        {
            targets = new(),
            targetCount = Targets.Length,
            alphaToCoverageEnable = AlphaToCoverageEnable,
        };

        for (var i = 0; i < Targets.Length; i++)
        {
            var targetBlendDescription = Targets[i];

            res.targets[i] = (
                (IMarshalsToNative<Unmanaged.TargetBlendDesc>)targetBlendDescription
            ).AsNative(ref buffer);
        }

        return res;
    }

    public static BlendDescription CreateFromNative(Unmanaged.BlendDesc unmanaged)
    {
        var blendDescs = new TargetBlendDescription[unmanaged.targetCount];
        for (var i = 0; i < unmanaged.targetCount; i++)
        {
            blendDescs[i] = TargetBlendDescription.CreateFromNative(unmanaged.targets[i]);
        }
        return new(blendDescs, unmanaged.alphaToCoverageEnable);
    }
}
