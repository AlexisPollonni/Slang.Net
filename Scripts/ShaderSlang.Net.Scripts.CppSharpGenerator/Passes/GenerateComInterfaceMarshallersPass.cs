using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using CppSharp;
using CppSharp.AST;
using CppSharp.AST.Extensions;
using CppSharp.Generators;
using CppSharp.Passes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Attribute = CppSharp.AST.Attribute;
using Type = CppSharp.AST.Type;

namespace ShaderSlang.Net.Scripts.CppSharpGenerator.Passes;

internal sealed class GenerateComInterfaceMarshallersPass : TranslationUnitPass
{
    private Class GenerateMarshallerClassFrom(Class managedClass, Class nativeClass)
    {
        var managedType = new QualifiedType(new CustomType(managedClass.ToGlobalFullName() + "?"));
        var nativePointerType = new QualifiedType(new PointerType(new QualifiedType(new BuiltinType(PrimitiveType.Void)))
                                                      { Modifier = PointerType.TypeModifier.Pointer });

        // ConvertToManaged method
        var convertToManagedMethod = new Method
        {
            Name = "ConvertToManaged",
            ReturnType = managedType,
            Parameters =
            {
                new()
                {
                    Name = "native",
                    QualifiedType = nativePointerType
                }
            },
            Access = AccessSpecifier.Public,
            IsStatic = true,
            Body = $"""
                    if (native is null)
                        return null;
                    return {managedClass.ToGlobalFullName()}.__GetOrCreateInstance(new __IntPtr(native), saveInstance: false);
                    """
        };
        
        var convertToUnmanagedMethod = new Method
        {
            Name = "ConvertToUnmanaged",
            ReturnType = nativePointerType,
            Parameters =
            {
                new()
                {
                    Name = "managed",
                    QualifiedType = managedType
                }
            },
            Access = AccessSpecifier.Public,
            IsStatic = true,
            Body = """
                   if (managed is null)
                       return null;
                   return managed.__Instance.ToPointer();
                   """
        };

        var marshallerClass = new Class
        {
            Name = managedClass.Name + "Marshaller",
            Namespace = managedClass.Namespace,
            Access = AccessSpecifier.Internal,
            IsPOD = true,
            Methods =
            {
                convertToManagedMethod,
                convertToUnmanagedMethod
            }
        };

        // Add CustomMarshallerAttribute
        marshallerClass.Attributes.Add(CreateCustomMarshallerAttribute(managedClass, MarshalMode.Default, marshallerClass));

        return marshallerClass;
    }

    private Class GenerateNativeLayoutStructFrom(Class nativeClass)
    {
        var fields = nativeClass.Layout.Fields.Select(nativeField =>
        {
            var f = new Field(nativeField.Name, nativeField.QualifiedType, AccessSpecifier.Internal);

            f.Attributes.Add(CreateFieldOffsetAttribute(nativeField.Offset));

            return f;
        });

        var internalsClass = new Class
        {
            Name = "__Native",
            Namespace = nativeClass,
            Access = AccessSpecifier.Internal,
            IsPOD = true,
            Fields = fields.ToList(),
            Type = ClassType.ValueType,
        };

        internalsClass.Attributes.Add(CreateStructLayoutAttribute(LayoutKind.Explicit, nativeClass.Layout.Size));

        return internalsClass;
    }

    public override bool VisitClassDecl(Class visClass)
    {
        if (visClass.IsISlangUnknown()) return base.VisitClassDecl(visClass);

        if (visClass.Attributes.Any(attribute => attribute.Type == typeof(NativeMarshallingAttribute))) return false;

        if (visClass is { IsStatic: false, Ignore: false })
        {
            visClass.Attributes.Add(CreateNativeMarshallingAttribute(visClass));

            if (visClass.Name.EndsWith("Desc") || visClass.Name.EndsWith("Flag"))
            {
                visClass.Type = ClassType.ValueType;
                visClass.IsPOD = true;
            }
        }

        var nativeLayoutStruct = GenerateNativeLayoutStructFrom(visClass);

        return base.VisitClassDecl(visClass);
    }

    public override bool VisitParameterDecl(Parameter parameter)
    {
        if (parameter.Namespace is Method { Namespace: Class parentClass } && parentClass.IsISlangUnknown())
        {
            var final = parameter.Type.SkipPointerRefs();

            final.TryGetClass(out var paramPointeeClass);
            if (paramPointeeClass is not null && paramPointeeClass.IsValueType)
            {
                parameter.QualifiedType = new(new PointerType(new QualifiedType(final))
                                                  { Modifier = PointerType.TypeModifier.RVReference });
            }
        }

        return base.VisitParameterDecl(parameter);
    }

    private static Attribute CreateStructLayoutAttribute(LayoutKind kind, int size)
    {
        return new()
        {
            Type = typeof(StructLayoutAttribute),
            Value = $"{typeof(LayoutKind).ToGlobalFullName()}.{kind}, Size = {size}"
        };
    }

    private static Attribute CreateFieldOffsetAttribute(uint offset)
    {
        return new()
        {
            Type = typeof(FieldOffsetAttribute),
            Value = offset.ToString()
        };
    }

    private static Attribute CreateNativeMarshallingAttribute(Class marshalledType)
    {
        var value = $"typeof({marshalledType.ToGlobalFullName()}.{marshalledType.Name}Marshaller)";

        return new()
        {
            Type = typeof(NativeMarshallingAttribute),
            Value = value
        };
    }

    private static Attribute CreateCustomMarshallerAttribute(Class managedType,
                                                             MarshalMode marshalMode,
                                                             Class marshallerType)
    {
        return new()
        {
            Type = typeof(CustomMarshallerAttribute),
            Value
                = $"typeof({managedType.ToGlobalFullName()}), {typeof(MarshalMode).ToGlobalFullName()}.{marshalMode}, typeof({marshallerType.ToGlobalFullName()}))"
        };
    }
}