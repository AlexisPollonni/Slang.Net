// See https://aka.ms/new-console-template for more information

using ConsoleAppFramework;
using CppSharp;
using CppSharp.AST;
using CppSharp.Passes;
using ShaderSlang.Net.Scripts.CppSharpGenerator;
using Shouldly;
using TruePath;
using TruePath.SystemIo;

ConsoleApp.Run(args, GenerateBindings);
return;

void GenerateBindings([Argument] string slangRepoPath, [Argument] string outputDirPath)
{
    var slangRepo = new LocalPath(slangRepoPath).ResolveToCurrentDirectory();
    var outputDir = new LocalPath(outputDirPath).ResolveToCurrentDirectory();

    slangRepo.ExistsDirectory().ShouldBeTrue($"Slang repository path does not exist: {slangRepo}");
    outputDir.ExistsDirectory().ShouldBeTrue($"Output directory path does not exist: {outputDir}");

    ConsoleDriver.Run(new SlangLibrary(slangRepo, outputDir));
}

internal sealed class RemoveAmbiguousNamingPrefixPass : TranslationUnitPass
{
    public override bool VisitFunctionDecl(Function function)
    {
        if (!function.Name.StartsWith("sp", StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        if (function.Name.StartsWith("specialize", StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        function.Name = function.Name.Remove(0, 2);

        return base.VisitFunctionDecl(function);
    }
}