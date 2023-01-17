using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMS.Database.Model
{
    [Table("Assignments")]
    public class Assignment
    {
        [Required]
        public Guid Id { get; set; }

        public Guid CourseId { get; set; }

        public Guid UnitId { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "Text is too long.")]
        public string Text { get; set; }

        public DateTime? DueDate { get; set; }

        public bool Visible { get; set; }

        public Assignment(string text, bool visible, DateTime? dueDate)
        {
            Text = text;
            Visible = visible;
            DueDate = dueDate;
        }
    }
}