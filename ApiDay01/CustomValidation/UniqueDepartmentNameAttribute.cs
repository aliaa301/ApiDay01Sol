using ApiDay01.Repositories;
using System.ComponentModel.DataAnnotations;

namespace ApiDay01.CustomValidation
{
    public class UniqueDepartmentNameAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var departmentName = value as string;

            // Access the repository using DI
            var departmentRepository = (IDepartmentRepository)validationContext.GetService(typeof(IDepartmentRepository));

            // Check if the department name already exists
            var existingDepartment = departmentRepository.GetAll().FirstOrDefault(d => d.Name == departmentName);

            if (existingDepartment != null)
            {
                return new ValidationResult("Department name must be unique.", new[] { validationContext.MemberName });
            }

            return ValidationResult.Success;
        }
    }
}
