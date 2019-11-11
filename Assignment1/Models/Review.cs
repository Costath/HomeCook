using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Assignment1.Models
{
    public class Review
    {
        /// <summary>
        /// Unique ID for each review
        /// </summary>
        [Key]
        [BindNever]
        public int ReviewID { get; set; }
        /// <summary>
        /// Reference for the recipe reviewed
        /// </summary>
        public int RecipeID { get; set; }
        /// <summary>
        /// Textual comments for each review
        /// </summary>
        public string Comments { get; set; }
        /// <summary>
        /// Numeric rating from 1 to 5 for each review
        /// </summary>
        public int Rating { get; set; }
    }
}
