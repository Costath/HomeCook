using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public interface IIngredientRepository
    {
        IQueryable<Ingredient> Ingredients { get; }

        void SaveIngredients(List<Ingredient> ingredients);
    }
}
