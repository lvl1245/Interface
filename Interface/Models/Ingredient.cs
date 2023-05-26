using System;
using System.Collections.Generic;

namespace Interface.Models;

public partial class Ingredient
{
    public int IngredientId { get; set; }

    public int? ProductId { get; set; }

    public int IngredientCount { get; set; }

    public virtual ICollection<DrinkIngridient> DrinkIngridients { get; } = new List<DrinkIngridient>();

    public virtual ICollection<FoodIngridient> FoodIngridients { get; } = new List<FoodIngridient>();

    public virtual Product? Product { get; set; }
}
