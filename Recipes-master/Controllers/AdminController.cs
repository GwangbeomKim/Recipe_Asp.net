using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recipes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Controllers
{
    [Authorize]
    public class AdminController:Controller
    {
        private IRecipeRepository Repository;

        public AdminController(IRecipeRepository repo)
        {
            Repository = repo;
        }
        public ViewResult Index() => View(Repository.Recipes);
        public ViewResult Edit(int recipeId) => View(Repository.Recipes.FirstOrDefault(r => r.RecipeId == recipeId));
        [HttpPost]
        public IActionResult Edit(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                Repository.SaveRecipe(recipe);
                TempData["message"] = $"{recipe.RecipeName} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                return View(recipe);
            }
        }
        public ViewResult Create() => View("Edit",new Recipe());
        [HttpPost]
        public IActionResult Delete(int recipeId)
        {
            Recipe deleteRecipe = Repository.DeleteRecipe(recipeId);
            if(deleteRecipe != null)
            {
                TempData["message"] = $"{deleteRecipe.RecipeName} has been deleted";
            }
            return RedirectToAction("Index");
        }
    }
}
