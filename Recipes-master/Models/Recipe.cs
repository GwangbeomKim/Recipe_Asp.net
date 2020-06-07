using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Models
{
    public class Recipe
    {
        //Recipe properties
        [Key]
        public int RecipeId { get; set; }
        [Required(ErrorMessage ="Please enter a recipe name")]
        public String RecipeName { get; set; }
        [Required(ErrorMessage = "Please enter the time to prepare")]
        public int? TimeToPrepare { get; set; }
        [Required(ErrorMessage = "Please enter ingredients for the recipe")]
        public String Ingredients { get; set; }
        [Required(ErrorMessage = "Please enter instructions for the recipe")]
        public String Instructions { get; set; }
    }
}
