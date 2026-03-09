using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using CppSharp.Parser.AST;
using Attribute = CppSharp.AST.Attribute;
using Class = CppSharp.AST.Class;
using Type = CppSharp.AST.Type;

namespace ShaderSlang.Net.Scripts.CppSharpGenerator;

internal sealed class AstAttributeFactory
{
    public static Attribute CreateMarshalAsAttribute(UnmanagedType unmanagedType)
    {
        return new()
        {
            Type = typeof(MarshalAsAttribute),
            Value = $"{typeof(UnmanagedType).ToGlobalFullName()}.{unmanagedType}",
        };
    }

    public static Attribute CreateLibraryImportAttribute(
        string libraryName,
        string entryPoint,
        StringMarshalling stringMarshalling
    )
    {
        return new()
        {
            Type = typeof(LibraryImportAttribute),
            Value =
                $"\"{libraryName}\", EntryPoint = \"{entryPoint}\", StringMarshalling = {typeof(StringMarshalling).ToGlobalFullName()}.{stringMarshalling}",
        };
    }

    public static Attribute CreateComInterfaceAttribute(StringMarshalling stringMarshalling)
    {
        var stringMarshallingString =
            $"global::{typeof(StringMarshalling).FullName}.{stringMarshalling}";

        return new()
        {
            //TODO: custom string marshalling
            Type = typeof(GeneratedComInterfaceAttribute),
            Value = $"StringMarshalling = {stringMarshallingString}",
        };
    }

    public static Attribute CreateGuidAttribute(Guid guid)
    {
        return new() { Type = typeof(GuidAttribute), Value = $"\"{guid:D}\"" };
    }

    public static Attribute CreateNativeMarshallingAttribute(Class marshallerType)
    {
        var value = $"typeof({marshallerType.ToGlobalFullName()})";

        return new() { Type = typeof(NativeMarshallingAttribute), Value = value };
    }

    public static Attribute CreateStructLayoutAttribute(LayoutKind kind, int size)
    {
        return new()
        {
            Type = typeof(StructLayoutAttribute),
            Value = $"{typeof(LayoutKind).ToGlobalFullName()}.{kind}, Size = {size}",
        };
    }

    public static Attribute CreateFieldOffsetAttribute(uint offset)
    {
        return new() { Type = typeof(FieldOffsetAttribute), Value = offset.ToString() };
    }

    public static Attribute CreateCustomMarshallerAttribute(
        Type managedType,
        MarshalMode marshalMode,
        Class marshallerType
    )
    {
        return new()
        {
            Type = typeof(CustomMarshallerAttribute),
            Value =
                $"typeof({managedType.ToSyntax()}), {typeof(MarshalMode).ToGlobalFullName()}.{marshalMode}, typeof({marshallerType.ToGlobalFullName()})",
        };
    }
}
