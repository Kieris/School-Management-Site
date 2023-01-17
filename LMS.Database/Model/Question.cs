using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMS.Database.Model
{
    public enum QuestionType
    {
        MultipleChoice = 0,
    }

    [Table("Questions")]
    public class Question
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "The question text is too long.")]
        public string QText { get; set; } = string.Empty;

        [Required]
        public QuestionType Type { get; set; }

        [StringLength(1250, ErrorMessage = "The explanation text is too long.")]
        public string? Explanation { get; set; }

        public Guid TestId { get; set; }

        public Guid MediaItemId { get; set; }

        public Media? MediaItem { get; set; }

        public List<QuestionOption> Options { get; set; } = new List<QuestionOption>();

        public List<RelatedLink> Links { get; set; } = new List<RelatedLink>();
    }
}