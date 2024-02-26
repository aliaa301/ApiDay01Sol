using ApiDay01.Models;

namespace ApiDay01.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        Student GetById(int id);
        Student GetByName(string name);
        void Add(Student student);
        void Update(Student student);
        void Delete(int id);
    }
}
