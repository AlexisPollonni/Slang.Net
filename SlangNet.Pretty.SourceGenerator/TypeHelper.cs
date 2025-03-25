using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SlangNet.Pretty.SourceGenerator;

internal static class TypeHelper
{
    private const string MarshalsToNativeTypeName = "IMarshalsToNative";
    private const string ComObjectTypeName = "COMObject";

    public static bool ImplementsIMarshalToNative(this ITypeSymbol type)
    {
        return GetNativeTypeFromMarshalInterface(type) != null;
    }

    public static ITypeSymbol? GetNativeTypeFromMarshalInterface(this ITypeSymbol type)
    {
        foreach (var interfaceType in type.AllInterfaces)
        {
            if (!interfaceType.IsGenericType)
                continue;

            var originalDefinition = interfaceType.OriginalDefinition;
            if (originalDefinition.Name != MarshalsToNativeTypeName)
                continue;

            // Get the type argument (TNative)
            return interfaceType.TypeArguments[0];
        }

        return null;
    }

    public static ITypeSymbol? GetNativeTypeFromComObject(this ITypeSymbol type)
    {
        while (type.BaseType is not null)
        {
            if (!type.BaseType.IsGenericType)
            {
                type = type.BaseType;
                continue;
            }

            var originalDefinition = type.BaseType.OriginalDefinition;

            if (originalDefinition.Name == ComObjectTypeName) return type.BaseType.TypeArguments[0];
            type = type.BaseType;
        }

        return null;
    }



    public static ITypeSymbol? GetNativeType(this ITypeSymbol thisType, Compilation comp)
    {
        var type = thisType.StripNullable();

        // First check if it implements IMarshalToNative<TNative>
        var nativeType = GetNativeTypeFromMarshalInterface(type);
        if (nativeType != null)
            return nativeType;

        // Then check if it is a COM object
        nativeType = GetNativeTypeFromComObject(type);
        if (nativeType != null)
            return nativeType;

        //Then check if it is a string
        if (type.SpecialType == SpecialType.System_String)
            return comp.CreatePointerTypeSymbol(comp.GetSpecialType(SpecialType.System_SByte));

        //Check if it is a readonly collection of one of the types above
        var collectionType = type.GetTypeFromIReadonlyCollection(comp);
        if (collectionType is not null)
        {
            var nativeTypeArgVersion = collectionType.GetNativeType(comp);
            return nativeTypeArgVersion is null ? null : comp.CreatePointerTypeSymbol(nativeTypeArgVersion);
        }

        var spanType = comp.GetTypeByMetadataName("System.Span`1");
        var readonlySpanType = comp.GetTypeByMetadataName("System.ReadonlySpan`1");

        if (type is INamedTypeSymbol { IsGenericType: true } named)
        {
            var unbound = named.ConstructUnboundGenericType();

            if (unbound.Equals(spanType, SymbolEqualityComparer.Default) || unbound.Equals(readonlySpanType, SymbolEqualityComparer.Default))
            {
                return named.TypeArguments[0].GetNativeType(comp);
            }
        }
        
        return null;
    }

    public static INamedTypeSymbol? GetImplementedSpecialType(this ITypeSymbol type, SpecialType sType, Compilation comp)
    {
        return type.AllInterfaces.FirstOrDefault(s => s.OriginalDefinition.Equals(comp.GetSpecialType(sType),
                                                                           SymbolEqualityComparer.Default));
    }

    public static ITypeSymbol? GetTypeFromIReadonlyCollection(this ITypeSymbol type, Compilation comp)
    {
        var impl = type.GetImplementedSpecialType(SpecialType.System_Collections_Generic_IReadOnlyCollection_T, comp);
        return impl?.TypeArguments[0];
    }

    public static ITypeSymbol? GetTypeFromDoublePointerType(this ITypeSymbol type)
    {
        return type is IPointerTypeSymbol { PointedAtType: IPointerTypeSymbol ptrPtrSymbol } 
            ? ptrPtrSymbol.PointedAtType : null;
    }


    public static bool IsDoublePointer(this ITypeSymbol type)
    {
        return GetTypeFromDoublePointerType(type) is not null;
    }

    public static bool IsUnsafe(this IMethodSymbol method)
    {
        return method.DeclaringSyntaxReferences.FirstOrDefault()?.GetSyntax() is MethodDeclarationSyntax methodSyntax
            && methodSyntax.Modifiers.Any(m => m.IsKind(SyntaxKind.UnsafeKeyword));
    }

    public static ITypeSymbol StripNullable(this ITypeSymbol type)
    {
        return type.NullableAnnotation == NullableAnnotation.Annotated ? type.OriginalDefinition : type;
    }
}