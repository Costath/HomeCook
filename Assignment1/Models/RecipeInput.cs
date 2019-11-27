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
            this.Reviews = new List<Review> { };
        }
        /// <summary>
        /// Holds a List with the ingredients for the Recipe object
        /// </summary>
        [Required(ErrorMessage = "At least one ingredient is required")]
        public List<IngredientInput> Ingredients { get; set; }
        public List<Review> Reviews { get; set; }
        /// <summary>
        /// Creates a RecipeInput object from the recipeID received as parameter
        /// </summary>
        /// <param name="recipeID"></param>
        /// <param name="recipeRepository"></param>
        /// <param name="ingredientRepository"></param>
        /// <param name="recipe_ingredientRepository"></param>
        /// <returns></returns>
        public static RecipeInput convertIntoRecipeInput(int recipeID, IRecipeRepository recipeRepository, IIngredientRepository ingredientRepository, IRecipe_IngredientRepository recipe_ingredientRepository, IReviewRepository reviewRepository)
        {
            Recipe recipe;

            recipe = recipeRepository.RecipeList
                        .FirstOrDefault(r => r.RecipeID == recipeID);
            RecipeInput recipeInput = new RecipeInput { };
            Ingredient ingredient = new Ingredient();
            IngredientInput ingredientInput;
            Review review;

            recipeInput.RecipeID = recipeID;
            recipeInput.Title = recipe.Title;
            recipeInput.Category = recipe.Category;
            recipeInput.TotalTime = recipe.TotalTime;
            recipeInput.CookTime = recipe.CookTime;
            recipeInput.Instructions = recipe.Instructions;
            recipe.Category = recipeInput.Category;

            foreach (Recipe_Ingredient ri in recipe_ingredientRepository.Recipe_IngredientList
                                                .Where(r => r.RecipeID == recipeID))
            {
                ingredientInput = new IngredientInput
                {
                    IngredientID = ri.IngredientID,
                    Name = ingredientRepository.Ingredients
                            .FirstOrDefault(i => i.IngredientID == ri.IngredientID).Name,
                    Quantity = ri.Quantity,
                    UnitOfMeasurement = ri.UnitOfMeasurement
                };

                recipeInput.Ingredients.Add(ingredientInput);
            }

            foreach (Review rev in reviewRepository.Reviews
                                                .Where(r => r.RecipeID == recipeID))
            {
                review = new Review
                {
                    Rating = rev.Rating,
                    Comments = rev.Comments
                };

                recipeInput.Reviews.Add(review);
            }

            return recipeInput;
        }
    }
}
