using ApiDay01.Entity;
using ApiDay01.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiDay01.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _dbContext;



        public DepartmentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Department> GetAll()
        {
            return _dbContext.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return _dbContext.Departments.FirstOrDefault(d => d.Id == id);
        }

        public Department GetByName(string name)
        {
            return _dbContext.Departments.FirstOrDefault(d => d.Name == name);
        }

        public void Add(Department department)
        {
            _dbContext.Departments.Add(department);
            _dbContext.SaveChanges();
        }

        public void Update(Department department)
        {
            _dbContext.Entry(department).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var department = _dbContext.Departments.Find(id);
            if (department != null)
            {
                _dbContext.Departments.Remove(department);
                _dbContext.SaveChanges();
            }
        }

    }
}
