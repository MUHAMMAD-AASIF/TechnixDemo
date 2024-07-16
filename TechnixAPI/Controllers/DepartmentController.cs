using Microsoft.AspNetCore.Mvc;
using TechnixAPI.Service;
using TechnixAPI.Models.Custom;

namespace TechnixAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class DepartmentController : ControllerBase
	{
		private readonly DepartmentService _departmentService;

		public DepartmentController(DepartmentService departmentService)
		{
			_departmentService = departmentService;
		}

		[HttpGet("GetAllDepartment")]
		public IActionResult GetAllDepartment()
		{
			var result = _departmentService.GetAllDepartment();
			return Ok(result);
		}

		[HttpGet("GetDepartmentById")]
		public IActionResult GetDepartmentById(int id)
		{
			var result = _departmentService.GetDepartmentById(id);
			if (result == null)
			{
				return NotFound();
			}
			return Ok(result);
		}

		[HttpPost("CreateDepartment")]
		public IActionResult CreateDepartment([FromBody] DepartmentModel entity)
		{
			var result = _departmentService.CreateDepartment(entity);
			return Ok(result);
		}

		[HttpPut("UpdateDepartment")]
		public IActionResult UpdateDepartment([FromBody] DepartmentModel entity)
		{
			var result = _departmentService.UpdateDepartment(entity);
			if (result == null)
			{
				return NotFound();
			}
			return Ok(result);
		}

		[HttpDelete("Department")]
		public IActionResult DeleteDepartment(int id)
		{
			var result = _departmentService.DeleteDepartment(id);
			if (!result)
			{
				return NotFound();
			}
			return NoContent();
		}
	}
}
