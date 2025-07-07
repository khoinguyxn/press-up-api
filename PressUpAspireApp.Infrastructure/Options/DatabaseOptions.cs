using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace PressUpAspireApp.Infrastructure.Options;

public class DatabaseOptionsSetup(IConfiguration configuration) : IConfigureOptions<DatabaseOptions>
{
    public void Configure(DatabaseOptions options)
    {
        options.ConnectionString = configuration.GetConnectionString(DatabaseOptions.ConnectionStringName) ??
                          throw new
                              InvalidOperationException($"Connection string '{DatabaseOptions.ConnectionStringName}' not found.");
    }
}

public record DatabaseOptions
{
    public const string ConnectionStringName = "mysqldb";
    public required string ConnectionString { get; set; }
};