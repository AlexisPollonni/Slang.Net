namespace SlangNet;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface)]
internal sealed class GenerateThrowingMethodsAttribute : Attribute
{
}

[AttributeUsage(AttributeTargets.Method)]
internal sealed class IgnoreThrowingMethodAttribute : Attribute
{
}
