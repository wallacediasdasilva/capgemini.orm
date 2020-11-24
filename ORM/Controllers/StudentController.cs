using Microsoft.AspNetCore.Mvc;
using ORM.Application.App.Interface;
using ORM.Domain.Model;
using System.Collections.Generic;

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
        public IEnumerable<Student> Get()
        {
            return _studentApplication.ListAll();
        }

        [HttpPost]
        public Student Post([FromBody] Student student)
        {
            return _studentApplication.Create(student);
        }

        [HttpPut("{id}")]
        public Student Put([FromQuery] int id, [FromBody] Student student)
        {
            return _studentApplication.Update(id, student);
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] int id)
        {
            _studentApplication.Delete(id);

            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult Patch([FromQuery] int id, [FromBody] Student student)
        {
            _studentApplication.Patch(id, student);

            return Ok();
        }
    }
}
