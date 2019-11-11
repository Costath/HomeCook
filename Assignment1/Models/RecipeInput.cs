using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class RecipeInput : Recipe
    {
        public RecipeInput()
        {
            this.Ingredients = new List<IngredientInput> { };
        }
        /// <summary>
        /// Holds a List with the ingredients for the Recipe object
        /// </summary>
        [Required(ErrorMessage = "At least one ingredient is required")]
        public List<IngredientInput> Ingredients { get; set; }

        public static RecipeInput convertIntoRecipeInput(int recipeID, IRecipeRepository recipeRepository, IIngredientRepository ingredientRepository, IRecipe_IngredientRepository recipe_ingredientRepository)
        {
            Recipe recipe;

            recipe = recipeRepository.RecipeList
                        .FirstOrDefault(r => r.RecipeID == recipeID);
            RecipeInput recipeInput = new RecipeInput { };
            IngredientInput ingredientInput;
            Ingredient ingredient = new Ingredient();

            recipeInput.RecipeID = recipeID;
            recipeInput.Title = recipe.Title;
            recipeInput.TotalTime = recipe.TotalTime;
            recipeInput.CookTime = recipe.CookTime;
            recipeInput.Instructions = recipe.Instructions;

            foreach (Recipe_Ingredient ri in recipe_ingredientRepository.Recipe_IngredientList
                                                .Where(r => r.RecipeID == recipeID))
            {
                ingredientInput = new IngredientInput
                {
                    Name = ingredientRepository.Ingredients
                            .FirstOrDefault(i => i.IngredientID == ri.IngredientID).Name,
                    Quantity = ri.Quantity,
                    UnitOfMeasurement = ri.UnitOfMeasurement
                };

                recipeInput.Ingredients.Add(ingredientInput);
            }

            return recipeInput;
        }
    }
}
