using CppSharp;
using CppSharp.AST;
using CppSharp.AST.Extensions;
using CppSharp.Passes;
using CSharpier.Core;
using CSharpier.Core.CSharp;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging.Console;
using ShaderSlang.Net.Scripts.CppSharpGenerator.Passes;
using Shouldly;
using TruePath;
using TruePath.SystemIo;

namespace ShaderSlang.Net.Scripts.CppSharpGenerator;

internal sealed class SlangLibrary(AbsolutePath slangRepoPath, AbsolutePath outputDirPath)
    : ILibrary
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

        // Since we rewrote the entire code generator we can enable dry run to skip cppsharp's generator since we do so in the postprocess
        opts.DryRun = true;

        var compilerModule = opts.AddModule("slang-compiler");
        compilerModule.OutputNamespace = "ShaderSlang.Net.Bindings.Generated";
        compilerModule.IncludeDirs.Add(slangIncludePath.ToString());
        compilerModule.Headers.AddRange(
            slangHeaderPath.ToString(),
            slangDeprecatedHeaderPath.ToString()
        );
    }

    public void SetupPasses(Driver driver)
    {
        //workaround
        driver.Context.TranslationUnitPasses.Passes.RemoveAll(pass =>
            pass is CheckIgnoredDeclsPass
        );

        // Removes enum member prefixes to match csharp conventions
        //TODO: check if can detect automatically similarly to how was done with ClangSharp script
        string[] enumMemberPrefixesToRemove =
        [
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

        var stringNameConflictsPass = new RegexRenamePass(
            "string",
            "srcString",
            RenameTargets.Parameter
        ); //IDK why anyone would name a param "string" but here we are...
        stringNameConflictsPass.VisitOptions.SetFlags(VisitFlags.FunctionParameters); // surprisingly by default visiting parameters is not set, even when adding the rename target for it

        IEnumerable<TranslationUnitPass> passes =
        [
            stringNameConflictsPass,
            new ResolveOpaqueClassesPass(),
            new GenerateStaticClassForFunctionPass("slang_", "SlangApi"),
            new GenerateStaticClassForFunctionPass("sp", "SlangApi"),
            new CheckIgnoredDeclsPass(),
            .. enumMemberPrefixesToRemove.Select(prefix => new RegexRenamePass(
                $"^{prefix}",
                string.Empty,
                RenameTargets.EnumItem
            )),
            new RenameEnumItemsCasePass(),
            new FieldToPropertyPass(),
            new CaseRenamePass(
                RenameTargets.Function | RenameTargets.Namespace | RenameTargets.Property,
                RenameCasePattern.UpperCamelCase
            ),
            new RemoveAmbiguousNamingPrefixPass(),
            new ResolveIncompleteDeclsPass(),
            new GenerateSlangComInterfacesPass(),
            new GenerateMarshallersForClassesPass(),
            new TransformParametersMarshalPass(),
            new GenerateTranslationUnitNamespacePass(),
        ];

        foreach (var pass in passes)
            driver.AddTranslationUnitPass(pass);
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
        ctx.GetEnumWithMatchingItem("SLANG_DIAGNOSTIC_FLAG_TREAT_WARNINGS_AS_ERRORS").Name =
            "SlangDiagnosticFlags";
        ctx.GetEnumWithMatchingItem("SLANG_COMPILE_FLAG_NO_MANGLING").Name = "SlangCompileFlags";
        ctx.GetEnumWithMatchingItem("SLANG_TARGET_FLAG_GENERATE_WHOLE_PROGRAM").Name =
            "SlangTargetFlags";

        var uuid = ctx.FindClass("SlangUUID").First();

        uuid.HasNonTrivialDefaultConstructor = false;
        uuid.HasNonTrivialCopyConstructor = false;
        uuid.HasNonTrivialDestructor = false;
    }

    public void Postprocess(Driver driver, ASTContext ctx)
    {
        var pass = new SyntaxCodeGeneratorPass(driver.Context);

        foreach (
            var unit in driver
                .Context.Options.Modules.SelectMany(module => module.Units.GetGenerated())
                .Where(u => !u.IsSystemHeader)
        )
        {
            var tree = pass.Visit(unit);

            var formatterResult = CSharpFormatter.Format(tree, new() { IncludeGenerated = true });
            var resultText = formatterResult.CompilationErrors.Any()
                ? tree.GetRoot().NormalizeWhitespace().ToFullString()
                : formatterResult.Code;

            foreach (var error in formatterResult.CompilationErrors)
            {
                Diagnostics.Error($"Syntax Error : {error} at location {error.Location}");
            }

            var outputFile =
                new LocalPath(driver.Options.OutputDir) / $"{unit.FileNameWithoutExtension}.cs";
            File.WriteAllText(outputFile.ToString(), resultText);
        }
    }
}
