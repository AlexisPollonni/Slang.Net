using CppSharp;
using CppSharp.AST;
using CppSharp.Passes;

namespace ShaderSlang.Net.Scripts.CppSharpGenerator.Passes;

/// <summary>
/// Renames enumeration items to PascalCase if they are in ALL_CAPS, which is a common convention for C/C++ enums but not for C# enums.
/// </summary>
internal sealed class RenameEnumItemsCasePass : TranslationUnitPass
{
    public override bool VisitEnumItemDecl(Enumeration.Item item)
    {
        var split = item.Name.Split(
            '_',
            StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries
        );

        // if name contains
        if (split.Length <= 0 || split.SelectMany(part => part).Any(char.IsLower))
            return false;

        var newName = split
            .Select(namePart => StringHelpers.Capitalize(namePart.ToLower()))
            .Aggregate((a, b) => a + b);

        item.Name = newName;

        return base.VisitEnumItemDecl(item);
    }
}
