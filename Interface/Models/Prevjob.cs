using System;
using System.Collections.Generic;

namespace Interface.Models;

public partial class Prevjob
{
    public int PrevJobId { get; set; }

    public int? EmployeesId { get; set; }

    public int OrderNumber { get; set; }

    public DateTime OrderDate { get; set; }

    public virtual Employee? Employees { get; set; }
}
