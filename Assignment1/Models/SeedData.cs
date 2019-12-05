using System.Linq;
using Microsoft.AspNetCore.Builder;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;

namespace Assignment1.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Recipes.Any())
            {
                context.Recipes.AddRange(
                    new Recipe {
                        Title = "Steamed Rice",
                        Category = "Asian",
                        TotalTime = 20,
                        CookTime = 12,
                        Instructions = "1 - Mix all ingredients in a saucepan, then put it on the stovetop;" +
                                        "2 - Set the temperature to mid heat and wait the water dry out;" +
                                        "3 - Once there is no more water, remove the saucepan from heat;"
                    },
                    new Recipe
                    {
                        Title = "Grilled Chicken Breast",
                        Category = "Brazilian",
                        TotalTime = 45,
                        CookTime = 15,
                        Instructions = "1 - In a medium bowl, whisk together balsamic vinegar, olive oil, brown sugar, garlic, and dried herbs, and season generously with salt and pepper. Reserve ¼ cup;" +
                                        "2 - Add chicken to the bowl and toss to combine. Let marinate at least 20 minutes and up to overnight;" +
                                        "3 - Preheat grill to medium high. Add chicken and grill, basting with reserved marinade, until cooked through, 6 minutes per side;" +
                                        "4 - Garnish with parsley before serving."
                    },
                    new Recipe
                    {
                        Title = "Slow-Cooker Pork Shoulder",
                        Category = "Slow Cooker",
                        TotalTime = 500,
                        CookTime = 480,
                        Instructions = "1 - Dry pork shoulder with a paper towel and make 1” incisions with a knife all over;" +
                                        "2 - Pulse garlic, ¼ cup oil, cumin, salt, pepper, and oregano in a food processor until a paste is formed. Remove 2 tablespoons of the paste and set aside;" +
                                        "3 - Rub pork shoulder all over with remaining paste, pushing some of it into the incisions;" +
                                        "4 - Place pork in slow cooker, cover, and cook on low until meat is fork-tender but not yet completely falling apart, 7 1/2 to 8 hours;" +
                                        "5 - To make the sauce, heat remaining ¼ cup oil in a small saucepan over medium heat until shimmering. Add reserved 2 tablespoons garlic paste and let sizzle, " +
                                                "stirring continuously until fragrant, just about 1 minute. Remove from heat and let cool before whisking in orange juice, lime juice, serrano, and cilantro;" +
                                        "6 - Serve sliced pork over rice with sauce drizzled on top."
                    }
                );
            }
            if (!context.Ingredients.Any())
            {
                context.Ingredients.AddRange(
                    new Ingredient()
                    {
                        Name = "White rice"
                    },
                    new Ingredient()
                    {
                        Name = "Water"
                    },
                    new Ingredient()
                    {
                        Name = "Garlic"
                    },
                    new Ingredient()
                    {
                        Name = "Salt"
                    },
                    new Ingredient()
                    {
                        Name = "balsamic vinegar"
                    },
                    new Ingredient()
                    {
                        Name = "extra-virgin olive oil"
                    },
                    new Ingredient()
                    {
                        Name = "brown sugar"
                    },
                    new Ingredient()
                    {
                        Name = "cloves garlic, minced"
                    },
                    new Ingredient()
                    {
                        Name = "dried thyme"
                    },
                    new Ingredient()
                    {
                        Name = "dried rosemary"
                    },
                    new Ingredient()
                    {
                        Name = "chicken breasts"
                    },
                    new Ingredient()
                    {
                        Name = "Freshly ground black pepper"
                    },
                    new Ingredient()
                    {
                        Name = "Freshly chopped parsley"
                    },
                    new Ingredient()
                    {
                        Name = "boneless, skinless pork shoulder, boston butt"
                    },
                    new Ingredient()
                    {
                        Name = "cloves garlic"
                    },
                    new Ingredient()
                    {
                        Name = "olive oil"
                    },
                    new Ingredient()
                    {
                        Name = "cumin"
                    },
                    new Ingredient()
                    {
                        Name = "black pepper"
                    },
                    new Ingredient()
                    {
                        Name = "oregano leaves"
                    },
                    new Ingredient()
                    {
                        Name = "fresh squeezed orange juice"
                    },
                    new Ingredient()
                    {
                        Name = "fresh squeezed lime juice"
                    },
                    new Ingredient()
                    {
                        Name = "serrano, seeded, and diced"
                    },
                    new Ingredient()
                    {
                        Name = "freshly chopped fresh cilantro"
                    },
                    new Ingredient()
                    {
                        Name = "White rice, for serving"
                    }
                );
            }
            if (!context.Recipe_Ingredient.Any())
            {
                context.Recipe_Ingredient.AddRange(
                    new Recipe_Ingredient()
                    {
                        IngredientID = 1,
                        RecipeID = 1,
                        Quantity = 1.5F,
                        UnitOfMeasurement = Recipe_Ingredient._unitOfMeasurement.cup
                    },
                    new Recipe_Ingredient()
                    {
                        IngredientID = 2,
                        RecipeID = 1,
                        Quantity = 2.5F,
                        UnitOfMeasurement = Recipe_Ingredient._unitOfMeasurement.cup
                    },
                    new Recipe_Ingredient()
                    {
                        IngredientID = 3,
                        RecipeID = 1,
                        Quantity = 3,
                        UnitOfMeasurement = Recipe_Ingredient._unitOfMeasurement.unit
                    },
                    new Recipe_Ingredient()
                    {
                        IngredientID = 4,
                        RecipeID = 1,
                        UnitOfMeasurement = Recipe_Ingredient._unitOfMeasurement.atWill
                    },
                    new Recipe_Ingredient()
                    {
                        IngredientID = 5,
                        RecipeID = 2,
                        Quantity = 0.25F,
                        UnitOfMeasurement = Recipe_Ingredient._unitOfMeasurement.cup
                    },
                    new Recipe_Ingredient()
                    {
                        IngredientID = 6,
                        RecipeID = 2,
                        Quantity = 3,
                        UnitOfMeasurement = Recipe_Ingredient._unitOfMeasurement.tbsp
                    },
                    new Recipe_Ingredient()
                    {
                        IngredientID = 7,
                        RecipeID = 2,
                        Quantity = 2,
                        UnitOfMeasurement = Recipe_Ingredient._unitOfMeasurement.tbsp
                    },
                    new Recipe_Ingredient()
                    {
                        IngredientID = 8,
                        RecipeID = 2,
                        Quantity = 3,
                        UnitOfMeasurement = Recipe_Ingredient._unitOfMeasurement.unit
                    },
                    new Recipe_Ingredient()
                    {
                        IngredientID = 9,
                        RecipeID = 2,
                        Quantity = 1,
                        UnitOfMeasurement = Recipe_Ingredient._unitOfMeasurement.tsp
                    },
                    new Recipe_Ingredient()
                    {
                        IngredientID = 10,
                        RecipeID = 2,
                        Quantity = 1,
                        UnitOfMeasurement = Recipe_Ingredient._unitOfMeasurement.tsp
                    },
                    new Recipe_Ingredient()
                    {
                        IngredientID = 11,
                        RecipeID = 2,
                        Quantity = 4,
                        UnitOfMeasurement = Recipe_Ingredient._unitOfMeasurement.unit
                    },
                    new Recipe_Ingredient()
                    {
                        IngredientID = 4,
                        RecipeID = 2,
                        UnitOfMeasurement = Recipe_Ingredient._unitOfMeasurement.atWill
                    },
                    new Recipe_Ingredient()
                    {
                        IngredientID = 12,
                        RecipeID = 2,
                        UnitOfMeasurement = Recipe_Ingredient._unitOfMeasurement.atWill
                    },
                    new Recipe_Ingredient()
                    {
                        IngredientID = 13,
                        RecipeID = 2,
                        UnitOfMeasurement = Recipe_Ingredient._unitOfMeasurement.atWill
                    },
                    new Recipe_Ingredient()
                    {
                        IngredientID = 14,
                        RecipeID = 3,
                        Quantity = 6,
                        UnitOfMeasurement = Recipe_Ingredient._unitOfMeasurement.pound
                    },
                    new Recipe_Ingredient()
                    {
                        IngredientID = 15,
                        RecipeID = 3,
                        Quantity = 6,
                        UnitOfMeasurement = Recipe_Ingredient._unitOfMeasurement.unit
                    },
                    new Recipe_Ingredient()
                    {
                        IngredientID = 16,
                        RecipeID = 3,
                        Quantity = 0.5F,
                        UnitOfMeasurement = Recipe_Ingredient._unitOfMeasurement.cup
                    },
                    new Recipe_Ingredient()
                    {
                        IngredientID = 17,
                        RecipeID = 3,
                        Quantity = 2,
                        UnitOfMeasurement = Recipe_Ingredient._unitOfMeasurement.tsp
                    },
                    new Recipe_Ingredient()
                    {
                        IngredientID = 4,
                        RecipeID = 3,
                        Quantity = 2,
                        UnitOfMeasurement = Recipe_Ingredient._unitOfMeasurement.tbsp
                    },
                    new Recipe_Ingredient()
                    {
                        IngredientID = 18,
                        RecipeID = 3,
                        Quantity = 1,
                        UnitOfMeasurement = Recipe_Ingredient._unitOfMeasurement.tbsp
                    },
                    new Recipe_Ingredient()
                    {
                        IngredientID = 19,
                        RecipeID = 3,
                        Quantity = 3,
                        UnitOfMeasurement = Recipe_Ingredient._unitOfMeasurement.tbsp
                    },
                    new Recipe_Ingredient()
                    {
                        IngredientID = 20,
                        RecipeID = 3,
                        Quantity = 0.5F,
                        UnitOfMeasurement = Recipe_Ingredient._unitOfMeasurement.cup
                    },
                    new Recipe_Ingredient()
                    {
                        IngredientID = 21,
                        RecipeID = 3,
                        Quantity = 0.25F,
                        UnitOfMeasurement = Recipe_Ingredient._unitOfMeasurement.cup
                    },
                    new Recipe_Ingredient()
                    {
                        IngredientID = 22,
                        RecipeID = 3,
                        Quantity = 1,
                        UnitOfMeasurement = Recipe_Ingredient._unitOfMeasurement.unit
                    },
                    new Recipe_Ingredient()
                    {
                        IngredientID = 23,
                        RecipeID = 3,
                        Quantity = 0.25F,
                        UnitOfMeasurement = Recipe_Ingredient._unitOfMeasurement.cup
                    },
                    new Recipe_Ingredient()
                    {
                        IngredientID = 24,
                        RecipeID = 3,
                        UnitOfMeasurement = Recipe_Ingredient._unitOfMeasurement.atWill
                    }
                    );
            }
            context.SaveChanges();
        }

    }
}
