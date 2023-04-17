using System;
using System.Collections.Generic;

namespace Interface;

public partial class FoodIngridient
{
    public int FoodIngridientId { get; set; }

    public int? DrinkId { get; set; }

    public int? IngredientId { get; set; }

    public virtual Drink? Drink { get; set; }

    public virtual Ingredient? Ingredient { get; set; }
}
