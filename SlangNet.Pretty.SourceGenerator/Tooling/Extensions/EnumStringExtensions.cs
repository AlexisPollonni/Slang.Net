using System;
using Microsoft.CodeAnalysis;

namespace SlangNet.Pretty.SourceGenerator.Tooling.Extensions;

public static class EnumStringExtensions
{
    public static string ToDisplayString(this RefKind refKind) =>
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