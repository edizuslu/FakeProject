using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResisipeApp.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public string RecipeDetail { get; set; }
        public string RecipeTags { get; set; }
        public string RecipeIngredients { get; set; }
    }
}