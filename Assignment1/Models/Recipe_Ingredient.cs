using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class Recipe_Ingredient
    {
        /// <summary>
        /// Reference to RecipeID from Recipe table
        /// </summary>
        [Key]
        public int RecipeID { get; set; }
        /// <summary>
        /// Reference to IngredientID from Ingredient table
        /// </summary>
        [Key]
        public int IngredientID { get; set; }
        /// <summary>
        /// Quantity of the Ingredient
        /// </summary>
        public float? Quantity { get; set; }
        /// <summary>
        /// Unit of measurement used for this Ingredient
        /// </summary>
        public _unitOfMeasurement UnitOfMeasurement { get; set; }
        /// <summary>
        /// Possible entries for unit of measurements
        /// </summary>
        public enum _unitOfMeasurement
        {
            litter,
            ml,
            gram,
            kg,
            oz,
            fl_oz,
            pound,
            tbsp,
            tsp,
            cup,
            unit,
            atWill
        }
    }
}
