using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiDay01.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        [ForeignKey("Department")]
        public int ?DeptId { get; set; }
        public virtual Department? Department { get; set; }
    }
}
