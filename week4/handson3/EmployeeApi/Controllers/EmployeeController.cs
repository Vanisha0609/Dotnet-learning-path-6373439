using Microsoft.AspNetCore.Mvc;
using EmployeeApi.Models;
using EmployeeApi.Filters;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(CustomAuthFilter))] // Custom Filter
    public class EmployeeController : ControllerBase
    {
        [HttpGet("standard")]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public ActionResult<List<Employee>> GetStandard()
{
    throw new Exception("Test exception for filter");
}


        [HttpPost]
        public IActionResult PostEmployee([FromBody] Employee emp)
        {
            return Ok(emp);
        }

        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "John",
                    Salary = 50000,
                    Permanent = true,
                    Department = new Department { Id = 1, Name = "IT" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 1, Name = "C#" },
                        new Skill { Id = 2, Name = "ASP.NET" }
                    },
                    DateOfBirth = new DateTime(1990, 1, 1)
                }
            };
        }
    }
}
