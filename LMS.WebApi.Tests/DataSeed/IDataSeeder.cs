using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Database.Tests.DataSeed;

public interface IDataSeeder
{
    Task Seed(LMSDbContext context);
}

public interface IDataSeeder<TSeeded> : IDataSeeder
{
    IReadOnlyList<TSeeded> SeededEntities { get; }
}

public interface IDataSeeder<TSeeded1, TSeeded2> : IDataSeeder
{
    IReadOnlyList<TSeeded1> SeededEntities1 { get; }
    IReadOnlyList<TSeeded2> SeededEntities2 { get; }

}