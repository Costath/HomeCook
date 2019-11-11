using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class Recipe_IngredientRepository : IRecipe_IngredientRepository
    {
        /// <summary>
        /// Recipe_Ingredient DB context
        /// </summary>
        private ApplicationDbContext context;

        public Recipe_IngredientRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        /// <summary>
        /// Recipe_Ingredient DB table
        /// </summary>
        public IQueryable<Recipe_Ingredient> Recipe_IngredientList => context.Recipe_Ingredient;
        /// <summary>
        /// Saves a Recipe_Ingredient object to the database
        /// </summary>
        /// <param name="recipe_ingredient"></param>
        public void SaveRecipe_Ingredient(Recipe_Ingredient recipe_ingredient)
        {
            if (Recipe_IngredientList
                .Any(r => (r.RecipeID == recipe_ingredient.RecipeID && r.IngredientID == recipe_ingredient.IngredientID)))
            {
                context.Recipe_Ingredient.Update(recipe_ingredient);
            }
            else
            {
                context.Recipe_Ingredient.Add(recipe_ingredient);
            }
            context.SaveChanges();
        }
    }
}
