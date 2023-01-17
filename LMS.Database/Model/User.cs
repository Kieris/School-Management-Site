using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMS.Database.Model
{
    public abstract class User
    {
        [Required]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "User name is required.")]
        [StringLength(20, ErrorMessage = "User name is too long.")]
        public string Username { get; set; } = string.Empty;

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(30, ErrorMessage = "First name is too long.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(30, ErrorMessage = "Last name is too long.")]
        public string LastName { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "Address is too long.")]
        public string? Address { get; set; }

        [StringLength(30, ErrorMessage = "City is too long.")]
        public string? City { get; set; }

        [StringLength(30, ErrorMessage = "State is too long.")]
        public string? State { get; set; }

        public bool Current { get; set; }

        [Phone]
        public string? Phone { get; set; }

        [Phone]
        public string? AltPhone { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [EmailAddress]
        public string? AltEmail { get; set; }

        public Guid CalendarId { get; set; }

        public Calendar Calendar { get; set; } = new Calendar();

        [Required]
        [MaxLength(20)]
        public string CreatedBy { get; set; } = "Author";

        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [MaxLength(50)]
        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}