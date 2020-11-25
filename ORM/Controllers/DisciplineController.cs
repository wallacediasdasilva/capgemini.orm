using Microsoft.AspNetCore.Mvc;
using ORM.Application.App.Interface;
using ORM.Domain.Model;
using System;

namespace ORM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DisciplineController : ControllerBase
    {
        private readonly IDisciplineApplication _disciplineApplication;

        public DisciplineController(IDisciplineApplication disciplineApplication)
        {
            _disciplineApplication = disciplineApplication;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_disciplineApplication.ListAll());
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Discipline discipline)
        {
            try
            {
                return Created("", _disciplineApplication.Create(discipline));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromQuery] int id, [FromBody] Discipline discipline)
        {
            try
            {
                return Ok(_disciplineApplication.Update(id, discipline));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] int id)
        {
            try
            {
                _disciplineApplication.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}
