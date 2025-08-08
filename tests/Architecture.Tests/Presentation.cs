using AspireWebApp.Application.Common.Interfaces;
using AspireWebApp.Architecture.UnitTests.Common;
using AspireWebApp.Infrastructure.Persistence;

namespace AspireWebApp.Architecture.UnitTests;

public class Presentation : TestBase
{
    private static readonly Type IDbContext = typeof(IApplicationDbContext);
    private static readonly Type DbContext = typeof(ApplicationDbContext);

    [Fact]
    public void Endpoints_ShouldNotReferenceDbContext()
    {
        var types = Types
            .InAssembly(PresentationAssembly)
            .That()
            .HaveNameEndingWith("Endpoints");

        var result = types
            .ShouldNot()
            .HaveDependencyOnAny(DbContext.FullName, IDbContext.FullName)
            .GetResult();

        result.Should().BeSuccessful();
    }
}