using System;
using System.Collections.Generic;

namespace Interface;

public partial class Employee
{
    public int Id { get; set; }

    public int? EmployeePostId { get; set; }

    public string FirstName { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public decimal Salary { get; set; }

    public string EmployeeAddress { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public virtual Post? EmployeePost { get; set; }

    public virtual ICollection<Prevjob> Prevjobs { get; } = new List<Prevjob>();
}
