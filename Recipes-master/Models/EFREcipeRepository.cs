using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Models
{
    public class EFRecipeRepository:IRecipeRepository
    {
        private ApplicationDbContext context;
        public EFRecipeRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Recipe> Recipes => context.Recipes;
        public IQueryable<Review> Reviews => context.Reviews;

        public Recipe DeleteRecipe(int recipeId)
        {
            Recipe recipeEntry = context.Recipes.FirstOrDefault(r => r.RecipeId == recipeId);
            if(recipeEntry != null)
            {
                context.Recipes.Remove(recipeEntry);
                context.SaveChanges();
            }
            return recipeEntry;
        }

        public void SaveRecipe(Recipe recipe)
        {
            if(recipe.RecipeId == 0)
            {
                context.Recipes.Add(recipe);
            }
            else
            {
                Recipe recipeEntry = context.Recipes.FirstOrDefault(r => r.RecipeId == recipe.RecipeId);
                if(recipeEntry != null)
                {
                    recipeEntry.RecipeName = recipe.RecipeName;
                    recipeEntry.Ingredients = recipe.Ingredients;
                    recipeEntry.Instructions = recipe.Instructions;
                    recipeEntry.TimeToPrepare = recipe.TimeToPrepare;
                }
            }
            context.SaveChanges();
        }
        public void SaveReview(Review review)
        {
            if (review.ReviewId == 0)
            {
                context.Reviews.Add(review);
            }
            context.SaveChanges();
        }
    }
}
