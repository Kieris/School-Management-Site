using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace LMS.Database.Model
{
    [Table("Tests")]
    public class Test
    {
        [Required]
        public Guid Id { get; set; }

        public Guid CourseId { get; set; }

        public Guid LessonId { get; set; }

        public Guid UnitId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Title is too long.")]
        public string Title { get; set; } = string.Empty;
        
        public List<Question> Questions { get; set; } = new List<Question>();

        public DateTime? DueDate { get; set; }

        public bool Visible { get; set; }

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
