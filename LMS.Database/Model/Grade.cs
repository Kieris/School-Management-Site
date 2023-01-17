using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace LMS.Database.Model
{
    public enum GradeType
    {
        Misc = 0,
        Quiz = 1,
        Participation = 2,
        Test = 3,
        Homework = 4,
        Project = 5
    }

    [Table("Grades")]
    public class Grade
    {
        [Required]
        public Guid Id { get; set; }

        public Guid UnitId { get; set; }
        public Guid TestId { get; set; }
        public Guid AssignmentId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name is too long.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        public GradeType Type { get; set; }

        public Unit? Unit { get; set; }

        public Assignment? Assignment { get; set; }

        public Test? Test { get; set; }

        public Guid CourseId { get; set; }

        [Required]
        public Course Course { get; set; } = new Course();

        public Guid StudentId { get; set; }

        [Required]
        public Student Student { get; set; } = new Student();

        [Required]
        [StringLength(30, ErrorMessage = "Create author is too long.")]
        public string CreatedBy { get; set; } = "Author";

        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [StringLength(30, ErrorMessage = "Update author is too long.")]
        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}