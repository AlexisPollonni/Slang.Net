using Microsoft.CodeAnalysis;

namespace SlangNet.Pretty.SourceGenerator;

internal static class ParameterValidator
{
    public static bool ValidateParameters(
        IMethodSymbol managedMethod,
        IMethodSymbol nativeMethod,
        Location location,
        SourceProductionContext context)
    {
        var isValid = true;

        if(!managedMethod.ReturnType.Equals(nativeMethod.ReturnType, SymbolEqualityComparer.Default))
        {
            
        }

        // Validate out parameters match native double pointers
        for (var i = 0; i < managedMethod.Parameters.Length; i++)
        {
            var managedParam = managedMethod.Parameters[i];
            if (managedParam.RefKind == RefKind.Out)
            {
                if (i >= nativeMethod.Parameters.Length)
                {
                    context.ReportDiagnostic(Diagnostic.Create(
                        DiagnosticDescriptors.OutParameterMismatch,
                        location,
                        managedParam.Name));
                    isValid = false;
                    continue;
                }

                var nativeParam = nativeMethod.Parameters[i];
                if (!nativeParam.Type.IsDoublePointer())
                {
                    context.ReportDiagnostic(Diagnostic.Create(
                        DiagnosticDescriptors.InvalidOutParameterType,
                        location,
                        managedParam.Name,
                        nativeParam.Type));
                    isValid = false;
                }
            }
            else
            {
                
            }
        }

        return isValid;
    }
}