using ApiDay01.DTOs;
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
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
        _studentRepository = (StudentRepository?)studentRepository;
        }

        // GET: api/students
        [HttpGet]
        public IActionResult GetAll()
        {
            var students = _studentRepository.GetAll();
            if (students == null)
            {
                return NotFound();
            }
            return Ok(students);
        }

        // GET: api/students/5
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            var student = _studentRepository.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            StudWithDept stdDTO = new StudWithDept();
            stdDTO.Student_Id = student.Id;
            stdDTO.Student_Name = student.Name;
            stdDTO.Student_Age = student.Age;
            stdDTO.Student_Address = student.Address;
            stdDTO.Student_Department = student.Department.Name;
            return Ok(stdDTO);
        }

        [HttpGet]
        [Route("{name:alpha}")]
        public IActionResult GetByName(string name)
        {
            var student = _studentRepository.GetByName(name);
            if (student is null)
            {
                return NotFound();
            }
            StudWithDept stdDTO = new StudWithDept();
            stdDTO.Student_Id = student.Id;
            stdDTO.Student_Name = student.Name;
            stdDTO.Student_Age = student.Age;
            stdDTO.Student_Address = student.Address;
            stdDTO.Student_Department = student.Department.Name;
            return Ok(stdDTO);
        }
        // POST: api/students
        [HttpPost]
        public IActionResult Add([FromBody] Student student)
        {
            if (ModelState.IsValid)
            {
                _studentRepository.Add(student);
                return CreatedAtAction(actionName: "GetById", routeValues: new { id = student.Id }, "");
            }
            return BadRequest();
        }

        // PUT: api/students/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Student student)
        {
            if (ModelState.IsValid)
            {
                _studentRepository.Update(student);
                return NoContent();
            }
            return BadRequest();
            //if (id != student.Id)
            //    return BadRequest();

            //var existingStudent = _studentRepository.GetById(id);
            //if (existingStudent == null)
            //    return NotFound();

            //_studentRepository.Update(student);
            //return NoContent();
        }

        // DELETE: api/students/5
        [HttpDelete]
        [Route("{id:int}")]
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
