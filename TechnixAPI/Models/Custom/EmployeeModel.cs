using System;

namespace TechnixAPI.Models.Custom
{
	public class EmployeeModel
	{
		public int Id { get; set; }
		public int Age { get; set; }
		public int DepartmentId { get; set; }
		public string Email { get; set; }
		public string EmpName { get; set; }
		public bool IsPermenant { get; set; }
	}
}
