using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class Recipe
    {
        //private int RecipeID { get; set; }
        public string Title { get; set; }
        //private List<Ingredients> Ingredients { get; set; }
        //public List<string> Ingredients { get; set; }
        public string Ingredients { get; set; }
        public float PrepTime { get; set; }
        public float CookTime { get; set; }
        public string Instructions { get; set; }
        //public string ImagePath { get; set; }
    }
}
