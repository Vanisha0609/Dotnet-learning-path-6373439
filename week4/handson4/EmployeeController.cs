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
        // 🔹 Hardcoded list initialized once
        private static List<Employee> employees = new List<Employee>
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

        // ✅ PUT: Update an employee
        [HttpPut("update")]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public ActionResult<Employee> UpdateEmployee([FromBody] Employee emp)
        {
            if (emp.Id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            var existing = employees.FirstOrDefault(e => e.Id == emp.Id);
            if (existing == null)
            {
                return BadRequest("Invalid employee id");
            }

            // 🔄 Update employee data
            existing.Name = emp.Name;
            existing.Salary = emp.Salary;
            existing.Permanent = emp.Permanent;
            existing.Department = emp.Department;
            existing.Skills = emp.Skills;
            existing.DateOfBirth = emp.DateOfBirth;

            return Ok(existing);
        }
    }
}
