using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    public class CRUDController : Controller
    {
        private IRecipeRepository recipeRepository;
        private IIngredientRepository ingredientRepository;
        private IRecipe_IngredientRepository recipe_ingredientRepository;

        public CRUDController(IRecipeRepository recipes, IIngredientRepository ingredients, IRecipe_IngredientRepository recipes_ingredients)
        {
            recipeRepository = recipes;
            ingredientRepository = ingredients;
            recipe_ingredientRepository = recipes_ingredients;
        }
        //When the AddRecipe view is opened from the link in the navigation menu it is rendered by this action
        [HttpGet]
        public ViewResult AddRecipe()
        {
            return View();
        }
        /*When a Recipe object is created from AddRecipe view, the page is reloaded with the post method. 
            This action adds the just created Recipe object to the Repository and renders the DisplayPage view passing this Recipe object*/
        [HttpPost]
        public ViewResult AddRecipe(RecipeInput recipeInput)
        {
            Ingredient temp;
            Recipe recipe = new Recipe();
            List<Ingredient> ingredients = new List<Ingredient>();
            Recipe_Ingredient recipe_ingredient = new Recipe_Ingredient();

            // transfers recipe information from recipeInput to a Recipe object to add in the repository later
            recipe.Title = recipeInput.Title;
            recipe.TotalTime = recipeInput.TotalTime;
            recipe.CookTime = recipeInput.CookTime;
            recipe.Instructions = recipeInput.Instructions;

            foreach (IngredientInput ingredient in recipeInput.Ingredients) // transfers ingredient names from recipeInput to an Ingredient list to add in the repository later
            {
                temp = new Ingredient();
                temp.Name = ingredient.Name;
                ingredients.Add(temp);
            }

            recipeRepository.SaveRecipe(recipe);
            ingredientRepository.SaveIngredients(ingredients);

            foreach (IngredientInput ingredient in recipeInput.Ingredients)
            {
                try
                {
                    recipe_ingredient.IngredientID = ingredientRepository.Ingredients
                                                        .FirstOrDefault(i => i.Name == ingredient.Name).IngredientID;
                }
                catch (Exception)
                {
                    continue;
                }

                recipe_ingredient.RecipeID = recipeRepository.RecipeList.Last().RecipeID;
                recipe_ingredient.Quantity = ingredient.Quantity;
                recipe_ingredient.UnitOfMeasurement = ingredient.UnitOfMeasurement;

                recipe_ingredientRepository.SaveRecipe_Ingredient(recipe_ingredient);
            }

            return View("../Recipe/DisplayPage", recipeInput);
        }
        public PartialViewResult Partial_AddRecipe()
        {
            return PartialView();
        }
    }
}