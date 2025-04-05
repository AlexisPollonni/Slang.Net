using SlangNet.Bindings.Generated;
using SlangNet.ComWrappers;


Slang.CreateGlobalSession(0, out var globalSession);

var compiler = globalSession.GetDefaultDownstreamCompiler(SourceLanguage.Cpp);

var buildTag = globalSession.GetBuildTagString();
Console.WriteLine(buildTag);

globalSession.GetDownstreamCompilerPrelude(PassThrough.VisualStudio, out var prelude);
Console.WriteLine(prelude.AsString());

var profile = globalSession.FindProfile("spirv_1_5");

Console.WriteLine(profile);