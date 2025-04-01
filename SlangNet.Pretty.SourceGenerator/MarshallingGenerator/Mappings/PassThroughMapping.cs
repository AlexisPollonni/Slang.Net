using System;
using Microsoft.CodeAnalysis;
using SlangNet.Pretty.SourceGenerator.Tooling;

namespace SlangNet.Pretty.SourceGenerator.MarshallingGenerator.Mappings;

class PassThroughMapping(CSharpSourceBuilder builder, IParameterSymbol managed, IParameterSymbol native) : MarshalManagedNativeMappingBase(builder, managed, native) {
    
    private IDisposable? _fixedScope;

    public override void WriteByteCountAllocVar(string countVarName)
    {
        //noop
    }
    public override void WriteBeforeMarshal(string _)
    {

        if (IsOutParameter)
        {
            _fixedScope = Builder.BeginScope(
                $"fixed ({Native.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)} {NativeVarName} = &{Managed.Name})");
        }
    }

    public override void WriteNativeParameterPassing()
    {
        Builder.Append(IsOutParameter ? NativeVarName : Managed.Name);
    }

    public override void WriteAfterMarshal()
    {
        _fixedScope?.Dispose();
    }
}