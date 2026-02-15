using CppSharp.AST;
using CppSharp.Generators;
using CppSharp.Types;
using Type = CppSharp.AST.Type;

namespace ShaderSlang.Net.Scripts.CppSharp;

[TypeMap("SlangResult", GeneratorKind.CSharp_ID)]
internal class SlangResultMap : TypeMap
{
    public override Type SignatureType(TypePrinterContext ctx)
    {
        return new CustomType("global::ShaderSlang.Net.Bindings.SlangResult");
    }
}