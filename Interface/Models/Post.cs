using System;
using System.Collections.Generic;

namespace Interface.Models;

public partial class Post
{
    public int PostId { get; set; }

    public string PostName { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
