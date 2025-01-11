namespace SlangNet;

public struct TargetDescription
{
    private TargetDesc native;

    public CompileTarget Format
    {
        get => native.format;
        set => native.format = value;
    }

    public ProfileID Profile
    {
        get => native.profile;
        set => native.profile = value;
    }

    public TargetFlags Flags
    {
        get => (TargetFlags)native.flags;
        set => native.flags = (uint)value;
    }

    public FloatingPointMode FloatingPointMode
    {
        get => native.floatingPointMode;
        set => native.floatingPointMode = value;
    }

    public LineDirectiveMode LineDirectiveMode
    {
        get => native.lineDirectiveMode;
        set => native.lineDirectiveMode = value;
    }

    public bool ForceGLSLScalarBufferLayout
    {
        get => native.forceGLSLScalarBufferLayout != 0;
        set => native.forceGLSLScalarBufferLayout = value ? (byte)1 : (byte)0;
    }

    internal unsafe void AsNative(TargetDesc* ptr)
    {
        native.structureSize = new((uint)sizeof(TargetDesc));
        *ptr = native;
    }
}
