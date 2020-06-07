using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Models
{
    public interface IRecipeRepository
    {
        IQueryable<Recipe> Recipes { get; }
        IQueryable<Review> Reviews { get; }
        void SaveRecipe(Recipe recipe);
        Recipe DeleteRecipe(int recipeId);
        void SaveReview(Review review);
    }
}
