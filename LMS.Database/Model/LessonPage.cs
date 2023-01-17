using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMS.Database.Model
{
    [Table("LessonPages")]
    public class LessonPage
    {
        [Required]
        public Guid Id { get; set; }

        public Guid LessonId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Title is too long.")]
        public string Title { get; set; } = string.Empty;
        
        [StringLength(4000, ErrorMessage = "Text is too long.")]
        public string? Text { get; set; }

        public List<Media> MediaItems { get; set; } = new List<Media>();

        public List<RelatedLink> Links { get; set; } = new List<RelatedLink>();

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