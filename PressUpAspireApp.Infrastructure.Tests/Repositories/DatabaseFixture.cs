using System.Data.Common;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PressUpAspireApp.Infrastructure.Persistence;

namespace PressUpAspireApp.Infrastructure.Tests.Repositories;

public sealed class DatabaseFixture : IDisposable
{
    private readonly DbConnection _connection;

    public PressUpApiDbContext DbContext { get; }

    public DatabaseFixture()
    {
        _connection = new SqliteConnection("Filename=:memory:");
        _connection.Open();

        var contextOptions = new DbContextOptionsBuilder<PressUpApiDbContext>().UseSqlite(_connection).Options;

        DbContext = new PressUpApiDbContext(contextOptions);
        DbContext.Database.EnsureCreated();
    }

    public void Dispose()
    {
        _connection.Dispose();
        
        GC.SuppressFinalize(this);
    }
}