using System.Runtime.InteropServices;
using CppSharp;
using CppSharp.AST;
using CppSharp.AST.Extensions;
using CppSharp.Passes;
using static ShaderSlang.Net.Scripts.CppSharpGenerator.AstAttributeFactory;
using Attribute = CppSharp.AST.Attribute;
using Type = CppSharp.AST.Type;

namespace ShaderSlang.Net.Scripts.CppSharpGenerator.Passes;

internal sealed class TransformParametersMarshalPass : TranslationUnitPass
{
    public override bool VisitMethodDecl(Method method)
    {
        if (!ShouldTransformMethod(method))
            return false;

        var newReturnType = TransformTypeFromNativeToManaged(
            method.ReturnType,
            out var marshallingAttribute
        );

        method.ReturnType = newReturnType;
        if (marshallingAttribute is not null)
            method.Attributes.Add(new ReturnAttribute(marshallingAttribute));

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

        if (param.Namespace is not Method method)
        {
            Diagnostics.Warning(
                $"Parameter {param.Name} has no function namespace, skipping transformation"
            );
            return false;
        }

        if (isOutParam && method is { IsInternal: false, Access: AccessSpecifier.Public })
        {
            param.Usage = ParameterUsage.Out;
        }

        var newParamType = TransformTypeFromNativeToManaged(
            param.QualifiedType,
            out var marshallingAttribute,
            isOutParam
        );

        param.QualifiedType = newParamType;
        if (marshallingAttribute is not null)
            param.Attributes.Add(marshallingAttribute);

        return base.VisitParameterDecl(param);
    }

    private static QualifiedType TransformTypeFromNativeToManaged(
        QualifiedType type,
        out Attribute? marshallingAttribute,
        bool isOutParam = false
    )
    {
        marshallingAttribute = null;
        var desugared = type.Type.Desugar();

        if (desugared.IsPrimitiveType(PrimitiveType.Bool))
        {
            marshallingAttribute = CreateMarshalAsAttribute(UnmanagedType.I1);
            return new(desugared);
        }

        if (desugared.IsPointerToPrimitiveType(PrimitiveType.Char))
        {
            var stringType = new QualifiedType(new CILType(typeof(string)));
            return desugared.GetPointee().IsPointer() //is double pointer
                ? isOutParam
                    ? stringType
                    : new(new PointerType(stringType))
                : stringType;
        }

        if (desugared.IsPointerTo(out TagType tagType) && tagType.TryGetClass(out var classDef))
        {
            var isDoublePointer = desugared.GetPointee().IsPointer();
            if (isDoublePointer && !isOutParam)
            {
                //is an array of pointers, need to set to span of managed types
                return type; //TODO
            }

            //Is an out parameter just set to the managed type
            return new(tagType);
        }

        return type;
    }

    private static bool ShouldTransformMethod(Method method)
    {
        return method.Attributes.Any(attribute => attribute.Type == typeof(LibraryImportAttribute))
            || method.Namespace is Class { IsInterface: true };
    }
}
