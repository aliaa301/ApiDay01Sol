using ApiDay01.Models;

namespace ApiDay01.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private List<Department> _departments = new List<Department>();

        public IEnumerable<Department> GetAll()
        {
            return _departments;
        }

        public Department GetById(int id)
        {
            return _departments.FirstOrDefault(d => d.Id == id);
        }

        public Department GetByName(string name)
        {
            return _departments.FirstOrDefault(d => d.Name == name);
        }

        public void Add(Department department)
        {
            _departments.Add(department);
        }

        public void Update(Department department)
        {
            var existingDepartment = _departments.FirstOrDefault(d => d.Id == department.Id);
            if (existingDepartment != null)
            {
                existingDepartment.Name = department.Name;
                existingDepartment.Location = department.Location;
                existingDepartment.Manager = department.Manager;
            }
        }

        public void Delete(int id)
        {
            _departments.RemoveAll(d => d.Id == id);
        }
    }
}
