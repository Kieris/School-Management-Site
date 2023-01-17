using Microsoft.EntityFrameworkCore;
using LMS.Database.Model;

namespace LMS.Database;

public abstract class LMSDbContext: DbContext 
{

    protected string MigrationsAssembly = Configuration.GetValue<string>("MigrationsAssemblyName");

    protected LMSDbContext() : base()
    {

    }

    protected LMSDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Administrator> Administrators { get; set; } = default!;
    public DbSet<Assignment> Assignments { get; set; } = default!;
    public DbSet<Calendar> Calendars { get; set; } = default!;
    public DbSet<CalendarItem> CalendarItems { get; set; } = default!;
    public DbSet<Course> Courses { get; set; } = default!;
    public DbSet<Grade> Grades { get; set; } = default!;
    public DbSet<Instructor> Instructors { get; set; } = default!;
    public DbSet<Lesson> Lessons { get; set; } = default!;
    public DbSet<LessonPage> LessonPages { get; set; } = default!;
    public DbSet<Media> Media { get; set; } = default!;
    public DbSet<QA> QAs { get; set; } = default!;
    public DbSet<QASection> QASections { get; set; } = default!;
    public DbSet<Question> Questions { get; set; } = default!;
    public DbSet<QuestionOption> QuestionOptions { get; set; } = default!;
    public DbSet<RelatedLink> RelatedLinks { get; set; } = default!;
    public DbSet<Student> Students { get; set; } = default!;
    public DbSet<StudyGuide> StudyGuides { get; set; } = default!;
    public DbSet<Test> Tests { get; set; } = default!;
    public DbSet<Unit> Units { get; set; } = default!;


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }


}