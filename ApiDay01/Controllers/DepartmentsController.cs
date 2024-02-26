using ApiDay01.Models;
using ApiDay01.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDay01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        // GET api/departments
        [HttpGet]
        public IActionResult GetAll()
        {
            var departments = _departmentRepository.GetAll();
            return Ok(departments);
        }

        // GET api/departments/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department == null)
                return NotFound();
            return Ok(department);
        }

        // POST api/departments
        [HttpPost]
        public IActionResult Add([FromBody] Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _departmentRepository.Add(department);
            return CreatedAtAction(nameof(GetById), new { id = department.Id }, department);
        }

        // PUT api/departments/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Department department)
        {
            if (id != department.Id)
                return BadRequest();

            var existingDepartment = _departmentRepository.GetById(id);
            if (existingDepartment == null)
                return NotFound();

            _departmentRepository.Update(department);
            return NoContent();
        }

        // DELETE api/departments/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department == null)
                return NotFound();

            _departmentRepository.Delete(id);
            return Ok(department);
        }
    }
}
