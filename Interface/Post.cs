using System;
using System.Collections.Generic;

namespace Interface;

public partial class Post
{
    public int PostId { get; set; }

    public string PostName { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
