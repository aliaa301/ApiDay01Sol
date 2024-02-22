using ApiDay01.Entity;
using ApiDay01.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiDay01.Repositories
{
    public class StudentRepository : IStudentRepository
    {
         ApplicationDbContext applicationDbContext;

        public StudentRepository(ApplicationDbContext context)
        {
            applicationDbContext = context;
        }

        public IEnumerable<Student> GetAll()
        {
            return applicationDbContext.Students.ToList();
        }

        public Student GetById(int id)
        {
            return applicationDbContext.Students.FirstOrDefault(std => std.Id == id);
        }

        public IEnumerable<Student> GetByName(string name)
        {
            return applicationDbContext.Students.Where(std => std.Name == name).ToList();
        }

        public void Add(Student student)
        {
            applicationDbContext.Students.Add(student);
            applicationDbContext.SaveChanges();
        }

        public void Update(Student student)
        {
            applicationDbContext.Students.Update(student);
            applicationDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = applicationDbContext.Students.FirstOrDefault(std => std.Id == id);
            if (student != null)
            {
                applicationDbContext.Students.Remove(student);
                applicationDbContext.SaveChanges();
            }
        }
    }
}
