using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMS.Database.Model
{
    [Table("StudyGuides")]
    public class StudyGuide
    {
        [Required]
        public Guid Id { get; set; }

        public Guid MediaItemId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Title is too long.")]
        public string Title { get; set; } = string.Empty;
        
        [StringLength(50, ErrorMessage = "Text is too long.")]
        public string? Text { get; set; }

        public List<QASection> QASections { get; set; } = new List<QASection>();

        public Media? MediaItem { get; set; }
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