using AspireWebApp.Application.Common.Interfaces;
using AspireWebApp.Domain.Common.Base;
using AspireWebApp.Infrastructure.Persistence;
using AspireWebApp.WebApi;
using System.Reflection;

namespace AspireWebApp.Architecture.UnitTests.Common;

public abstract class TestBase
{
    protected static readonly Assembly DomainAssembly = typeof(AggregateRoot<>).Assembly;
    protected static readonly Assembly ApplicationAssembly = typeof(IApplicationDbContext).Assembly;
    protected static readonly Assembly InfrastructureAssembly = typeof(ApplicationDbContext).Assembly;
    protected static readonly Assembly PresentationAssembly = typeof(IWebApiMarker).Assembly;
}