using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using CppSharp.AST;
using CppSharp.AST.Extensions;
using CppSharp.Passes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static ShaderSlang.Net.Scripts.CppSharpGenerator.AstAttributeFactory;
using PointerType = CppSharp.AST.PointerType;
using TemplateParameterType = CppSharp.Parser.AST.TemplateParameterType;
using Type = CppSharp.AST.Type;

namespace ShaderSlang.Net.Scripts.CppSharpGenerator.Passes;

internal sealed class GenerateMarshallersForClassesPass : TranslationUnitPass
{
    private readonly Dictionary<Class, Class> _managedToNativeClass = [];

    private static string GenerateConvertToManaged(
        Parameter unmanagedParameter,
        Class managedClass,
        Class nativeClass
    )
    {
        var marshallingStatements = new List<StatementSyntax>();

        if (managedClass.Fields.Count == 0 && managedClass.Layout.Size == 0)
        {
            //is an opaque type, need to marshal with instance pointer
            marshallingStatements.Add(
                ParseStatement($"managed.Instance = {unmanagedParameter.Name};")
            );
        }

        foreach (var (index, property) in managedClass.Properties.Index())
        {
            var nativeField = nativeClass.Fields[index];
            var marshaller = TypeMarshallerPass.GetMarshallerFor(nativeField.Type, property.Type);

            marshaller.WriteUnmanagedToManagedConversion(
                marshallingStatements,
                nativeField.Type,
                property.Type,
                $"{unmanagedParameter.Name}->{nativeField.Name}",
                $"managed.{property.Name}"
            );
        }

        return $"""
            if ({unmanagedParameter.Name} is null)
                return null;

            var managed = new {managedClass.ToGlobalFullName()}();
                
            {string.Join(" ", marshallingStatements.Select(statement => statement.ToFullString()))}
                
            return managed;
            """;
    }

    private static string GenerateConvertToUnmanaged(
        Parameter managedParameter,
        Class managedClass,
        Class nativeClass
    )
    {
        var marshallingStatements = new List<StatementSyntax>();

        if (managedClass.Fields.Count == 0 && managedClass.Layout.Size == 0)
        {
            return $"return {managedParameter.Name}.Instance;";
        }

        foreach (var (index, property) in managedClass.Properties.Index())
        {
            var nativeField = nativeClass.Fields[index];
            var marshaller = TypeMarshallerPass.GetMarshallerFor(nativeField.Type, property.Type);

            marshaller.WriteManagedToUnmanagedConversion(
                marshallingStatements,
                nativeField.Type,
                property.Type,
                $"managed.{property.Name}",
                $"{managedParameter.Name}->{nativeField.Name}"
            );
        }

        return $"""
            if ({managedParameter.Name} is null)
                return null;

            var native = ({nativeClass.Name}*)  {typeof(NativeMemory).ToGlobalFullName()}.AllocZeroed((UIntPtr)sizeof({nativeClass.Name}));

            {string.Join(" ", marshallingStatements.Select(statement => statement.ToFullString()))}

            return native;
            """;
    }

    private static Class GenerateMarshallerClassFrom(Class managedClass, Class nativeClass)
    {
        var managedType = new QualifiedType(new NullableType(managedClass));
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
        };

        var marshallerClass = GetMarshallerClassFor(managedClass);

        // wire up namespaces
        convertToManagedMethod.Namespace = marshallerClass;
        convertToUnmanagedMethod.Namespace = marshallerClass;
        convertToManagedMethod.Parameters.Single().Namespace = convertToManagedMethod;
        convertToUnmanagedMethod.Parameters.Single().Namespace = convertToUnmanagedMethod;

        marshallerClass.Attributes.Add(
            CreateCustomMarshallerAttribute(
                managedClass.IsValueType
                    ? new NullableType(managedClass)
                    : new TagType(managedClass),
                MarshalMode.Default,
                marshallerClass
            )
        );

        marshallerClass.Methods.AddRange([convertToManagedMethod, convertToUnmanagedMethod]);

        convertToManagedMethod.Body = GenerateConvertToManaged(
            convertToManagedMethod.Parameters.Single(),
            managedClass,
            nativeClass
        );
        convertToUnmanagedMethod.Body = GenerateConvertToUnmanaged(
            convertToUnmanagedMethod.Parameters.Single(),
            managedClass,
            nativeClass
        );

