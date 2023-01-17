using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace LMS.Database.Tests.DataSeed;


public class DataSeederRunner
{
    private readonly LMSDbContext context;
    List<IDataSeeder> seeders = new List<IDataSeeder>();

    public DataSeederRunner(LMSDbContext context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
    }

    internal void AddSeed<TSeeder>() where TSeeder : IDataSeeder, new()
    {
        seeders.Add(new TSeeder());
    }

    internal void AddSeed(IDataSeeder seeder)
    {
        if (seeder is null)
        {
            throw new ArgumentNullException(nameof(seeder));
        }
        seeders.Add(seeder);
    }

    internal async Task RunAsync()
    {
        foreach(var seeder in seeders)
        {
            await seeder.Seed(context);
            await context.SaveChangesAsync();
        }
    }
}
