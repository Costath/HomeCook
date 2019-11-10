using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Models;

namespace Assignment1.Models
{
    public class IngredientInput : Ingredient
    {
        /// <summary>
        /// Quantity of this Ingridient
        /// </summary>
        public float? Quantity { get; set; }
        /// <summary>
        /// Unit of measurement used for this Ingredient
        /// </summary>
        public Recipe_Ingredient._unitOfMeasurement UnitOfMeasurement { get; set; }
    }
}
