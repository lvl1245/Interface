using System;
using System.Collections.Generic;

namespace Interface.Models;

public partial class User
{
    public int UserId { get; set; }

    public byte[] UserPassword { get; set; } = null!;

    public byte[] UserLogin { get; set; } = null!;

    public int UserPermission { get; set; }

    public string? UserName { get; set; }
}
