using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    public class RecipeController : Controller
    {
        private IRecipeRepository recipeRepository;
        private IIngredientRepository ingredientRepository;
        private IRecipe_IngredientRepository recipe_ingredientRepository;

        public RecipeController (IRecipeRepository recipes, IIngredientRepository ingredients, IRecipe_IngredientRepository recipes_ingredients)
        {
            recipeRepository = recipes;
            ingredientRepository = ingredients;
            recipe_ingredientRepository = recipes_ingredients;
        }
        public ViewResult Home()
        {
            return View();
        }
        //Action that renders the DisplayPage view passing a single Recipe object according to the received recipeID
        [Route("{recipeID}")] //Attribute to receive the recipeID from the previous view
        public ViewResult DisplayPage(int recipeID = 1)
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
            return View(recipeInput);
        }
        public ViewResult UserPage()
        {
            return View();
        }
        public ViewResult AllRecipes()
        {
            return View(recipeRepository.RecipeList);
        }
        
    }
}