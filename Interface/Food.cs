using System;
using System.Collections.Generic;

namespace Interface;

public partial class Food
{
    public int FoodId { get; set; }

    public string FoodName { get; set; } = null!;

    public int FoodWeight { get; set; }

    public double? TotalPrice { get; set; }
}
