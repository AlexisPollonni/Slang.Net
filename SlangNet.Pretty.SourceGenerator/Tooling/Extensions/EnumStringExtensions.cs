using Microsoft.CodeAnalysis;

namespace SlangNet.Pretty.SourceGenerator.Tooling.Extensions;

public static class EnumStringExtensions
{
    extension(RefKind refKind)
    {
        public string ToDisplayString() =>
            refKind switch
            {
                RefKind.None => "",
                RefKind.Ref => "ref",
                RefKind.Out => "out",
                RefKind.In => "in",
                RefKind.RefReadOnlyParameter => "ref readonly",
                _ => throw new ArgumentOutOfRangeException(nameof(refKind), refKind, null),
            };
    }
}