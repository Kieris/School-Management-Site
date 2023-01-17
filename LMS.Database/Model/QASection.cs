using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMS.Database.Model
{
    [Table("QASections")]
    public class QASection
    {
        [Required]
        public Guid Id { get; set; }

        public Guid StudyGuideId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Title is too long.")]
        public string Title { get; set; } = string.Empty;
        
        public List<QA> QAs { get; set; } = new List<QA>();
    }
}