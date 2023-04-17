using System;
using System.Collections.Generic;

namespace Interface;

public partial class DrinkIngridient
{
    public int DrinkIngridientId { get; set; }

    public int? DrinkId { get; set; }

    public int? IngredientId { get; set; }

    public virtual Drink? Drink { get; set; }

    public virtual Ingredient? Ingredient { get; set; }
}
