using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Assignment1.Models
{
    public class Ingredient
    {
        /// <summary>
        /// Unique ID for each Ingredient object
        /// </summary>
        [Key]
        public int IngredientID { get; set; }
        /// <summary>
        /// Name of the Ingredient
        /// </summary>
        public string Name { get; set; }
    }
}
