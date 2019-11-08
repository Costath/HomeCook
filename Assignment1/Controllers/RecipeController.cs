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

        public RecipeController (IRecipeRepository recipes, IIngredientRepository ingredients)
        {
            recipeRepository = recipes;
            ingredientRepository = ingredients;
        }
        public ViewResult Home()
        {
            return View();
        }
        //Action that renders the DisplayPage view passing a single Recipe object according to the received parameter
        [Route("{recipeID}")] //Attribute to receive the recipeID from the previous view
        public ViewResult DisplayPage(int recipeID)
        {
            return View(recipeRepository.RecipeList
                .Where(r => r.RecipeID == recipeID));
        }
        public ViewResult UserPage()
        {
            return View();
        }
        public ViewResult AllRecipes()
        {
            //return View(Repository.recipes);
            return View(recipeRepository.RecipeList);
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
        public ViewResult AddRecipe(Recipe recipe)
        {
            Repository.AddRecipe(recipe);
            return View("DisplayPage", recipeRepository.RecipeList
                .Where(r => r.RecipeID == recipe.RecipeID));
        }
        public PartialViewResult Partial_AddRecipe()
        {
            return PartialView();
        }
    }
}