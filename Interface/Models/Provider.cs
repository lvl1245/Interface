using System;
using System.Collections.Generic;

namespace Interface.Models;

public partial class Provider
{
    public int ProviderId { get; set; }

    public string ProvideName { get; set; } = null!;

    public string Adress { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Fax { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<BankDetail> BankDetails { get; } = new List<BankDetail>();

    public virtual ICollection<ProviderProduct> ProviderProducts { get; } = new List<ProviderProduct>();
}
