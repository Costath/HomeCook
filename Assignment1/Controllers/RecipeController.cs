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
        public ViewResult DisplayPage(int recipeID)
        {
            //RecipeListViewModel rec = new RecipeListViewModel
            //{
            //    Recipes = Repository.Recipes
            //    .Where(r => r.Title == title)
            //};

            //rec.Recipes.First().Title = rec.Recipes.First().Title.Replace('_', ' ');
            //return View(rec.Recipes);

            return View(new RecipeListViewModel
            {
                Recipes = Repository.Recipes
                //.Where(r => r.Title == title)
                .Where(r => r.RecipeID == recipeID)
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
            //recipe.Title = recipe.Title.Replace(' ', '_');
            Repository.AddRecipe(recipe);
            return View("DisplayPage", new RecipeListViewModel
            {
                Recipes = Repository.Recipes
                //.Where(r => r.Title == recipe.Title)
                .Where(r => r.RecipeID == recipe.RecipeID)
            }.Recipes);
        }
        public PartialViewResult Partial_AddRecipe()
        {
            return PartialView();
        }
    }
}