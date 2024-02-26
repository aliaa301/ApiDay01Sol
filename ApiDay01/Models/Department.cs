using ApiDay01.CustomValidation;
using System.ComponentModel.DataAnnotations;

namespace ApiDay01.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Department name is required.")]
        [UniqueDepartmentName]
        public string Name { get; set; }
        public string Location { get; set; }
        public string Manager { get; set; }
        public virtual ICollection<Student>? Students { get; set; }

    }
}
