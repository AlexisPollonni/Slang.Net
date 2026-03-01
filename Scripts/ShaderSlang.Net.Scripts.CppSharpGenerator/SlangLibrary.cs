using CppSharp;
using CppSharp.AST;
using CppSharp.Passes;
using CSharpier.Core.CSharp;
using Microsoft.CodeAnalysis.CSharp;
using ShaderSlang.Net.Scripts.CppSharpGenerator.Passes;
using Shouldly;
using TruePath;
using TruePath.SystemIo;

namespace ShaderSlang.Net.Scripts.CppSharpGenerator;

internal sealed class SlangLibrary(AbsolutePath slangRepoPath, AbsolutePath outputDirPath) : ILibrary
{
    public void Setup(Driver driver)
    {
        Diagnostics.Level = DiagnosticKind.Debug;
            
        var slangIncludePath = slangRepoPath / "include";
        var slangHeaderPath = slangIncludePath / "slang.h";
        var slangDeprecatedHeaderPath = slangIncludePath / "slang-deprecated.h";

        slangIncludePath.ExistsDirectory().ShouldBeTrue();
        slangHeaderPath.ExistsFile().ShouldBeTrue();
        slangDeprecatedHeaderPath.ExistsFile().ShouldBeTrue();

        outputDirPath.ExistsDirectory().ShouldBeTrue();

        var opts = driver.Options;
        opts.OutputDir = outputDirPath.ToString();
        opts.GenerationOutputMode = GenerationOutputMode.FilePerUnit;
        opts.CommentKind = CommentKind.BCPLSlash;
        opts.GenerateDeprecatedDeclarations = true;
        opts.GenerateFinalizers = false;
        opts.UseSpan = true;
        opts.MarshalConstCharArrayAsString = true;

        // Since we rewrote the entire code generator we can enable dry run to skip cppsharp's generator since we do so in the postprocess
        opts.DryRun = true;
        
        var compilerModule = opts.AddModule("slang-compiler");
        compilerModule.OutputNamespace = "ShaderSlang.Net.Bindings.Generated";
        compilerModule.IncludeDirs.Add(slangIncludePath.ToString());
        compilerModule.Headers.AddRange(slangHeaderPath.ToString(), slangDeprecatedHeaderPath.ToString());
    }

    public void SetupPasses(Driver driver)
    {
        // Removes enum member prefixes to match csharp conventions
        //TODO: check if can detect automatically similarly to how was done with ClangSharp script
        string[] enumMemberPrefixesToRemove = [
            "SLANG_",
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


        IEnumerable<TranslationUnitPass> passes = [
                
            new GenerateStaticClassForFunctionPass("slang_"),
            new GenerateStaticClassForFunctionPass("sp"),
                
            new FunctionToStaticMethodPass(),
            ..enumMemberPrefixesToRemove.Select(prefix => new RegexRenamePass($"^{prefix}", string.Empty, RenameTargets.EnumItem)),
            
            
                
            new CaseRenamePass(RenameTargets.Function, RenameCasePattern.UpperCamelCase),
                
            new RemoveAmbiguousNamingPrefixPass(),
            new ResolveIncompleteDeclsPass(),
                
            new GenerateSlangComInterfacesPass(),
            new GenerateComInterfaceMarshallersPass(),
        ];

        foreach (var pass in passes) driver.AddTranslationUnitPass(pass);
    }

    public void Preprocess(Driver driver, ASTContext ctx)
    {
        ctx.IgnoreFunctionWithName("slang::createGlobalSession");
        ctx.IgnoreFunctionWithName("slang::shutdown");
        ctx.IgnoreFunctionWithName("slang::getLastInternalErrorMessage");
        
        
        ctx.SetClassAsValueType("SlangUUID");
        
        ctx.IgnoreClassWithName("_GUID");
        
        ctx.IgnoreConversionToProperty("ISlangUnknown::release");
        ctx.IgnoreConversionToProperty("ISlangUnknown::Release");

        ctx.GenerateEnumFromMacros("SlangFacility", "SLANG_FACILITY_(.*)");
        
        //Fixes small errors in the slang api where enum typedefs are missing from bases
        ctx.GetEnumWithMatchingItem("SLANG_DIAGNOSTIC_FLAG_TREAT_WARNINGS_AS_ERRORS").Name = "SlangDiagnosticFlags";
        ctx.GetEnumWithMatchingItem("SLANG_COMPILE_FLAG_NO_MANGLING").Name = "SlangCompileFlags";
        ctx.GetEnumWithMatchingItem("SLANG_TARGET_FLAG_GENERATE_WHOLE_PROGRAM").Name = "SlangTargetFlags";

        var uuid = ctx.FindClass("SlangUUID").First();

        uuid.HasNonTrivialDefaultConstructor = false;
        uuid.HasNonTrivialCopyConstructor = false;
        uuid.HasNonTrivialDestructor = false;
    }

    public void Postprocess(Driver driver, ASTContext ctx)
    {
        var pass = new SyntaxCodeGeneratorPass(driver.Context);
        foreach (var unit in ctx.TranslationUnits)
        {
            var tree = pass.Visit(unit); 
            
            var formattedSyntax = CSharpFormatter.Format(tree);
        }
    }
}