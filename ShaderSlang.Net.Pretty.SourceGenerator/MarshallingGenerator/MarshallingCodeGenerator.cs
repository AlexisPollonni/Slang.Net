// using System;
// using System.Collections.Generic;
// using System.Linq;
// using Microsoft.CodeAnalysis;
// using ShaderSlang.Net.Pretty.SourceGenerator.MarshallingGenerator.Mappings;
// using ShaderSlang.Net.Pretty.SourceGenerator.Tooling;
//
// namespace ShaderSlang.Net.Pretty.SourceGenerator.MarshallingGenerator;
//
// class MarshallingCodeGenerator()
// {
//     public DiagnosticsList Diagnostics { get; } = new();
//
//     private readonly CSharpSourceBuilder _builder = new();
//     
//     public string GenerateCode(IMethodSymbol method, IMethodSymbol nativeMethod)
//     {
//         WriteUsings();
//         WriteNamespace(method.ContainingNamespace);
//         using (WriteClassStart(method.ContainingType))
//         {
//             using (WriteMethodSignature(method))
//             {
//                 using(_builder.BeginScope("unsafe"))
//                     WriteMethodBody(method, nativeMethod);
//             }
//         }
//         return _builder.ToString();
//     }
//
//     private void WriteUsings()
//     {
//         _builder.AppendLine("using System;");
//         _builder.AppendLine("using ShaderSlang.Net.Bindings.Generated;");
//         _builder.AppendLine("using ShaderSlang.Net.Internal;");
//         _builder.AppendLine();
//         _builder.AppendLine("#nullable enable");
//         _builder.AppendLine();
//     }
//
//     private void WriteNamespace(INamespaceSymbol ns)
//     {
//         _builder.AppendLine($"namespace {ns.ToDisplayString()};");
//         _builder.AppendLine();
//     }
//
//     private IDisposable WriteClassStart(INamedTypeSymbol type)
//     {
//         return _builder.BeginClass(type.Name, null, true, type.DeclaredAccessibility);
//     }
//
//     private IDisposable WriteMethodSignature(IMethodSymbol method)
//     {
//         return _builder.BeginMethod(method, true);
//     }
//
//     private void WriteMethodBody(IMethodSymbol method,
//                                  IMethodSymbol nativeMethod)
//     {
//         const string byteSizeVarName = "_byteSize";
//
//         var mappings = method.Parameters.Zip(nativeMethod.Parameters, (a, b) => (a,b))
//               .Select(tuple => GetMappingForParameter(tuple.a, tuple.b)).ToArray();
//         
//         _builder.AppendLine($"var {byteSizeVarName} = 0;");
//         
//         //Mapping alloc
//         foreach (var map in mappings.Where(b => !b.IsOutParameter)) map.WriteByteCountAllocVar(byteSizeVarName);
//         
//         _builder.AppendLine();
//         _builder.AppendLine($"var _span = {byteSizeVarName} > 1024 ? GC.AllocateUninitializedArray<byte>({byteSizeVarName}, true) : stackalloc byte[{byteSizeVarName}];");
//         _builder.AppendLine("var _buffer = new MarshallingAllocBuffer(_span);");
//         _builder.AppendLine();
//
//         _builder.AppendLine($"{nativeMethod.ReturnType.ToFullyQualified()} _native_res;");
//
//         //marshal before
//         foreach (var map in mappings) map.WriteBeforeMarshal("_buffer");
//
//         _builder.AppendLine();
//         
//         _builder.Append("_native_res = Pointer->");
//         _builder.Append(nativeMethod.Name);
//         _builder.Append("(");
//         
//         for (var i = 0; i < mappings.Length; i++)
//         {
//             if (i > 0)
//                 _builder.Append(", ");
//             mappings[i].WriteNativeParameterPassing();
//         }
//         _builder.AppendLine(");");
//
//         _builder.AppendLine();
//
//         //marshal after
//         foreach (var map in mappings) map.WriteAfterMarshal();
//         
//         //TODO: handle marshalling other return types
//         _builder.AppendLine(method.ReturnType.Name == "SlangResult"
//                                 ? "return _native_res.ToSlangResult();"
//                                 : "return _native_res;");
//     }
//
//
//     private MarshalManagedNativeMappingBase GetMappingForParameter(IParameterSymbol managed,
//                                                                           IParameterSymbol native)
//     {
//         var outType = managed.Type.GetNativeTypeFromComObject();
//         
//         if (outType is not null)
//         {
//             return new ComObjectToNative(_builder, managed, native);
//         }
//
//         outType = managed.Type.GetNativeTypeFromMarshalInterface();
//         if (outType is not null)
//         {
//             return new MarshalsAsNativeMapping(_builder, managed, native);
//         }
//
//         if (managed.Type.SpecialType == SpecialType.System_String)
//         {
//             return new StringMapping(_builder, managed, native);
//         }
//
//         //TODO: Handle collections as well
//         return new PassThroughMapping(_builder, managed, native);
//     }
// }