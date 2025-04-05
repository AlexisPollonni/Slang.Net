using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SlangNet.Bindings.Generated;

namespace SlangNet.ComWrappers;

public unsafe struct SessionDescription
{
    internal uint StructureSize = (uint)sizeof(SessionDesc);

    public List<TargetDesc> Targets = [];

    public SessionDescription()
    { }
}


public unsafe struct TargetDescription
{
    internal uint StructureSize = (uint)sizeof(TargetDesc);

    public CompileTarget Format = CompileTarget.TargetUnknown;
    public ProfileID Profile = ProfileID.ProfileUnknown;
    public uint Flags = 0;
    public FloatingPointMode FloatingPointMode = FloatingPointMode.Default;
    public LineDirectiveMode LineDirectiveMode = LineDirectiveMode.Default;
    public bool ForceGLSLScalarBufferLayout = false;

    [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStruct)]
    public CompilerOptionEntry[] CompilerOptionEntries = [];

    public TargetDescription()
    { }
}

public unsafe struct CompilerOptionEntry
{
    public CompilerOptionName Name;
    public CompilerOptionValueKind Kind;

    public int IntValue0;
    public int IntValue1;
    public string StringValue0;
    public string StringValue1;


    public CompilerOptionEntry()
    { }
}