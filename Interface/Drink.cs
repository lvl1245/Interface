using System;
using System.Collections.Generic;

namespace Interface;

public partial class Drink
{
    public int DrinkId { get; set; }

    public string DrinkName { get; set; } = null!;

    public double Percents { get; set; }

    public int DrinkWeight { get; set; }

    public string Capasity { get; set; } = null!;

    public double TotalPrice { get; set; }

    public virtual ICollection<DrinkIngridient> DrinkIngridients { get; } = new List<DrinkIngridient>();

    public virtual ICollection<FoodIngridient> FoodIngridients { get; } = new List<FoodIngridient>();
}
