using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recipes.Models;
using Recipes.Models.ViewModels;

namespace Recipes.Controllers
{
    public class RecipesController : Controller
    {
        private IRecipeRepository Repository;
        public int PageSize = 5;
        public RecipesController (IRecipeRepository repo)
        {
            Repository = repo;
        }
        public ViewResult Home()
        {
            return View();
        }
        [HttpGet]
        public ViewResult AddRecipe()
        {
            return View();
        }
        [HttpGet]
        public ViewResult List(int recipePageNumber = 1)
            => View(new RecipeListViewModel
            {
                Recipes = Repository.Recipes.OrderBy(r => r.RecipeId).Skip((recipePageNumber - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = recipePageNumber,
                    ItemsPerPage = PageSize,
                    TotalItems = Repository.Recipes.Count()
                }
            });


        [HttpGet]
        public ViewResult ViewRecipe(int RecipeId)
        {
            return View(Repository.Recipes
                .Where(r => r.RecipeId == RecipeId));
        }
        [HttpGet]
        public ViewResult AddReview(int RecipeId)
        {
            if (RecipeId != null)
            {
                return View("AddReview", new Review());
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult AddReview(Review review)
        {
            Repository.SaveReview(review);
            return RedirectToAction("ReadReview", new { review.RecipeId });
        }
        [HttpGet]
        public ViewResult ReadReview(int RecipeId) {
            return View(new RecipeReviewsViewModel{
                Recipe = Repository.Recipes.FirstOrDefault(r => r.RecipeId == RecipeId), 
                Reviews = Repository.Reviews.Where(r => r.RecipeId == RecipeId) }
                );
        }
    }
}
