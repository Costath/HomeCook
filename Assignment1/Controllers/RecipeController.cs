using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Infrastructure;
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
        public ViewResult DisplayPage(string title)
        {
            return View(new RecipeListViewModel
            {
                Recipes = Repository.Recipes
                .Where(r => r.Title == title)
            }.Recipes);
        }
        public ViewResult UserPage()
        {
            return View();
        }
        public ViewResult AllRecipes()
        {
            return View(Repository.Recipes);
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
            return View("DisplayPage", new RecipeListViewModel
            {
                Recipes = Repository.Recipes
                .Where(r => r.Title == recipe.Title)
            }.Recipes);
        }
        public PartialViewResult Partial_AddRecipe()
        {
            return PartialView();
        }
    }
}