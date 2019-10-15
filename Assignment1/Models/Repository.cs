using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public static class Repository
    {
        /// <summary>
        /// Public static List of Recipe objects
        /// </summary>
        public static List<Recipe> recipes = new List<Recipe> { };
        /// <summary>
        /// Adds a new Recipe object to the recipes List
        /// </summary>
        /// <param name="recipe"></param>
        public static void AddRecipe(Recipe recipe)
        {
            recipe.RecipeID = (recipes.Count() == 0) ? 0 : recipes.Last().RecipeID + 1;

            recipes.Add(recipe);
        }
    }
}
