using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public interface IRecipe_IngredientRepository
    {
        IQueryable<Recipe_Ingredient> Recipe_IngredientList { get; }

        void SaveRecipe_Ingredient(Recipe_Ingredient recipe_ingredient);
    }
}
