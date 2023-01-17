using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMS.Database.Model
{
    [Table("Calendars")]
    public class Calendar
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Title is too long.")]
        public string Title { get; set; } = string.Empty;

        public List<CalendarItem> Items { get; set; } = new List<CalendarItem>();
    }
}