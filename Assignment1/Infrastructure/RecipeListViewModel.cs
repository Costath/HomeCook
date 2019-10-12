using System;
using System.Collections.Generic;
using System.Linq;
using Assignment1.Models;

namespace Assignment1.Infrastructure
{
    public class RecipeListViewModel
    {
        public IEnumerable<Recipe> Recipes { get; set; }
    }
}
