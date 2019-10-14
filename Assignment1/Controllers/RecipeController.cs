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
        public ViewResult Home()
        {
            return View();
        }
        [Route("{recipeID}")]
        public ViewResult DisplayPage(int recipeID)
        {
            return View(Repository.recipes
                .Where(r => r.RecipeID == recipeID));
        }
        public ViewResult UserPage()
        {
            return View();
        }
        public ViewResult AllRecipes()
        {
            return View(Repository.recipes);
        }
        [HttpGet]
        public ViewResult AddRecipe()
        {
            return View();
        }
        [HttpPost]
        public ViewResult AddRecipe(Recipe recipe)
        {
            Repository.AddRecipe(recipe);
            return View("DisplayPage", Repository.recipes
                .Where(r => r.RecipeID == recipe.RecipeID));
        }
        public PartialViewResult Partial_AddRecipe()
        {
            return PartialView();
        }
    }
}