using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyFirstWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private static List<string> values = new List<string> { "Apple", "Banana" };

        [HttpGet]
        public IActionResult Get() => Ok(values);

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id >= values.Count) return NotFound();
            return Ok(values[id]);
        }

        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            values.Add(value);
            return Ok("Added");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            if (id >= values.Count) return NotFound();
            values[id] = value;
            return Ok("Updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id >= values.Count) return NotFound();
            values.RemoveAt(id);
            return Ok("Deleted");
        }
    }
}
