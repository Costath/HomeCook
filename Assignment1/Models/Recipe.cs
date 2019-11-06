using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class Recipe
    {
        /// <summary>
        /// Holds a unique ID for each Recipe object
        /// </summary>
        public int RecipeID { get; set; }
        /// <summary>
        /// Holds the title of the Recipe object
        /// </summary>
        [Required(ErrorMessage = "Please enter a title for the recipe")]
        public string Title { get; set; }
        /// <summary>
        /// Holds a string with the ingredients for the Recipe object
        /// </summary>
        public List<Ingredient> Ingredients { get; set; }
        /// <summary>
        /// Holds the preparation time for the Recipe object
        /// </summary>
        [Required(ErrorMessage = "Please enter a preparation time for the recipe")]
        public float PrepTime { get; set; }
        /// <summary>
        /// Holds the cooking time for the Recipe object
        /// </summary>
        [Required(ErrorMessage = "Please enter a cooking time for the recipe")]
        public float CookTime { get; set; }
        /// <summary>
        /// Holds a string with the intructions for the Recipe object
        /// </summary>
        [Required(ErrorMessage = "Please enter a preparation instructions for the recipe")]
        public string Instructions { get; set; }
    }
}
