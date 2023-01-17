using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace LMS.Database.Model
{
    [Table("Instructors")]
    public class Instructor: User
    {        
        public string Specialty { get; set; } = string.Empty;
        
        public List<Course> Courses { get; set; } = new List<Course>();
    }
}