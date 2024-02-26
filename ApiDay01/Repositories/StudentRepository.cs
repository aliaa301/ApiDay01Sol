using ApiDay01.Entity;
using ApiDay01.Models;
using Microsoft.EntityFrameworkCore;
using System;

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
            return applicationDbContext.Students.Include(std => std.Department).ToList();
        }

        public Student GetById(int id)
        {
            return applicationDbContext.Students.Include(std => std.Department).FirstOrDefault(s => s.Id == id);
        }

        
        public Student GetByName(string name)
        {
            return applicationDbContext.Students.Include(std => std.Department).FirstOrDefault(std => std.Name == name);

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
