// See https://aka.ms/new-console-template for more information

using System;
using ConsoleAppFramework;
using CppSharp;
using CppSharp.AST;
using CppSharp.Generators;
using CppSharp.Generators.Cpp;
using CppSharp.Passes;
using ShaderSlang.Net.Scripts.CppSharp;
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


internal sealed class SlangLibrary(AbsolutePath slangRepoPath, AbsolutePath outputDirPath) : ILibrary
{
    public void Setup(Driver driver)
    {
        var slangIncludePath = slangRepoPath / "include";
        var slangHeaderPath = slangIncludePath / "slang.h";

        slangIncludePath.ExistsDirectory().ShouldBeTrue();
        slangHeaderPath.ExistsFile().ShouldBeTrue();

        outputDirPath.ExistsDirectory().ShouldBeTrue();

        var opts = driver.Options;
        opts.OutputDir = outputDirPath.ToString();
        opts.GenerationOutputMode = GenerationOutputMode.FilePerModule;
        opts.CommentKind = CommentKind.BCPLSlash;
        opts.GenerateDeprecatedDeclarations = true;
        opts.GenerateFinalizers = false;
        opts.UseSpan = true;
        opts.MarshalCharAsManagedChar = true;
        opts.MarshalConstCharArrayAsString = true;
        
        
        var module = opts.AddModule("slang-compiler");
        
        module.OutputNamespace = "ShaderSlang.Net.Bindings.Generated";
        module.IncludeDirs.Add(slangIncludePath.ToString());
        module.Headers.Add(slangHeaderPath.ToString());
    }

    public void SetupPasses(Driver driver)
    {
        var passes = driver.Context.TranslationUnitPasses;
        
        passes.RemovePrefix("SLANG_");
        passes.RemovePrefix("Sp", RenameTargets.Function | RenameTargets.Method);
        passes.RenameDeclsUpperCase(RenameTargets.Any);
        
        // Removes enum member prefixes to match csharp conventions
        //TODO: check if can detect automatically similarly to how was done with ClangSharp script
        string[] enumMemberPrefixesToRemove = [
            "SEVERITY_",
            "DIAGNOSTIC_FLAG_",
            "TARGET_",
            "CONTAINER_FORMAT_",
            "PASS_THROUGH_",
            "ARCHIVE_TYPE_",
            "COMPILE_FLAG_",
            "TARGET_FLAG_",
            "FLOATING_POINT_MODE_",
            "FP_DENORM_MODE_",
            "LINE_DIRECTIVE_MODE_",
            "SOURCE_LANGUAGE_",
            "PROFILE_",
            "CAPABILITY_",
            "MATRIX_LAYOUT_MODE_",
            "MATRIX_LAYOUT_",
            "STAGE_",
            "DEBUG_INFO_LEVEL_",
            "DEBUG_INFO_FORMAT_",
            "OPTIMIZATION_LEVEL_",
            "EMIT_SPIRV_",
            "EMIT_CPU_",
            "PATH_TYPE_",
            "WRITER_CHANNEL_",
            "WRITER_MODE_",
            "DECL_KIND_",
            "RESOURCE_ACCESS_",
            "PARAMETER_CATEGORY_",
            "IMAGE_FORMAT_",
            "GENERIC_ARG_",
            "TYPE_KIND_",
            "SCALAR_TYPE_",
            "BINDING_TYPE_",
            "LAYOUT_RULES_",
            "MODIFIER_",
            "LANGUAGE_VERSION_",
            "DIAGNOSTIC_FLAG_",
        ];
        
        foreach (var prefix in enumMemberPrefixesToRemove)
        {
            passes.RemovePrefix(prefix, RenameTargets.EnumItem);
        }

        driver.AddTranslationUnitPass(new GenerateSlangComInterfacesPass());
        driver.AddTranslationUnitPass(new FixParametersMissingAttributesPass(driver.Context));
    }

    public void Preprocess(Driver driver, ASTContext ctx)
    {
        ctx.SetClassAsValueType("SlangUUID");
        
        ctx.IgnoreConversionToProperty("ISlangUnknown::release");
        ctx.IgnoreConversionToProperty("ISlangUnknown::Release");

        ctx.GenerateEnumFromMacros("SlangFacility", "SLANG_FACILITY_(.*)");
    }

    public void Postprocess(Driver driver, ASTContext ctx)
    {
        
    }
}