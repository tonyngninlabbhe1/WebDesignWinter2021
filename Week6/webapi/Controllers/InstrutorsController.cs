using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Database;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstrutorsController : ControllerBase
    {
        private readonly ILogger<InstrutorsController> _logger;

        public InstrutorsController(ILogger<InstrutorsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(getInstrutors());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            
            var instrutor = InMemory.Instrutors.FirstOrDefault(s => s.Id == id);

            if (instrutor == null)
            {
                return NotFound();
            }

            return Ok(instrutor);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Instrutor instrutor)
        {
            instrutor.Id = getNextId();

            InMemory.Instrutors.Add(instrutor);

            return CreatedAtAction(nameof(GetById), new { id = instrutor.Id }, instrutor);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateInstrutor(int id, [FromBody] Instrutor instrutor)
        {
            var existingInstrutor = InMemory.Instrutors.FirstOrDefault(s => s.Id == id);

            if (existingInstrutor == null)
            {
                return NotFound();
            }

            existingInstrutor.FirstName = instrutor.FirstName;
            existingInstrutor.LastName = instrutor.LastName;
            existingInstrutor.MiddleInitial = instrutor.MiddleInitial;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteInstrutor(int id)
        {
            var existingInstrutor = InMemory.Instrutors.FirstOrDefault(s => s.Id == id);

            if (existingInstrutor == null)
            {
                return NotFound();
            }

            InMemory.Instrutors.Remove(existingInstrutor);

            return NoContent();
        }

        private List<Instrutor> getInstrutors()
        {
            return InMemory.Instrutors;
        }  

        private int getNextId()
        {
            return InMemory.Students.Max(p => p.Id) + 1;
        }
    }
}
