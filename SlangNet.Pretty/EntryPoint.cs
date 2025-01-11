namespace SlangNet;

public sealed unsafe class EntryPoint : ComponentType
{
    public new IEntryPoint* Pointer => (IEntryPoint*)base.Pointer;

    internal EntryPoint(IEntryPoint* pointer) : base((IComponentType*)pointer)
    {
    }
}
