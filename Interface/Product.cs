using System;
using System.Collections.Generic;

namespace Interface;

public partial class Product
{
    public string ProductName { get; set; } = null!;

    public int ProductId { get; set; }

    public virtual ICollection<Ingredient> Ingredients { get; } = new List<Ingredient>();

    public virtual ICollection<ProviderProduct> ProviderProducts { get; } = new List<ProviderProduct>();
}
