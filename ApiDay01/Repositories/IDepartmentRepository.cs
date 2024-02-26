using ApiDay01.Models;

namespace ApiDay01.Repositories
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAll();
        Department GetById(int id);
        Department GetByName(string name);
        void Add(Department department);
        void Update(Department department);
        void Delete(int id);
    }
}
