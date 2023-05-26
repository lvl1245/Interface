using System;
using System.Collections.Generic;

namespace Interface.Models;

public partial class ProviderProduct
{
    public int? ProviderId { get; set; }

    public int? ProductId { get; set; }

    public int ProviderProductsId { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Provider? Provider { get; set; }
}
