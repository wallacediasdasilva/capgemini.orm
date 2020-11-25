using Microsoft.AspNetCore.Mvc;
using ORM.Application.App.Interface;
using ORM.Domain.Model;
using System;
using System.Collections.Generic;

namespace ORM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClassesController : ControllerBase
    {
        private readonly IClassesApplication _classesApplication;

        public ClassesController(IClassesApplication classesApplication)
        {
            _classesApplication = classesApplication;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Classes>> Get()
        {
            try
            {
                return Ok(_classesApplication.ListAll());
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Classes classes)
        {
            try
            {
                return Created("", _classesApplication.CreateStudent(classes));

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromQuery] int id, [FromBody] Classes classes)
        {
            try
            {
                return Ok(_classesApplication.UpdateStudent(id, classes));
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
                _classesApplication.DeleteStudent(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPatch("{id}")]
        public IActionResult Patch([FromQuery] int id, [FromBody] Classes classes)
        {
            try
            {
                _classesApplication.Patch(id, classes);

                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPost]
        [Route("[controller]/[action]")]
        public IActionResult Relashionship([FromBody] Registration registration)
        {
            try
            {
                _classesApplication.Relashionship(registration);

                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}
