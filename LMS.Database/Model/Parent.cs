using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMS.Database.Model
{
    [Table("Parents")]
    public class Parent: User
    {
        public List<Student> Children { get; set; } = new List<Student>();

        public bool HasPrivilege { get; set; }
    }
}