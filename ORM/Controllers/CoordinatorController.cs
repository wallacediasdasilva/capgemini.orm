using Microsoft.AspNetCore.Mvc;
using ORM.Application.App.Interface;
using ORM.Domain.Model;
using System.Collections.Generic;

namespace ORM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoordinatorController : ControllerBase
    {
        private readonly ICoordinatorApplication _coordinatorApplication;

        public CoordinatorController(ICoordinatorApplication coordinatorApplication)
        {
            _coordinatorApplication = coordinatorApplication;
        }

        [HttpGet]
        public IEnumerable<Coordinator> Get()
        {
            return _coordinatorApplication.ListAll();
        }

        [HttpPost]
        public Coordinator Post([FromBody] Coordinator coordinator)
        {
            return _coordinatorApplication.Create(coordinator);
        }

        [HttpPut("{id}")]
        public Coordinator Put([FromQuery] int id, [FromBody] Coordinator coordinator)
        {
            return _coordinatorApplication.Update(id, coordinator);
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] int id)
        {
            _coordinatorApplication.Delete(id);

            return Ok();
        }
    }
}
