using System.Collections.Generic;
using System.Linq;
using TechnixAPI.Models.Custom;
using TechnixAPI.Models;

namespace TechnixAPI.Service
{
    public class EmployeeService
    {
        public IEnumerable<Employee> GetAllEmployee()
        {
            using (var db = new AppDbContext())
            {
                var res = db.Employees.ToList();
                return res;
            }
        }

        public Employee GetEmployeeById(int id)
        {
            using (var db = new AppDbContext())
            {
                var res = db.Employees.FirstOrDefault(x => x.Id == id);
                return res ?? new Employee();
            }
        }

        public bool CreateEmployee(EmployeeModel entity)
        {
            using (var db = new AppDbContext())
            {
                Employee obj = new Employee()
                {
                    Id = entity.Id,
                    Age = entity.Age,
                    DepartmentId = entity.DepartmentId,
                    Email = entity.Email,
                    EmpName = entity.EmpName,
                    IsPermenant = entity.IsPermenant,
                };
                db.Employees.Add(obj);
                db.SaveChanges();
                return true;
            }
        }

        public bool UpdateEmployee(EmployeeModel entity)
        {
            using (var db = new AppDbContext())
            {
                var res = db.Employees.FirstOrDefault(x => x.Id == entity.Id);
                if (res == null) return false;
                res.Id = entity.Id;
                res.Age = entity.Age;
                res.DepartmentId = entity.DepartmentId;
                res.Email = entity.Email;
                res.EmpName = entity.EmpName;
                res.IsPermenant = entity.IsPermenant;
                db.Employees.Update(res);
                db.SaveChanges();
                return true;
            }
        }

        public bool DeleteEmployee(int id)
        {
            using (var db = new AppDbContext())
            {
                var res = db.Employees.FirstOrDefault(x => x.Id == id);
                if (res == null) return false;
                db.Employees.Remove(res);
                db.SaveChanges();
                return true;
            }
        }
    }
}
