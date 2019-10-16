using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class Ingredient
    {
        public int IngredientID { get; set; }
        public string Name { get; set; }
        public float Quantity { get; set; }
        public _unitOfMeasurement UnitOfMeasurement { get; set; }
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
            tsp
        }
    }
}
