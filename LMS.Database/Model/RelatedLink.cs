using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMS.Database.Model
{
    public enum RelatedLinkType
    {
        External = 0,
        Internal = 1,
        Reference = 2
    }

    [Table("RelatedLinks")]
    public class RelatedLink
    {
        [Required]
        public Guid Id { get; set; }

        public Guid LessonPageId { get; set; }
        public Guid QuestionId { get; set; }

        public RelatedLinkType Type { get; set; }

        [StringLength(300, ErrorMessage = "Path is too long.")]
        public string Path { get; set; } = string.Empty;

    }
}