using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MySqlConnector;
using PressUpAspireApp.Domain.Models;
using PressUpAspireApp.Domain.Repositories;
using PressUpAspireApp.Infrastructure.Options;
using PressUpAspireApp.Infrastructure.Persistence;
using PressUpAspireApp.Infrastructure.Repositories;

namespace PressUpAspireApp.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        AddInfrastructureOptions(services);
        AddDbContexts(services);
        AddInfrastructureHealthChecks(services);
        AddRepositories(services);
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IBaseRepository<MenuItemModel>, MenuItemRepository>();
    }

    private static void AddInfrastructureOptions(IServiceCollection services)
    {
        services.ConfigureOptions<DatabaseOptionsSetup>();
    }

    private static void AddDbContexts(IServiceCollection services)
    {
        var sp = services.BuildServiceProvider();
        var databaseOptions = sp.GetRequiredService<IOptions<DatabaseOptions>>().Value;

        services.AddMySqlDataSource(databaseOptions.ConnectionString, connectionLifetime: ServiceLifetime.Scoped);

        services.AddDbContextPool<PressUpApiDbContext>(options =>
        {
            options.UseMySQL(databaseOptions.ConnectionString);
        });
    }

    private static void AddInfrastructureHealthChecks(IServiceCollection services)
    {
        services.AddHealthChecks().AddMySql().AddDbContextCheck<PressUpApiDbContext>();
    }
}