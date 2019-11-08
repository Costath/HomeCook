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
        /// 
        /// </summary>
        public static List<Ingredient> ingredients = new List<Ingredient> { };
        /// <summary>
        /// Adds a new Recipe object to the recipes List
        /// </summary>
        /// <param name="recipe"></param>
        public static void AddRecipe(Recipe recipe)
        {
            recipe.RecipeID = (recipes.Count() == 0) ? 0 : recipes.Last().RecipeID + 1;

            recipes.Add(recipe);
        }
        /// <summary>
        /// Adds a new Ingredient object to the ingredients List
        /// </summary>
        /// <param name="ingredient"></param>
        public static void AddIngredient(Ingredient ingredient)
        {
            ingredient.IngredientID = (ingredients.Count() == 0) ? 0 : ingredients.Last().IngredientID + 1;

            ingredients.Add(ingredient);
        }
    }
}
