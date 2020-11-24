using Microsoft.AspNetCore.Mvc;
using ORM.Application.App.Interface;
using ORM.Domain.Model;
using System.Collections.Generic;

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
        public IEnumerable<Discipline> Get()
        {
            return _disciplineApplication.ListAll();
        }

        [HttpPost]
        public Discipline Post([FromBody] Discipline discipline)
        {
            return _disciplineApplication.Create(discipline);
        }

        [HttpPut("{id}")]
        public Discipline Put([FromQuery] int id, [FromBody] Discipline discipline)
        {
            return _disciplineApplication.Update(id, discipline);
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] int id)
        {
            _disciplineApplication.Delete(id);

            return Ok();
        }
    }
}
