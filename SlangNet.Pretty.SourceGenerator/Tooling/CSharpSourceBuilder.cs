using System;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;

namespace SlangNet.Pretty.SourceGenerator.Tooling;

/// <summary>
/// A type-safe builder for generating C# source code with proper indentation and scope handling.
/// </summary>
public sealed class CSharpSourceBuilder
{
    private readonly StringBuilder _builder = new();
    private int _indentLevel;
    private const string IndentString = "    "; // 4 spaces
    private bool _isNewLine = true;

    /// <summary>
    /// Gets the current source code as a string.
    /// </summary>
    public override string ToString() => _builder.ToString();

    /// <summary>
    /// Appends text with proper indentation.
    /// </summary>
    public CSharpSourceBuilder Append(string text)
    {
        if (_isNewLine)
        {
            _builder.Append(IndentString.Repeat(_indentLevel));
            _isNewLine = false;
        }
        _builder.Append(text);
        return this;
    }

    /// <summary>
    /// Appends text with proper indentation and a newline.
    /// </summary>
    public CSharpSourceBuilder AppendLine(string text = "")
    {
        if (_isNewLine && text.Length > 0)
        {
            _builder.Append(IndentString.Repeat(_indentLevel));
        }
        
        _builder.AppendLine(text);
        _isNewLine = true;
        return this;
    }

    /// <summary>
    /// Opens a new scope with curly braces and increases indentation.
    /// </summary>
    public IDisposable BeginScope(string? declaration = null)
    {
        if (declaration != null)
        {
            AppendLine(declaration);
        }
        AppendLine("{");
        _indentLevel++;
        return new ScopeGuard(this);
    }

    /// <summary>
    /// Begins a namespace scope using a string name.
    /// </summary>
    public IDisposable BeginNamespace(string namespaceName)
    {
        AppendLine($"namespace {namespaceName};");
        AppendLine();
        return new ScopeGuard(this, false); // Don't add braces for file-scoped namespaces
    }

    /// <summary>
    /// Begins a namespace scope using an INamespaceSymbol.
    /// </summary>
    public IDisposable BeginNamespace(INamespaceSymbol namespaceSymbol)
    {
        return BeginNamespace(namespaceSymbol.ToDisplayString());
    }

    /// <summary>
    /// Begins a class declaration scope using string parameters.
    /// </summary>
    public IDisposable BeginClass(string className, string? baseType = null, bool isPartial = false, Accessibility accessibility = Accessibility.Internal)
    {
        var declaration = $"{accessibility.ToCSharpString()} {(isPartial ? "partial " : "")}class {className}";
        if (baseType != null)
        {
            declaration += $" : {baseType}";
        }
        return BeginScope(declaration);
    }

    /// <summary>
    /// Begins a class declaration scope using an INamedTypeSymbol.
    /// </summary>
    public IDisposable BeginClass(INamedTypeSymbol classSymbol, bool isPartial = false)
    {
        var baseTypes = classSymbol.BaseType != null 
            ? new[] { classSymbol.BaseType }.Concat(classSymbol.Interfaces)
            : classSymbol.Interfaces;

        var baseTypesList = baseTypes.Any() 
            ? " : " + string.Join(", ", baseTypes.Select(t => t.ToDisplayString()))
            : null;

        return BeginClass(
            classSymbol.Name,
            baseTypesList,
            isPartial,
            classSymbol.DeclaredAccessibility);
    }

    /// <summary>
    /// Begins a method declaration scope using string parameters.
    /// </summary>
    public IDisposable BeginMethod(string returnType, string name, string parameters, Accessibility accessibility = Accessibility.Public, bool isPartial = false, bool isUnsafe = false)
    {
        var decl = $"{accessibility.ToCSharpString()} {(isUnsafe ? "unsafe " : "")}{(isPartial ? "partial " : "")}{returnType} {name}({parameters})";
        return BeginScope(decl);
    }

    /// <summary>
    /// Begins a method declaration scope using an IMethodSymbol.
    /// </summary>
    public IDisposable BeginMethod(IMethodSymbol methodSymbol, bool isPartial = false)
    {
        var parameters = string.Join(", ", methodSymbol.Parameters.Select(p => 
        {
            var paramStr = "";
            if (p.RefKind == RefKind.Ref) paramStr += "ref ";
            else if (p.RefKind == RefKind.Out) paramStr += "out ";
            else if (p.RefKind == RefKind.In) paramStr += "in ";
            paramStr += $"{p.Type.ToDisplayString()} {p.Name}";
            if (p.HasExplicitDefaultValue)
            {
                paramStr += " = ";
                paramStr += p.ExplicitDefaultValue?.ToString() ?? "default";
            }
            return paramStr;
        }));
        
        return BeginMethod(
            methodSymbol.ReturnType.ToDisplayString(),
            methodSymbol.Name,
            parameters,
            methodSymbol.DeclaredAccessibility,
            isPartial,
            methodSymbol.IsUnsafe());
    }

    /// <summary>
    /// Adds using directives from strings.
    /// </summary>
    public CSharpSourceBuilder AddUsings(params string[] namespaces)
    {
        foreach (var ns in namespaces)
        {
            AppendLine($"using {ns};");
        }
        if (namespaces.Length > 0)
        {
            AppendLine();
        }
        return this;
    }

    /// <summary>
    /// Adds using directives from INamespaceSymbols.
    /// </summary>
    public CSharpSourceBuilder AddUsings(params INamespaceSymbol[] namespaces)
    {
        return AddUsings(namespaces.Select(n => n.ToDisplayString()).ToArray());
    }

    /// <summary>
    /// Adds using directives with aliases.
    /// </summary>
    public CSharpSourceBuilder AddUsing(string alias, INamedTypeSymbol type)
    {
        AppendLine($"using {alias} = {type.ToDisplayString()};");
        return this;
    }

    private void EndScope()
    {
        if (_indentLevel > 0)
        {
            _indentLevel--;
        }
        AppendLine("}");
    }

    private sealed class ScopeGuard : IDisposable
    {
        private readonly CSharpSourceBuilder _builder;
        private readonly bool _addBraces;

        public ScopeGuard(CSharpSourceBuilder builder, bool addBraces = true)
        {
            _builder = builder;
            _addBraces = addBraces;
        }

        public void Dispose()
        {
            if (_addBraces)
            {
                _builder.EndScope();
            }
        }
    }
}

static class CSharpSourceBuilderExtensions
{
    public static string Repeat(this string str, int count)
    {
        if (count <= 0) return string.Empty;
        return string.Concat(Enumerable.Repeat(str, count));
    }

    public static string ToCSharpString(this Accessibility accessibility) => accessibility switch
    {
        Accessibility.Public => "public",
        Accessibility.Private => "private",
        Accessibility.Protected => "protected",
        Accessibility.Internal => "internal",
        Accessibility.ProtectedOrInternal => "protected internal",
        Accessibility.ProtectedAndInternal => "private protected",
        _ => "internal" // Default to internal for other cases
    };
} 