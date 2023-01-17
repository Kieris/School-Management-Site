using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMS.Database.Model
{
    [Table("Lessons")]
    public class Lesson
    {
        [Required]
        public Guid Id { get; set; }

        public Guid UnitId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Title is too long.")]
        public string Title { get; set; } = "Title";
        
        [StringLength(250, ErrorMessage = "Description is too long.")]
        public string? Description { get; set; }

        public List<LessonPage> Pages { get; set; } = new List<LessonPage>();

        public List<Test> Tests { get; set; } = new List<Test>();

        public DateTime? DueDate { get; set; }

        public bool Visible { get; set; }

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
