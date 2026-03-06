using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using CppSharp.AST;
using CppSharp.AST.Extensions;
using CppSharp.Passes;
using static ShaderSlang.Net.Scripts.CppSharpGenerator.AstAttributeFactory;

namespace ShaderSlang.Net.Scripts.CppSharpGenerator.Passes;

internal sealed class GenerateMarshallersForClassesPass : TranslationUnitPass
{
    private static Class GenerateMarshallerClassFrom(Class managedClass, Class nativeClass)
    {
        var managedType = new QualifiedType(new CustomType(managedClass.ToGlobalFullName() + "?"));
        var nativePointerType = new QualifiedType(
            new PointerType(new QualifiedType(new TagType(nativeClass)))
            {
                Modifier = PointerType.TypeModifier.Pointer,
            }
        );

        // ConvertToManaged method
        var convertToManagedMethod = new Method
        {
            Name = "ConvertToManaged",
            ReturnType = managedType,
            Parameters =
            {
                new() { Name = "native", QualifiedType = nativePointerType },
            },
            Access = AccessSpecifier.Public,
            IsStatic = true,
            Body = $"""
                if (native is null)
                    return null;
                return {managedClass.ToGlobalFullName()}.__GetOrCreateInstance(new __IntPtr(native), saveInstance: false);
                """,
        };

        var convertToUnmanagedMethod = new Method
        {
            Name = "ConvertToUnmanaged",
            ReturnType = nativePointerType,
            Parameters =
            {
                new() { Name = "managed", QualifiedType = managedType },
            },
            Access = AccessSpecifier.Public,
            IsStatic = true,
            Body = """
                if (managed is null)
                    return null;
                return managed.__Instance.ToPointer();
                """,
        };

        var marshallerClass = new Class
        {
            Name = managedClass.Name + "Marshaller",
            Namespace = managedClass,
            Access = AccessSpecifier.Internal,
            IsStatic = true,
            IsPOD = true,
            Methods = { convertToManagedMethod, convertToUnmanagedMethod },
        };

        // wire up namespaces
        convertToManagedMethod.Namespace = marshallerClass;
        convertToManagedMethod.Parameters.Single().Namespace = convertToManagedMethod;
        convertToUnmanagedMethod.Namespace = marshallerClass;
        convertToUnmanagedMethod.Parameters.Single().Namespace = convertToUnmanagedMethod;

        marshallerClass.Attributes.Add(
            CreateCustomMarshallerAttribute(managedClass, MarshalMode.Default, marshallerClass)
        );

        return marshallerClass;
    }

    private static Class GenerateNativeLayoutStructFrom(Class nativeClass)
    {
        var fields = nativeClass
            .Layout.Fields.Select(nativeField =>
            {
                var f = new Field(
                    nativeField.Name,
                    nativeField.QualifiedType,
                    AccessSpecifier.Internal
                );

                f.Attributes.Add(CreateFieldOffsetAttribute(nativeField.Offset));

                f.ExcludeFromPasses.Add(typeof(FieldToPropertyPass));

                return f;
            })
            .ToList();

        var internalsClass = new Class
        {
            Name = "__Native",
            Namespace = nativeClass,
            Access = AccessSpecifier.Internal,
            IsPOD = true,
            Fields = fields,
            Type = ClassType.ValueType,
        };

        foreach (var field in fields)
        {
            field.Namespace = internalsClass;
            field.Class = internalsClass;
        }

        internalsClass.Attributes.Add(
            CreateStructLayoutAttribute(LayoutKind.Explicit, nativeClass.Layout.Size)
        );

        return internalsClass;
    }

    public override bool VisitClassDecl(Class visClass)
    {
        if (Visited.Contains(visClass))
            return base.VisitClassDecl(visClass);

        if (visClass.IsISlangUnknown())
            return false;

        if (
            visClass.Attributes.Any(attribute =>
                attribute.Type == typeof(NativeMarshallingAttribute)
            )
        )
            return false;

        if (visClass is not { IsStatic: false, Ignore: false })
            return false;

        if (visClass.Name.EndsWith("Desc") || visClass.Name.EndsWith("Flag"))
        {
            visClass.Type = ClassType.ValueType;
            visClass.IsPOD = true;
        }

        // Continuing pass first to avoid infinite recursion
        var res = base.VisitClassDecl(visClass);

        var nativeLayoutStruct = GenerateNativeLayoutStructFrom(visClass);
        var marshallerClass = GenerateMarshallerClassFrom(visClass, nativeLayoutStruct);

        visClass.Attributes.Add(CreateNativeMarshallingAttribute(marshallerClass));

        visClass.Declarations.AddRange([nativeLayoutStruct, marshallerClass]);

        return res;
    }

    public override bool VisitMethodDecl(Method method)
    {
        if (!method.IsPure)
            method.ExplicitlyIgnore();

        return base.VisitMethodDecl(method);
    }

    public override bool VisitParameterDecl(Parameter parameter)
    {
        if (
            parameter.Namespace is Method { Namespace: Class parentClass }
            && parentClass.IsISlangUnknown()
        )
        {
            var final = parameter.Type.SkipPointerRefs();

            final.TryGetClass(out var paramPointeeClass);
            if (paramPointeeClass is not null && paramPointeeClass.IsValueType)
            {
                parameter.QualifiedType = new(
                    new PointerType(new QualifiedType(final))
                    {
                        Modifier = PointerType.TypeModifier.RVReference,
                    }
                );
            }
        }

        return base.VisitParameterDecl(parameter);
    }
}
