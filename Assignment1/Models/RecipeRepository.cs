using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class RecipeRepository : IRecipeRepository
    {
        /// <summary>
        /// Recipe DB context
        /// </summary>
        private ApplicationDbContext context;

        public RecipeRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        /// <summary>
        /// Recipe DB table
        /// </summary>
        public IQueryable<Recipe> RecipeList => context.Recipes;
        /// <summary>
        /// Saves a Recipe object to the database
        /// </summary>
        /// <param name="recipe"></param>
        public void SaveRecipe(Recipe recipe)
        {
            if (RecipeList.Any(r => r.RecipeID == recipe.RecipeID))
            {
                context.Recipes.Update(recipe);
            }
            else
            {
                context.Recipes.Add(recipe);
            }
            context.SaveChanges();
        }
    }
}
