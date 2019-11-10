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
            IQueryable<Ingredient> ingredientPresent;

            foreach (Ingredient ingredient in ingredients)
            {
                if (!string.IsNullOrEmpty(ingredient.Name)) // Only adds to database the ingredients with a name
                {
                    ingredientPresent = Ingredients
                                            .Where(q => q.Name == ingredient.Name);
                    if (!ingredientPresent.Any()) //checks if the ingredient is already present in the database so it doesn't duplicate it
                    {
                        context.Ingredients.Add(ingredient);
                    }
                }
            }
            context.SaveChanges();
        }
    }
}
