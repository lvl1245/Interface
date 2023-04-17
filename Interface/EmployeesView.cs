using System;
using System.Collections.Generic;

namespace Interface;

public partial class EmployeesView
{
    public string EmpName { get; set; } = null!;

    public decimal Salary { get; set; }

    public DateTime DateOfBirth { get; set; }
}
