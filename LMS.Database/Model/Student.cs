using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Database.Model
{
    [Table("Students")]
    public class Student: User
    {
        public List<Parent> Parents { get; set; } = new List<Parent>();

        public List<Course> Courses { get; set; } = new List<Course>();

        public List<Grade> Grades { get; set; } = new List<Grade>();

        public byte Year { get; set; }

    }
}