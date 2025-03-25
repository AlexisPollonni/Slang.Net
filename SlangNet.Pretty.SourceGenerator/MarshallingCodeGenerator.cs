using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis;

namespace SlangNet.Pretty.SourceGenerator;

internal static class MarshallingCodeGenerator
{
    public static string GenerateCode(IMethodSymbol method, IMethodSymbol nativeMethod, Compilation compilation)
    {
        var builder = new CSharpSourceBuilder();
        WriteUsings(builder);
        WriteNamespace(builder, method.ContainingNamespace);
        using (WriteClassStart(builder, method.ContainingType))
        {
            using (WriteMethodSignature(builder, method))
            {
                WriteMethodBody(builder, method, nativeMethod, compilation);
            }
        }
        return builder.ToString();
    }

    private static void WriteUsings(CSharpSourceBuilder source)
    {
        source.AppendLine("using System;");
        source.AppendLine("using SlangNet.Bindings.Generated;");
        source.AppendLine("using SlangNet.Internal;");
        source.AppendLine();
        source.AppendLine("#nullable enable");
        source.AppendLine();
    }

    private static void WriteNamespace(CSharpSourceBuilder source, INamespaceSymbol ns)
    {
        source.AppendLine($"namespace {ns.ToDisplayString()};");
        source.AppendLine();
    }

    private static IDisposable WriteClassStart(CSharpSourceBuilder source, INamedTypeSymbol type)
    {
        return source.BeginClass(type.Name, null, true, type.DeclaredAccessibility);
    }

    private static IDisposable WriteMethodSignature(CSharpSourceBuilder source, IMethodSymbol method)
    {
        return source.BeginMethod(method, true);
    }

    private static void WriteMethodBody(CSharpSourceBuilder source,
                                        IMethodSymbol method,
                                        IMethodSymbol nativeMethod,
                                        Compilation compilation)
    {
        WriteMarshallInputParameters(source, method);
        WriteDeclareNativeOutParameters(source, method, compilation);
        WriteNativeMethodCall(source, method, nativeMethod);
        WriteAssignOutParameters(source, method);
        source.AppendLine("return result;");
    }

    private static void WriteDeclareNativeOutParameters(CSharpSourceBuilder source, IMethodSymbol method, Compilation compilation)
    {
        foreach (var param in method.Parameters)
        {
            if (param.RefKind == RefKind.Out)
            {
                var nativeType = param.Type.GetNativeType(compilation);
                source.AppendLine($"{nativeType}* native_out_{param.Name} = default;");
            }
        }
    }

    private static void WriteMarshallInputParameters(CSharpSourceBuilder source, IMethodSymbol method)
    {
        source.AppendLine("var byteSize = 0;");
        foreach (var param in method.Parameters)
        {
            if (param.RefKind != RefKind.Out && param.Type.ImplementsIMarshalToNative())
            {
                source.AppendLine($"byteSize += {param.Name}.GetNativeAllocSize();");
            }
        }
        
        source.AppendLine();
        source.AppendLine("var span = byteSize > 1024 ? GC.AllocateUninitializedArray<byte>(byteSize, true) : stackalloc byte[byteSize];");
        source.AppendLine("var buffer = new MarshallingAllocBuffer(span);");
        source.AppendLine();

        foreach (var param in method.Parameters)
        {
            if (param.RefKind != RefKind.Out && param.Type.ImplementsIMarshalToNative())
            {
                source.AppendLine($"{param.Name}.AsNative(ref buffer, out var native_{param.Name});");
            }
        }

        source.AppendLine();
    }

    private static void WriteNativeMethodCall(CSharpSourceBuilder source, IMethodSymbol method, IMethodSymbol nativeMethod)
    {
        source.Append("var result = Pointer->");
        source.Append(nativeMethod.Name);
        source.Append("(");
        
        for (var i = 0; i < nativeMethod.Parameters.Length; i++)
        {
            if (i > 0)
                source.Append(", ");
            var nativeParam = nativeMethod.Parameters[i];
            var managedParam = method.Parameters[i];
            if (managedParam.RefKind == RefKind.Out)
                source.Append($"&native_out_{managedParam.Name}");
            else if (managedParam.Type.ImplementsIMarshalToNative())
                source.Append($"&native_{managedParam.Name}");
            else
                source.Append(managedParam.Name);
        }
        source.AppendLine(").ToSlangResult();");
    }

    private static void WriteAssignOutParameters(CSharpSourceBuilder source, IMethodSymbol method)
    {
        foreach (var param in method.Parameters)
        {
            if (param.RefKind == RefKind.Out)
            {
                source.AppendLine($"{param.Name} = native_out_{param.Name} != null ? new {param.Type.Name}(native_out_{param.Name}) : null;");
            }
        }
    }
}


public record ManagedToNativeMappings
{
     

    public Dictionary<string, INamedTypeSymbol> OutNamedVarList;
    public bool NativeIsVoidReturn;
    public bool MarshalNativeReturn;
}

public interface IMarshalMappingToNative
{
    public bool IsCorrectMapping(ITypeSymbol managed, ITypeSymbol native);

    public void WriteBodyByteCountAlloc(CSharpSourceBuilder builder, IParameterSymbol managed, string countVarName, string bufferVarName);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="managed"></param>
    /// <param name="native"></param>
    /// <returns>Variable name created that contains the native type</returns>
    public string WriteBodyMarshalConversion(CSharpSourceBuilder builder, IParameterSymbol managed, IParameterSymbol native, string bufferVarName);
}





public class ComObjectToNative: IMarshalMappingToNative
{
    public bool IsCorrectMapping(ITypeSymbol managed, ITypeSymbol native)
    {
        var natType = managed.GetNativeTypeFromComObject();
        return natType is not null && natType.Equals(native, SymbolEqualityComparer.Default);
    }


    public void WriteBodyByteCountAlloc(CSharpSourceBuilder builder, IParameterSymbol managed, string countVarName, string bufferVarName)
    {
        builder.AppendLine($"// Byte count calculations for ComObjects are a no-op");
    }

    public string WriteBodyMarshalConversion(CSharpSourceBuilder builder,
                                             IParameterSymbol managed,
                                             IParameterSymbol native,
                                             string bufferVarName)
    {
        var varName = $"native_in_{managed.Name}";

        builder.AppendLine($"var {varName} = {managed.Name}.AsNullablePtr();");

        return varName;
    }
}

public class MarshalsAsNativeMapping : IMarshalMappingToNative
{
    public bool IsCorrectMapping(ITypeSymbol managed, ITypeSymbol native)
    {
        var natType = managed.GetNativeTypeFromMarshalInterface();

        return natType is not null && natType.Equals(native, SymbolEqualityComparer.Default);
    }

    public void WriteBodyByteCountAlloc(CSharpSourceBuilder builder,
                                        IParameterSymbol managed,
                                        string countVarName,
                                        string bufferVarName)
    {
        builder.AppendLine($"{countVarName} += {managed.Name}.GetNativeAllocSize();");
    }

    public string WriteBodyMarshalConversion(CSharpSourceBuilder builder, IParameterSymbol managed, IParameterSymbol native, string bufferVarName)
    {
        var varName = $"native_in_{managed.Name}";

        builder.AppendLine($"// Marshalling of parameter {managed.Name} from {managed.Type} to {native.Type}");
        builder.AppendLine($"{managed.Name}.AsNative(ref {bufferVarName}, out var {varName});");

        return varName;
    }
}