using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SlangNet.Bindings.Generated;

namespace SlangNet.ComWrappers;

public unsafe struct SessionDescription
{
    internal uint StructureSize = (uint)sizeof(SessionDesc);

    public List<TargetDesc> Targets = [];

    public SessionDescription() { }
}


public readonly unsafe record struct TargetDescription(CompileTarget Format = CompileTarget.TargetUnknown,
                                                       ProfileID Profile = ProfileID.ProfileUnknown,
                                                       uint Flags = 0,
                                                       FloatingPointMode FloatingPointMode = FloatingPointMode.Default,
                                                       LineDirectiveMode LineDirectiveMode = LineDirectiveMode.Default,
                                                       bool ForceGlslScalarBufferLayout = false,
                                                       CompilerOptionEntry[]? CompilerOptions = null)
{
    [CustomMarshaller(typeof(TargetDescription), MarshalMode.Default, typeof(TargetDescriptionMarshaller))]
    internal static class TargetDescriptionMarshaller
    {
        public static Bindings.Generated.TargetDesc ConvertToUnmanaged(in TargetDescription managed)
        {
            
        }

        public static TargetDescription ConvertToManaged(in TargetDesc unmanaged)
        {
            throw new NotImplementedException();
        }
    }
}




public readonly unsafe record struct CompilerOptionEntry(
    CompilerOptionName Name,
    CompilerOptionValueKind Kind,
    int IntValue0,
    int IntValue1,
    string? StringValue0,
    string? StringValue1)
{
    
    [CustomMarshaller(typeof(CompilerOptionEntry), MarshalMode.Default, typeof(CompilerOptionEntryMarshaller))]
    internal static class CompilerOptionEntryMarshaller
    {
        public static Bindings.Generated.CompilerOptionEntry ConvertToUnmanaged(in CompilerOptionEntry managed)
        {
            return new()
            {
                name = managed.Name,
                value = new()
                {
                    kind = managed.Kind,
                    intValue0 = managed.IntValue0,
                    intValue1 = managed.IntValue1,
                    stringValue0 = (sbyte*)Utf8StringMarshaller.ConvertToUnmanaged(managed.StringValue0),
                    stringValue1 = (sbyte*)Utf8StringMarshaller.ConvertToUnmanaged(managed.StringValue1),
                }
            };
        }

        public static CompilerOptionEntry ConvertToManaged(in Bindings.Generated.CompilerOptionEntry unmanaged)
        {
            throw new NotImplementedException();
        }

        public static void Free(in Bindings.Generated.CompilerOptionEntry unmanaged)
        {
            Utf8StringMarshaller.Free((byte*)unmanaged.value.stringValue0);
            Utf8StringMarshaller.Free((byte*)unmanaged.value.stringValue1);
        }
    }
}