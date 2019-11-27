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
        private IReviewRepository reviewRepository;

        public CRUDController(IRecipeRepository recipes, IIngredientRepository ingredients, IRecipe_IngredientRepository recipes_ingredients, IReviewRepository reviews)
        {
            recipeRepository = recipes;
            ingredientRepository = ingredients;
            recipe_ingredientRepository = recipes_ingredients;
            reviewRepository = reviews;
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

            recipeRepository.SaveRecipe(recipe); // Saves the recipe to the database
            ingredientRepository.SaveIngredients(ingredients); // Saves the ingredients to the database

            foreach (IngredientInput ingredient in recipeInput.Ingredients) // loads recipe_ingredient information to a recipe_ingredient object to add the database
            {
                try
                {
                    recipe_ingredient.IngredientID = ingredientRepository.Ingredients
                                                        .FirstOrDefault(i => i.Name == ingredient.Name).IngredientID;
                }
                catch (System.NullReferenceException)
                {
                    continue;
                }

                recipe_ingredient.RecipeID = recipeRepository.RecipeList.Last().RecipeID;
                if (ingredient.UnitOfMeasurement == Recipe_Ingredient._unitOfMeasurement.atWill)
                {
                    recipe_ingredient.Quantity = null;
                }
                else
                {
                    recipe_ingredient.Quantity = ingredient.Quantity;
                }
                recipe_ingredient.UnitOfMeasurement = ingredient.UnitOfMeasurement;

                recipe_ingredientRepository.SaveRecipe_Ingredient(recipe_ingredient);
            }

            recipeInput.RecipeID = recipeRepository.RecipeList.FirstOrDefault(r => r.Title == recipeInput.Title).RecipeID;

            return View("../Recipe/DisplayPage", recipeInput);
        }
        public PartialViewResult Partial_AddRecipe()
        {
            return PartialView();
        }
        [HttpGet]
        [Route("CRUD/updateRecipe/{recipeID}")]
        public ViewResult updateRecipe(int recipeID)
        {
            RecipeInput recipeInput = RecipeInput.convertIntoRecipeInput(recipeID, recipeRepository, ingredientRepository, recipe_ingredientRepository, reviewRepository);

            return View(recipeInput);
        }
        [HttpPost]
        [Route("CRUD/updateRecipe/{recipeID}")]
        public ViewResult updateRecipe(RecipeInput recipeInput)
        {
            Ingredient temp;
            Recipe recipe = new Recipe();
            List<Ingredient> ingredients = new List<Ingredient>();
            Recipe_Ingredient recipe_ingredient = new Recipe_Ingredient();
            int n = 0;

            // transfers recipe information from recipeInput to a Recipe object to update in the repository later
            recipeInput.RecipeID = Int32.Parse(Request.Form["RecipeID"]);
            recipe.RecipeID = recipeInput.RecipeID;
            recipe.Title = recipeInput.Title;
            recipe.TotalTime = recipeInput.TotalTime;
            recipe.CookTime = recipeInput.CookTime;
            recipe.Instructions = recipeInput.Instructions;

            foreach (IngredientInput ingredient in recipeInput.Ingredients) // transfers ingredient names from recipeInput to an Ingredient list to add in the repository later
            {
                temp = new Ingredient();
                temp.Name = ingredient.Name;
                temp.IngredientID = ingredient.IngredientID;
                ingredients.Add(temp);
            }

            recipeRepository.SaveRecipe(recipe); // Saves the recipe to the database
            ingredientRepository.SaveIngredients(ingredients); // Saves the ingredients to the database

            if (!ingredients.Equals(recipeInput.Ingredients))
            {
                foreach (IngredientInput ingredient in recipeInput.Ingredients) // loads recipe_ingredient information to a recipe_ingredient object to add in the database
                {
                    recipe_ingredient = new Recipe_Ingredient();

                    recipe_ingredient.IngredientID = ingredient.IngredientID;
                    recipe_ingredient.RecipeID = recipe.RecipeID;
                    recipe_ingredient.Quantity = ingredient.Quantity;
                    recipe_ingredient.UnitOfMeasurement = ingredient.UnitOfMeasurement;

                    recipe_ingredientRepository.SaveRecipe_Ingredient(recipe_ingredient);
                }
            }

            return View("../Recipe/DisplayPage", recipeInput);
        }
        [Route("CRUD/deleteRecipe/{recipeID}")]
        public ViewResult deleteRecipe(int recipeID)
        {
            recipeRepository.deleteRecipe(recipeID);

            return View("../Recipe/AllRecipes", recipeRepository.RecipeList);
        }
    }
}