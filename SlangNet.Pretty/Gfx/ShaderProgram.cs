using System;
using SlangNet.Internal;

namespace SlangNet.Gfx;

[GenerateThrowingMethods]
public partial class ShaderProgram : COMObject<IShaderProgram>
{
    internal unsafe ShaderProgram(IShaderProgram* pointer) : base(pointer)
    { }
    
    public unsafe TypeReflection FindTypeByName(string name)
    {
        using var nameUtf8 = new Utf8String(name);
        var typeReflection = Pointer->findTypeByName(nameUtf8);
        if (typeReflection == null)
            throw new InvalidOperationException($"Type '{name}' not found in shader program");
        
        return new(typeReflection);
    }
}
