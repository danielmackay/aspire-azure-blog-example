using EntityFramework.Exceptions.SqlServer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AspireWebApp.Application.Common.Interfaces;
using AspireWebApp.Infrastructure.Persistence;
using AspireWebApp.Infrastructure.Persistence.Interceptors;

namespace AspireWebApp.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IHostApplicationBuilder builder)
    {
        builder.AddSqlServerDbContext<ApplicationDbContext>("Clean-Architecture",
            null,
            options =>
            {
                var serviceProvider = builder.Services.BuildServiceProvider();
                options.AddInterceptors(
                    serviceProvider.GetRequiredService<EntitySaveChangesInterceptor>(),
                    serviceProvider.GetRequiredService<DispatchDomainEventsInterceptor>());

                // Return strongly typed useful exceptions
                options.UseExceptionProcessor();
            });

        var services = builder.Services;

        services.AddScoped<IApplicationDbContext>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<EntitySaveChangesInterceptor>();
        services.AddScoped<DispatchDomainEventsInterceptor>();

        services.AddSingleton(TimeProvider.System);
    }
}