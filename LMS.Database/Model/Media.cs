using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMS.Database.Model
{
    public enum MediaType 
    {
        Image = 0,
        Audio = 1,
        Video = 2
    }

    public enum FileLocType
    {
        Embedded = 0,
        Local = 1
    }


    [Table("Media")]
    public class Media
    {
        [Required]
        public Guid Id { get; set; }
        
        public Guid LessonPageId { get; set; }

        public MediaType Type { get; set; }
        public FileLocType LocType { get; set; }
        
        [StringLength(300, ErrorMessage = "Path is too long.")]
        public string FilePath { get; set; } = "Path";

        [StringLength(200, ErrorMessage = "Heading is too long.")]
        public string Heading { get; set; } = "Heading";

        [Required]
        [StringLength(30, ErrorMessage = "Created author is too long.")]
        public string CreatedBy { get; set; } = "Author";

        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [StringLength(30, ErrorMessage = "Updated author is too long.")]
        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}