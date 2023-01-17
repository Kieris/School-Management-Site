using Microsoft.EntityFrameworkCore;

namespace LMS.Database;

public class SqliteDbContext: LMSDbContext
{
    public string ConnectionString => _connectionString;
    private string _connectionString = Configuration.GetConnectionString("Test-Sqlite");

    public SqliteDbContext() : base()
    {

    }

    public SqliteDbContext(DbContextOptions options) : base(options)
    {

    }

    public SqliteDbContext(string dbFilePath) : base()
    {
        _connectionString = $"Data Source ={dbFilePath}";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        base.OnConfiguring(options);
        if (!options.IsConfigured)
        {
            _connectionString = _connectionString ?? Configuration.GetConnectionString("Test-Sqlite");
            options.UseSqlite(_connectionString, x => x.MigrationsAssembly(MigrationsAssembly));
        }
    }
}