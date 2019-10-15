using System;
using System.Collections.Generic;
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
        public string Title { get; set; }
        /// <summary>
        /// Holds a string with the ingredients for the Recipe object
        /// </summary>
        public string Ingredients { get; set; }
        /// <summary>
        /// Holds the preparation time for the Recipe object
        /// </summary>
        public float PrepTime { get; set; }
        /// <summary>
        /// Holds the cooking time for the Recipe object
        /// </summary>
        public float CookTime { get; set; }
        /// <summary>
        /// Holds a string with the intructions for the Recipe object
        /// </summary>
        public string Instructions { get; set; }
    }
}
