using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Recipes.Models
{
    public static class RecipeSeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Recipes.Any())
            {
                context.Recipes.AddRange(
                    new Recipe
                    {
                        RecipeName = "Pasta",
                        Ingredients = "Pasta and Ground Beef",
                        Instructions = "Cook pasta, add Ground Beef",
                        TimeToPrepare = 25
                    },
                    new Recipe
                    {
                        RecipeName = "Lasagna",
                        Ingredients = "Ham and Cheese",
                        Instructions = "Mount layers of Ham and Cheese",
                        TimeToPrepare = 45
                    },
                    new Recipe
                    {
                        RecipeName = "Mac and Cheese",
                        Ingredients = "Pasta and Cheese",
                        Instructions = "Cook pasta, add cheese",
                        TimeToPrepare = 20
                    },
                    new Recipe
                    {
                        RecipeName = "Pizza",
                        Ingredients = "Peperoni and Cheese",
                        Instructions = "Mount pizza, bake in oven",
                        TimeToPrepare = 30
                    },
                    new Recipe
                    {
                        RecipeName = "Beef Burrito",
                        Ingredients = "Ground Beef, Cheese and Tortilla",
                        Instructions = "Cook ground beef with cheese, roll into tortilla",
                        TimeToPrepare = 30
                    },
                    new Recipe
                    {
                        RecipeName = "Chicken Teriyaki",
                        Ingredients = "Chicken breast and Teriyaki sauce",
                        Instructions = "Cook chicken breast and finish with sauce",
                        TimeToPrepare = 25
                    }
                ) ;
                if (!context.Reviews.Any())
                {
                    new Review
                    {
                        RecipeId = 1,
                        Rating = 5,
                        Description = "Great"
                    };
                }
                    context.SaveChanges();
            }
        }
    }
}
