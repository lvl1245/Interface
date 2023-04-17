using System;
using System.Collections.Generic;

namespace Interface;

public partial class BankDetail
{
    public int BankId { get; set; }

    public int? ProviderId { get; set; }

    public string City { get; set; } = null!;

    public string CheckingAccount { get; set; } = null!;

    public virtual Provider? Provider { get; set; }
}
