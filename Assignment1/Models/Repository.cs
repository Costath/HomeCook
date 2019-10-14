using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public static class Repository
    {
        public static List<Recipe> recipes = new List<Recipe> { };

        public static void AddRecipe(Recipe recipe)
        {
            recipe.RecipeID = (recipes.Count() == 0) ? 0 : recipes.Last().RecipeID + 1;

            recipes.Add(recipe);
        }
    }
}
