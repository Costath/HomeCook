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
        }
        /// <summary>
        /// Holds a List with the ingredients for the Recipe object
        /// </summary>
        [Required(ErrorMessage = "At least one ingredient is required")]
        public List<IngredientInput> Ingredients { get; set; }
    }
}
