using Microsoft.EntityFrameworkCore;
using AspireWebApp.Application.Common.Interfaces;
using AspireWebApp.Domain.Common.Interfaces;
using AspireWebApp.Domain.Heroes;
using AspireWebApp.Domain.Teams;
using AspireWebApp.Infrastructure.Persistence.Configuration;
using System.Reflection;

namespace AspireWebApp.Infrastructure.Persistence;

public class ApplicationDbContext(DbContextOptions options)
    : DbContext(options), IApplicationDbContext
{
    public DbSet<Hero> Heroes => AggregateRootSet<Hero>();

    public DbSet<Team> Teams => AggregateRootSet<Team>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        configurationBuilder.RegisterAllInVogenEfCoreConverters();
    }

    private DbSet<T> AggregateRootSet<T>() where T : class, IAggregateRoot => Set<T>();
}