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
        private IReviewRepository reviewRepository;

        public RecipeController (IRecipeRepository recipes, IIngredientRepository ingredients, IRecipe_IngredientRepository recipes_ingredients, IReviewRepository reviews)
        {
            recipeRepository = recipes;
            ingredientRepository = ingredients;
            recipe_ingredientRepository = recipes_ingredients;
            reviewRepository = reviews;
        }
        public ViewResult Home()
        {
            return View();
        }
        //Action that renders the DisplayPage view passing a single Recipe object according to the received recipeID
        [Route("Recipe/DisplayPage/{recipeID}")] //Attribute to receive the recipeID from the previous view
        public ViewResult DisplayPage(int recipeID)
        {
            RecipeInput recipeInput = RecipeInput.convertIntoRecipeInput(recipeID, recipeRepository, ingredientRepository, recipe_ingredientRepository, reviewRepository);

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
        [Route("Recipe/ReviewRecipe/{recipeID}")]
        public ViewResult ReviewRecipe(int recipeID)
        {
            Review review = new Review { RecipeID = recipeID };
            ViewBag.RecipeTitle = recipeRepository.RecipeList.FirstOrDefault(r => r.RecipeID == recipeID).Title;

            return View("UserPage", review);
        }
        [Route("Recipe/SaveReview/{recipeID}")]
        public ViewResult SaveReview(Review review)
        {
            review.RecipeID = Int32.Parse(Request.Form["RecipeID"]);

            reviewRepository.SaveReview(review);

            RecipeInput recipeInput = RecipeInput.convertIntoRecipeInput(review.RecipeID, recipeRepository, ingredientRepository, recipe_ingredientRepository, reviewRepository);

            return View("DisplayPage", recipeInput);
        }
    }
}
