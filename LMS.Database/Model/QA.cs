using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMS.Database.Model
{
    [Table("QAs")]
    public class QA
    {
        [Required]
        public Guid Id { get; set; }

        public Guid QASectionId { get; set; }

        public Guid MediaItemId { get; set; }
        
        [Required]
        [StringLength(1000, ErrorMessage = "Question is too long.")]
        public string Question { get; set; }  = string.Empty;

        [Required]
        [StringLength(1000, ErrorMessage = "Answer is too long.")]
        public string Answer { get; set; }  = string.Empty;

        public Media? MediaItem { get; set; }
    }
}