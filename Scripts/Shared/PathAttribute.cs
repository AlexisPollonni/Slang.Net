using Cake.Core.IO;
using ConsoleAppFramework;

namespace Slang.Net.Scripts.Shared;

[AttributeUsage(AttributeTargets.Parameter)]
public class FileAttribute : Attribute, IArgumentParser<FilePath>
{
    public static bool TryParse(ReadOnlySpan<char> s, out FilePath result)
    {
        result = FilePath.FromString(s.ToString());

        return true;
    }
}

[AttributeUsage(AttributeTargets.Parameter)]
public class DirAttribute : Attribute, IArgumentParser<DirectoryPath>
{
    public static bool TryParse(ReadOnlySpan<char> s, out DirectoryPath result)
    {
        result = DirectoryPath.FromString(s.ToString());

        return true;
    }
}