namespace SlangNet;

public sealed unsafe class TypeConformance : ComponentType
{
    public new ITypeConformance* Pointer => (ITypeConformance*)base.Pointer;

    internal TypeConformance(ITypeConformance* pointer) : base((IComponentType*)pointer)
    {
    }
}
