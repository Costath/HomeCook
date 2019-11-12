using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class IngredientRepository : IIngredientRepository
    {
        /// <summary>
        /// Ingredient DB context
        /// </summary>
        private ApplicationDbContext context;

        public IngredientRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        /// <summary>
        /// Ingredient DB table
        /// </summary>
        public IQueryable<Ingredient> Ingredients => context.Ingredients;
        /// <summary>
        /// Saves a List of Ingredient objects to the database
        /// </summary>
        /// <param name="ingredients"></param>
        public void SaveIngredients(List<Ingredient> ingredients)
        {
            foreach (Ingredient ingredient in ingredients)
            {
                if (Ingredients.Any(i => i.IngredientID == ingredient.IngredientID))
                {
                    context.Ingredients.Update(ingredient);
                }
                else if (!string.IsNullOrEmpty(ingredient.Name))
                {
                    context.Ingredients.Add(ingredient);
                }
            }
            context.SaveChanges();
        }
    }
}
