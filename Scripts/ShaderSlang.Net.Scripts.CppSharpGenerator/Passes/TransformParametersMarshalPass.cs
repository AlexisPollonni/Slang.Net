using System.Runtime.InteropServices;
using CppSharp;
using CppSharp.AST;
using CppSharp.AST.Extensions;
using CppSharp.Passes;
using static ShaderSlang.Net.Scripts.CppSharpGenerator.AstAttributeFactory;
using Attribute = CppSharp.AST.Attribute;

namespace ShaderSlang.Net.Scripts.CppSharpGenerator.Passes;

internal sealed class TransformParametersMarshalPass : TranslationUnitPass
{
    public override bool VisitMethodDecl(Method method)
    {
        var returnType = method.ReturnType.Type;
        if (returnType.IsPrimitiveType(PrimitiveType.Bool))
        {
            method.Attributes.Add(new ReturnAttribute(CreateMarshalAsAttribute(UnmanagedType.I1)));
        }

        return base.VisitMethodDecl(method);
    }

    public override bool VisitParameterDecl(Parameter param)
    {
        // Safety check: ensure parameter has a valid type
        if (param.Type == null || param.QualifiedType.Type == null)
        {
            Diagnostics.Warning($"Parameter {param.Name} has null type, skipping transformation");
            return false;
        }

        var isOutParam = param.OriginalName.StartsWith("out", StringComparison.OrdinalIgnoreCase);
        var type = param.Type.Desugar();

        if (param.Namespace is not Function function)
        {
            Diagnostics.Warning(
                $"Parameter {param.Name} has no function namespace, skipping transformation"
            );
            return false;
        }

        if (isOutParam && function is { IsInternal: false, Access: AccessSpecifier.Public })
        {
            param.Usage = ParameterUsage.Out;
        }

        if (param.Type.IsPrimitiveType(PrimitiveType.Bool))
        {
            param.Attributes.Add(CreateMarshalAsAttribute(UnmanagedType.I1));
        }

        return base.VisitParameterDecl(param);
    }
}
