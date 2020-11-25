using Microsoft.AspNetCore.Mvc;
using ORM.Application.App.Interface;
using ORM.Domain.Model;
using System;

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
        public IActionResult Get()
        {
            try
            {
                return Ok(_coordinatorApplication.ListAll());
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Coordinator coordinator)
        {
            try
            {
                return Created("", _coordinatorApplication.Create(coordinator));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromQuery] int id, [FromBody] Coordinator coordinator)
        {
            try
            {
                return Ok(_coordinatorApplication.Update(id, coordinator));
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
                _coordinatorApplication.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}
