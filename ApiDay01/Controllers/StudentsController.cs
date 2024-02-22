using ApiDay01.Models;
using ApiDay01.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDay01.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
        _studentRepository = studentRepository;
        }

        // GET: api/students
        [HttpGet]
        public IActionResult GetAll()
        {
        var students = _studentRepository.GetAll();
        return Ok(students);
        }

        // GET: api/students/5
        [HttpGet("{id}", Name = "GetStudentById")]
        public IActionResult GetById(int id)
        {
            var student = _studentRepository.GetById(id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        // POST: api/students
        [HttpPost]
        public IActionResult Add([FromBody] Student student)
        {
            if (student == null)
                return BadRequest();

            _studentRepository.Add(student);
            return CreatedAtRoute("GetStudentById", new { id = student.Id }, student);
        }

        // PUT: api/students/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Student student)
        {
            if (id != student.Id)
                return BadRequest();

            var existingStudent = _studentRepository.GetById(id);
            if (existingStudent == null)
                return NotFound();

            _studentRepository.Update(student);
            return NoContent();
        }

        // DELETE: api/students/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _studentRepository.GetById(id);
            if (student == null)
                return NotFound();

            _studentRepository.Delete(id);
            return Ok(student);
        }
    }
}
