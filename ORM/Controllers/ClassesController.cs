using Microsoft.AspNetCore.Mvc;
using ORM.Application.App.Interface;
using ORM.Domain.Model;
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
        public IEnumerable<Classes> Get()
        {
            return _classesApplication.ListAll();
        }

        [HttpPost]
        public Classes Post([FromBody] Classes classes)
        {
            return _classesApplication.CreateStudent(classes);
        }

        [HttpPut("{id}")]
        public Classes Put([FromQuery] int id, [FromBody] Classes classes)
        {
            return _classesApplication.UpdateStudent(id, classes);
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] int id)
        {
            _classesApplication.DeleteStudent(id);

            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult Patch([FromQuery] int id, [FromBody] Classes classes)
        {
            _classesApplication.Patch(id, classes);

            return Ok();
        }

        [HttpPost]
        [Route("[controller]/[action]")]
        public IActionResult Relashionship([FromBody] Registration registration)
        {
            _classesApplication.Relashionship(registration);

            return Ok();
        }
    }
}
