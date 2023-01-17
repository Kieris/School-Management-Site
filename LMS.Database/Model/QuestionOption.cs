using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMS.Database.Model
{
    [Table("QuestionOptions")]
    public class QuestionOption
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "Option text is too long.")]
        public string OptionText { get; set; } = string.Empty;

        public Guid QuestionId { get; set; }

        public Guid MediaItemId { get; set; }

        public Media? MediaItem { get; set; }

        [Required]
        public bool IsCorrect { get; set; }
    }
}