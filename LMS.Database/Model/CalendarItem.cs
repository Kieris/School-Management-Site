using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMS.Database.Model
{
    [Table("CalendarItems")]
    public class CalendarItem
    {
        [Required]
        public Guid Id { get; set; }

        public Guid CalendarId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Title is too long.")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(250, ErrorMessage = "Description is too long.")]
        public string? Description { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}