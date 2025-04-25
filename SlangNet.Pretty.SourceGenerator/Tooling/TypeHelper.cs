using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SlangNet.Pretty.SourceGenerator.Tooling;

static class TypeHelper
{
    private const string MarshalToNativeTypeName = "IMarshalsToNative";
    private const string ComObjectTypeName = "COMObject";

    public static bool ImplementsIMarshalToNative(this ITypeSymbol type)
    {
        return GetNativeTypeFromMarshalInterface(type) != null;
    }

    public static ITypeSymbol? GetNativeTypeFromMarshalInterface(this ITypeSymbol type) =>
        (type.AllInterfaces.Where(interfaceType => interfaceType.IsGenericType)
             .Select(interfaceType => new { interfaceType, originalDefinition = interfaceType.OriginalDefinition })
             .Where(@t => @t.originalDefinition.Name == MarshalToNativeTypeName)
             .Select(@t => @t.interfaceType.TypeArguments[0])).FirstOrDefault();

    public static ITypeSymbol? GetNativeTypeFromComObject(this ITypeSymbol type)
    {
        var cur = type.BaseType;
        while (cur is not null)
        {
            if(cur.OriginalDefinition.Name == ComObjectTypeName)
                return cur.TypeArguments[0];

            cur = cur.BaseType;
        }

        return null;
    }

    public static ITypeSymbol? GetNativeType(this ITypeSymbol type, Compilation comp)
    {
        // First check if it implements IMarshalToNative<TNative>
        var nativeType = GetNativeTypeFromMarshalInterface(type);
        if (nativeType != null) return nativeType;

        // Then check if it is a COM object
        nativeType = GetNativeTypeFromComObject(type);
        if (nativeType != null) return nativeType;

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

        if (type is not INamedTypeSymbol { IsGenericType: true } named) return null;
        
        var unbound = named.ConstructUnboundGenericType();

        if (unbound.Equals(spanType, SymbolEqualityComparer.Default) ||
            unbound.Equals(readonlySpanType, SymbolEqualityComparer.Default))
        {
            return named.TypeArguments[0].GetNativeType(comp);
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
            ? ptrPtrSymbol.PointedAtType
            : null;
    }

    public static bool IsDoublePointer(this ITypeSymbol type)
    {
        return GetTypeFromDoublePointerType(type) is not null;
    }

    public static bool IsUnsafe(this IMethodSymbol method)
    {
        return method.DeclaringSyntaxReferences.OfType<MethodDeclarationSyntax>()
                     .Any(syntax => syntax.Modifiers.Any(m => m.IsKind(SyntaxKind.UnsafeKeyword)));
    }

    public static string ToFullyQualified(this ITypeSymbol type)
    {
        return type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.WithMiscellaneousOptions(SymbolDisplayMiscellaneousOptions.IncludeNullableReferenceTypeModifier));
    }
}