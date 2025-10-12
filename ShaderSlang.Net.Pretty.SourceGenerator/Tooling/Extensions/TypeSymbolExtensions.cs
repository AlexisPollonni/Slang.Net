using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ShaderSlang.Net.Pretty.SourceGenerator.Tooling.Extensions;

static class TypeSymbolExtensions
{
    private const string MarshalToNativeTypeName = "IMarshalsToNative";
    private const string ComObjectTypeName = "COMObject";

    extension(ITypeSymbol type)
    {
        public bool ImplementsIMarshalToNative()
        {
            return GetNativeTypeFromMarshalInterface(type) != null;
        }

        public ITypeSymbol? GetNativeTypeFromMarshalInterface() =>
            (
                type
                    .AllInterfaces.Where(interfaceType => interfaceType.IsGenericType)
                    .Select(interfaceType => new
                    {
                        interfaceType,
                        originalDefinition = interfaceType.OriginalDefinition,
                    })
                    .Where(@t => @t.originalDefinition.Name == MarshalToNativeTypeName)
                    .Select(@t => @t.interfaceType.TypeArguments[0])
            ).FirstOrDefault();

        public ITypeSymbol? GetNativeTypeFromComObject()
        {
            var cur = type.BaseType;
            while (cur is not null)
            {
                if (cur.OriginalDefinition.Name == ComObjectTypeName)
                    return cur.TypeArguments[0];

                cur = cur.BaseType;
            }

            return null;
        }

        public ITypeSymbol? GetNativeType(Compilation comp)
        {
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
                return nativeTypeArgVersion is null
                    ? null
                    : comp.CreatePointerTypeSymbol(nativeTypeArgVersion);
            }

            var spanType = comp.GetTypeByMetadataName("System.Span`1");
            var readonlySpanType = comp.GetTypeByMetadataName("System.ReadonlySpan`1");

            if (type is not INamedTypeSymbol { IsGenericType: true } named)
                return null;

            var unbound = named.ConstructUnboundGenericType();

            if (
                unbound.Equals(spanType, SymbolEqualityComparer.Default)
                || unbound.Equals(readonlySpanType, SymbolEqualityComparer.Default)
            )
            {
                return named.TypeArguments[0].GetNativeType(comp);
            }

            return null;
        }

        public INamedTypeSymbol? GetImplementedSpecialType(SpecialType sType, Compilation comp)
        {
            return type.AllInterfaces.FirstOrDefault(s =>
                s.OriginalDefinition.Equals(
                    comp.GetSpecialType(sType),
                    SymbolEqualityComparer.Default
                )
            );
        }

        public ITypeSymbol? GetTypeFromIReadonlyCollection(Compilation comp)
        {
            var impl = type.GetImplementedSpecialType(
                SpecialType.System_Collections_Generic_IReadOnlyCollection_T,
                comp
            );
            return impl?.TypeArguments[0];
        }

        public ITypeSymbol? GetTypeFromDoublePointerType()
        {
            return type is IPointerTypeSymbol { PointedAtType: IPointerTypeSymbol ptrPtrSymbol }
                ? ptrPtrSymbol.PointedAtType
                : null;
        }

        public bool IsDoublePointer()
        {
            return GetTypeFromDoublePointerType(type) is not null;
        }

        public bool IsSpanType()
        {
            // Quick check if it's even a ref-like type
            if (!type.IsRefLikeType)
                return false;

            var fullName = type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
            return fullName.StartsWith("global::System.Span<")
                || fullName.StartsWith("global::System.ReadOnlySpan<");
        }

        public string ToFullyQualified()
        {
            return type.ToDisplayString(
                SymbolDisplayFormat.FullyQualifiedFormat.WithMiscellaneousOptions(
                    SymbolDisplayMiscellaneousOptions.IncludeNullableReferenceTypeModifier
                )
            );
        }
    }

    extension(IMethodSymbol method)
    {
        public bool IsUnsafe()
        {
            return method
                .DeclaringSyntaxReferences.OfType<MethodDeclarationSyntax>()
                .Any(syntax => syntax.Modifiers.Any(m => m.IsKind(SyntaxKind.UnsafeKeyword)));
        }

        public IEnumerable<(IParameterSymbol, IParameterSymbol)> GetMarshalUsingSpanCountPairs()
        {
            return method
                .Parameters.Select(paramSymbol =>
                {
                    var attribute = paramSymbol
                        .GetAttributes()
                        .FirstOrDefault(data => data.IsMarshalUsingAttribute());
                    var countParamName = attribute
                        ?.NamedArguments.SingleOrDefault(pair => pair.Key == "CountElementName")
                        .Value.ToCSharpString()
                        .Trim('\"');

                    var countParam = method.Parameters.SingleOrDefault(p =>
                        p.Name == countParamName
                    );

                    return (pSymbol: paramSymbol, Attrib: attribute, CountParam: countParam);
                })
                .Where(tuple =>
                    tuple.Attrib is not null
                    && tuple.CountParam is not null
                    && tuple.pSymbol.Type.IsSpanType()
                )
                .Select(tuple => (tuple.pSymbol!, tuple.CountParam!));
        }
    }

    extension(AttributeData data)
    {
        public bool IsMarshalUsingAttribute() =>
            data.AttributeClass?.ToFullyQualified()
                .StartsWith(
                    "global::System.Runtime.InteropServices.Marshalling.MarshalUsingAttribute"
                ) ?? false;
    }
}
