using System.Collections.Generic;
using System.Linq;
using TechnixAPI.Models.Custom;
using TechnixAPI.Models;

namespace TechnixAPI.Service
{
	public class DepartmentService
	{
		public IEnumerable<Department> GetAllDepartment()
		{
			using (var db = new AppDbContext())
			{
				var res = db.Departments.ToList();
				return res;
			}
		}

		public Department GetDepartmentById(int id)
		{
			using (var db = new AppDbContext())
			{
				var res = db.Departments.FirstOrDefault(x => x.Id == id);
				return res ?? new Department();
			}
		}

		public bool CreateDepartment(DepartmentModel entity)
		{
			using (var db = new AppDbContext())
			{
			Department obj=new Department()
			{
				 Id =entity.Id, 
				 DepartmentName =entity.DepartmentName, 
			};
				db.Departments.Add(obj);
				db.SaveChanges();
				return true;
			}
		}

		public bool UpdateDepartment(DepartmentModel entity)
		{
			using (var db = new AppDbContext())
			{
				var res = db.Departments.FirstOrDefault(x => x.Id == entity.Id);
				if (res == null) return false;
				 res.Id =entity.Id; 
				 res.DepartmentName =entity.DepartmentName; 
				db.Departments.Update(res);
				db.SaveChanges();
				return true;
			}
		}

		public bool DeleteDepartment(int id)
		{
			using (var db = new AppDbContext())
			{
				var res = db.Departments.FirstOrDefault(x => x.Id == id);
				if (res == null) return false;
				db.Departments.Remove(res);
				db.SaveChanges();
				return true;
			}
		}
	}
}
