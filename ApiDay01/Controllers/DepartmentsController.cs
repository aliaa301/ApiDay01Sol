﻿using ApiDay01.CustomFilter;
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

        [HttpGet]
        public IActionResult GetAll()
        {
            var departments = _departmentRepository.GetAll();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department == null)
                return NotFound();

            return Ok(department);
        }

        [HttpGet("name/{name}")]
        public IActionResult GetByName(string name)
        {
            var department = _departmentRepository.GetByName(name);
            if (department == null)
                return NotFound();

            return Ok(department);
        }

        [HttpPost]
        [LocationFilter("EG", "USA")] // Example allowed locations
        public IActionResult Add([FromBody] Department department)
        {
            //// Custom validation for unique department name
            //var existingDepartment = _departmentRepository.GetByName(department.Name);
            //if (existingDepartment != null)
            //    return BadRequest("Department name must be unique.");

            //_departmentRepository.Add(department);
            //return Ok();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _departmentRepository.Add(department);
            return CreatedAtAction(nameof(GetById), new { id = department.Id }, department);
        }
    





        [HttpPut]
        [LocationFilter("EG", "USA")] // Example allowed locations
        public IActionResult Update( Department department)
        {
            if(ModelState.IsValid)
            {
                _departmentRepository.Update(department);
                return NoContent();
            }
            return BadRequest();
           
           
        }

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
