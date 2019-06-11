using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ResisipeApp.Models
{
    public class RecipeContext: DbContext
    {
        public DbSet<Recipe> Recipe { get; set; }
    }
}