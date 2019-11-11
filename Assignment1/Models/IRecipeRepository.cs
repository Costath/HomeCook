using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public interface IRecipeRepository
    {
        IQueryable<Recipe> RecipeList { get; }

        void SaveRecipe(Recipe recipe);

        void deleteRecipe(int recipeID);
    }
}
