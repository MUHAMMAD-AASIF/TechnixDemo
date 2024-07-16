using System;
using System.Collections.Generic;

namespace TechnixAPI.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string EmpName { get; set; } = null!;

    public int Age { get; set; }

    public int DepartmentId { get; set; }

    public bool? IsPermenant { get; set; }

    public string? Email { get; set; }

    public virtual Department Department { get; set; } = null!;
}