        return marshallerClass;
    }

    private static Class GetMarshallerClassFor(Class managedClass)
    {
        var nGlobal = managedClass.TranslationUnit;

        const string marshallerClassName = "Marshallers";
        var marshallerClass =
            nGlobal.FindClass(marshallerClassName)
            ?? new Class
            {
                Name = marshallerClassName,
                Namespace = nGlobal,
                Access = AccessSpecifier.Internal,
                IsStatic = true,
                IsPOD = true,
            };

        if (!nGlobal.Declarations.Contains(marshallerClass))
        {
            nGlobal.Declarations.Add(marshallerClass);
        }

        return marshallerClass;
    }

    private Class GenerateNativeLayoutStructFrom(Class managedClass)
    {
        var fields = managedClass
            .Layout.Fields.Select(nativeField =>
            {
                var fieldType = nativeField.QualifiedType;

                fieldType.Type.GetFinalPointee().TryGetClass(out var fieldClass);

                if (fieldClass is null && fieldType.Type.IsPointerTo(out TypedefType typedef))
                    typedef.Declaration.Type.TryGetClass(out fieldClass);

                if (
                    fieldClass is not null
                    && _managedToNativeClass.TryGetValue(fieldClass, out var nativeClass)
                )
                {
                    fieldType.Type.GetFinalPointer().QualifiedPointee.Type = new TagType(
                        nativeClass
                    );
                }

                var f = new Field(nativeField.Name, fieldType, AccessSpecifier.Internal);

                f.Attributes.Add(CreateFieldOffsetAttribute(nativeField.Offset));

                f.ExcludeFromPasses.Add(typeof(FieldToPropertyPass));

                return f;
            })
            .ToList();

        var nativeClass = new Class
        {
            Name = managedClass.Name + "Native",
            Access = AccessSpecifier.Internal,
            IsPOD = true,
            Fields = fields,
            Type = ClassType.ValueType,
        };

        foreach (var field in fields)
        {
            field.Namespace = nativeClass;
            field.Class = nativeClass;
        }

        nativeClass.Attributes.Add(
            CreateStructLayoutAttribute(LayoutKind.Explicit, managedClass.Layout.Size)
        );

        _managedToNativeClass.Add(managedClass, nativeClass);

        return nativeClass;
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

        nativeLayoutStruct.Namespace = marshallerClass;
        marshallerClass.Declarations.Add(nativeLayoutStruct);

        visClass.Attributes.Add(CreateNativeMarshallingAttribute(marshallerClass));

        // if is an opaque type, add an instance pointer for marshalling purposes
        if (visClass.Fields.Count == 0 && visClass.Layout.Size == 0)
        {
            visClass.Properties.Add(
                new()
                {
                    Name = "Instance",
                    QualifiedType = new(
                        new PointerType(new QualifiedType(new TagType(nativeLayoutStruct)))
                    ),
                    Access = AccessSpecifier.Internal,
                    Namespace = visClass,
                }
            );
        }

        return res;
    }

    public override bool VisitMethodDecl(Method method)
    {
        if (!method.IsPure)
            method.ExplicitlyIgnore();

        return base.VisitMethodDecl(method);
    }
}

internal abstract class TypeMarshallerPass
{
    private static readonly TypeMarshallerPass[] AllPasses =
    [
        new StringMarshallerPass(),
        new MissingCommentMarshallerPass(), // Fallback marshaller, should be last in the list
    ];

    public static TypeMarshallerPass GetMarshallerFor(Type nativeType, Type managedType)
    {
        return AllPasses.First(pass => pass.IsApplicable(nativeType, managedType));
    }

    /// <summary> Determines if this marshaller is applicable for the given native and managed types. </summary>
    public abstract bool IsApplicable(Type nativeType, Type managedType);

    public abstract void WriteUnmanagedToManagedConversion(
        List<StatementSyntax> conversionStatements,
        Type nativeType,
        Type managedType,
        string nativeVarName,
        string managedVarName
    );

    public abstract void WriteManagedToUnmanagedConversion(
        List<StatementSyntax> conversionStatements,
        Type nativeType,
        Type managedType,
        string nativeVarName,
        string managedVarName
    );

    public abstract void WriteCleanupStatements(
        List<StatementSyntax> cleanupStatements,
        Type nativeType,
        string nativeVarName
    );
}

file sealed class MissingCommentMarshallerPass : TypeMarshallerPass
{
    public override bool IsApplicable(Type nativeType, Type managedType)
    {
        return true; // Fallback marshaller, applicable to all types
    }

    public override void WriteUnmanagedToManagedConversion(
        List<StatementSyntax> conversionStatements,
        Type nativeType,
        Type managedType,
        string nativeVarName,
        string managedVarName
    )
    {
        // No conversion, just write comment to indicate missing marshaller
        conversionStatements.Add(
            ParseStatement(
                $"// No marshaller found for native type '{nativeType}' and managed type '{managedType}'. Consider implementing a custom marshaller for this type pair."
            )
        );
    }

    public override void WriteManagedToUnmanagedConversion(
        List<StatementSyntax> conversionStatements,
        Type nativeType,
        Type managedType,
        string nativeVarName,
        string managedVarName
    )
    {
        // No conversion, just write comment to indicate missing marshaller
        conversionStatements.Add(
            ParseStatement(
                $"// No marshaller found for managed type '{managedType}' and native type '{nativeType}'. Consider implementing a custom marshaller for this type pair."
            )
        );
    }

    public override void WriteCleanupStatements(
        List<StatementSyntax> cleanupStatements,
        Type nativeType,
        string nativeVarName
    )
    {
        // No cleanup needed
    }
}

file sealed class StringMarshallerPass : TypeMarshallerPass
{
    private readonly string _marshallerName = typeof(Utf8StringMarshaller).ToGlobalFullName();

    public override bool IsApplicable(Type nativeType, Type managedType)
    {
        return nativeType.IsPointerToPrimitiveType(PrimitiveType.Char)
            && managedType is BuiltinType { Type: PrimitiveType.String };
    }

    public override void WriteUnmanagedToManagedConversion(
        List<StatementSyntax> conversionStatements,
        Type nativeType,
        Type managedType,
        string nativeVarName,
        string managedVarName
    )
    {
        conversionStatements.Add(
            ParseStatement(
                $"{managedVarName} = {_marshallerName}.ConvertToManaged((byte*){nativeVarName});"
            )
        );
    }

    public override void WriteManagedToUnmanagedConversion(
        List<StatementSyntax> conversionStatements,
        Type nativeType,
        Type managedType,
        string nativeVarName,
        string managedVarName
    )
    {
        conversionStatements.Add(
            ParseStatement(
                $"{nativeVarName} = ({nativeType.ToSyntax().ToFullString()}){_marshallerName}.ConvertToUnmanaged({managedVarName});"
            )
        );
    }

    public override void WriteCleanupStatements(
        List<StatementSyntax> cleanupStatements,
        Type nativeType,
        string nativeVarName
    )
    {
        // Free the unmanaged string after marshalling
        cleanupStatements.Add(ParseStatement($"{_marshallerName}.FreeUnmanaged({nativeVarName});"));
    }
}
