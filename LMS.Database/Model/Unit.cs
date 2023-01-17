using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMS.Database.Model
{
    [Table("Units")]
    public class Unit
    {
        [Required]
        public Guid Id { get; set; }

        public Guid CourseId { get; set; }

        public Guid InstructorId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Title is too long.")]
        public string Title { get; set; } = string.Empty;
        
        [StringLength(250, ErrorMessage = "Description is too long.")]
        public string? Description { get; set; }

        public List<Lesson> Lessons { get; set; } = new List<Lesson>();

        public List<Assignment> Assignments { get; set; } = new List<Assignment>();

        public List<Test> Tests { get; set; } = new List<Test>();

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public bool Share { get; set; }

        [Required]
        [MaxLength(50)]
        public string CreatedBy { get; set; } = "Author";

        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [MaxLength(50)]
        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}
