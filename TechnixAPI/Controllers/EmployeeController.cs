using Microsoft.AspNetCore.Mvc;
using TechnixAPI.Service;
using TechnixAPI.Models.Custom;

namespace TechnixAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class EmployeeController : ControllerBase
	{
		private readonly EmployeeService _employeeService;

		public EmployeeController(EmployeeService employeeService)
		{
			_employeeService = employeeService;
		}

		[HttpGet("GetAllEmployee")]
		public IActionResult GetAllEmployee()
		{
			var result = _employeeService.GetAllEmployee();
			return Ok(result);
		}

		[HttpGet("GetEmployeeById")]
		public IActionResult GetEmployeeById(int id)
		{
			var result = _employeeService.GetEmployeeById(id);
			if (result == null)
			{
				return NotFound();
			}
			return Ok(result);
		}

		[HttpPost("CreateEmployee")]
		public IActionResult CreateEmployee([FromBody] EmployeeModel entity)
		{
			var result = _employeeService.CreateEmployee(entity);
			return Ok(result);
		}

		[HttpPut("UpdateEmployee")]
		public IActionResult UpdateEmployee([FromBody] EmployeeModel entity)
		{
			var result = _employeeService.UpdateEmployee(entity);
			if (result == null)
			{
				return NotFound();
			}
			return Ok(result);
		}

		[HttpDelete("Employee")]
		public IActionResult DeleteEmployee(int id)
		{
			var result = _employeeService.DeleteEmployee(id);
			if (!result)
			{
				return NotFound();
			}
			return NoContent();
		}
	}
}
