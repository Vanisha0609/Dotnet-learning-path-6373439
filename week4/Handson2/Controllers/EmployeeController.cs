using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace YourProjectNamespace.Controllers
{
    [ApiController]
    [Route("api/employee")] // Will change this in Step 3
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetEmployees()
        {
            var employees = new List<string> { "John", "Jane", "Alice", "Bob" };
            return Ok(employees);
        }
    }
}
