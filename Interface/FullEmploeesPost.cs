using System;
using System.Collections.Generic;

namespace Interface;

public partial class FullEmploeesPost
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public decimal Salary { get; set; }

    public string EmployeeAddress { get; set; } = null!;

    public string PostName { get; set; } = null!;
}
