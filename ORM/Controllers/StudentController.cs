using Microsoft.AspNetCore.Mvc;
using ORM.Application.App.Interface;
using ORM.Domain.Model;
using System;

namespace ORM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {

        private readonly IStudentApplication _studentApplication;

        public StudentController(IStudentApplication studentApplication)
        {
            _studentApplication = studentApplication;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_studentApplication.ListAll());
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            try
            {
                return Created("", _studentApplication.Create(student));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromQuery] int id, [FromBody] Student student)
        {
            try
            {
                return Created("", _studentApplication.Update(id, student));
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] int id)
        {
            
            try
            {
                _studentApplication.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPatch("{id}")]
        public IActionResult Patch([FromQuery] int id, [FromBody] Student student)
        {
            try
            {
                _studentApplication.Patch(id, student);

                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}
