using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LMS.Database;

public class MariaDbContext: LMSDbContext
{
    public string ConnectionString => _connectionString;
    private string _connectionString = Configuration.GetConnectionString("Test-MariaDB");

    // Replace with your server version and type.
    // Use 'MariaDbServerVersion' for MariaDB. MySqlServerVersion if not.
    // Alternatively, use 'ServerVersion.AutoDetect(connectionString)'.
    // For common usages, see pull request #1233.
    private MariaDbServerVersion serverVersion = new MariaDbServerVersion(new Version(10, 4, 6));

    public MariaDbContext() : base()
    {

    }

    public MariaDbContext(DbContextOptions options) : base(options)
    {

    }

    public MariaDbContext(string dbFilePath) : base()
    {
        _connectionString = $"Data Source ={dbFilePath}";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        base.OnConfiguring(options);
        if (!options.IsConfigured)
        {
            _connectionString = _connectionString ?? Configuration.GetConnectionString("Test-MariaDB");
            options.UseMySql(_connectionString, serverVersion)
                // The following three options help with debugging, but should
                // be changed or removed for production.
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }
    }
}