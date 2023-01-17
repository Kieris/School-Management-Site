using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace LMS.Database.Model
{
    public enum CourseType
    {
        Core = 0,
        Elective = 1,
        Athletic = 2
    }

    [Table("Courses")]
    public class Course
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name is too long.")]
        public string Name { get; set; } = string.Empty;

        public byte PrefYear { get; set; }

        public CourseType Type { get; set; }

        public short Length { get; set; } //minutes

        public string Days { get; set; } = string.Empty;

        public string Semesters { get; set; } = string.Empty;

        public List<Unit> Units { get; set; } = new List<Unit>();

        public List<Assignment> Assignments { get; set; } = new List<Assignment>();

        public List<Test> Tests { get; set; } = new List<Test>();

        public List<Instructor> Instructors { get; set; } = new List<Instructor>();

        public List<Student> Students { get; set; } = new List<Student>();

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