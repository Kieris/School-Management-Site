using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using LMS.Database.Tests.DataSeed;
using LMS.Database;
using System.Threading.Tasks;
using Xunit;

namespace LMS.Database.Tests;

public abstract class DatabaseUnitTest : IAsyncLifetime
{
    protected readonly LMSDbContext context;

    protected readonly DataSeederRunner runner;

    public abstract IEnumerable<IDataSeeder> Seeders { get; }

    protected DatabaseUnitTest()
    {
        var connection = new SqliteConnection($"DataSource=:memory:");
        connection.Open();
        var optionsBuilder = new DbContextOptionsBuilder().UseSqlite(connection);
        context = new SqliteDbContext(optionsBuilder.Options);
        runner = new DataSeederRunner(context);
    }

    public virtual async Task InitializeAsync()
    {
        await context.Database.EnsureCreatedAsync();
        await SeedDataAsync();
    }

    public virtual async Task DisposeAsync()
    {
        await context.Database.EnsureDeletedAsync();
    }

    protected virtual async Task SeedDataAsync()
    {
        foreach(var seeder in Seeders)
        {
            runner.AddSeed(seeder);
        }
        await runner.RunAsync();
    }
}