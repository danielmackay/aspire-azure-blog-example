using Mono.Cecil;

namespace AspireWebApp.Architecture.UnitTests.Common;

public class IsNotEnumRule : ICustomRule
{
    public bool MeetsRule(TypeDefinition type) => !type.IsEnum;
}