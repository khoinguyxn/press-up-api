using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PressUpAspireApp.Infrastructure.Persistence;

public class PressUpApiDbContextFactory : IDesignTimeDbContextFactory<PressUpApiDbContext>
{
    private const string ConnectionStringKey = "ConnectionStrings__mysqldb";

    public PressUpApiDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddUserSecrets<PressUpApiDbContextFactory>()
            .AddEnvironmentVariables()
            .Build();

        var connectionString = configuration[ConnectionStringKey] ??
                               throw new InvalidOperationException(
                                   $"Connection string {ConnectionStringKey} is not found!");

        var optionsBuilder = new DbContextOptionsBuilder<PressUpApiDbContext>().UseMySQL(connectionString);

        return new PressUpApiDbContext(optionsBuilder.Options);
    }
}