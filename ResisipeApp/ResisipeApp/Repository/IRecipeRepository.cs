using ResisipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResisipeApp.Repository
{
    public interface IRecipeRepository
    {
        IEnumerable<Recipe> GetAll();
        Recipe Get(int Id);
        IEnumerable<Recipe> GetTag(string Id);
        void Add(Recipe recipe);
        void Delete(int Id);
        void Update(Recipe recipe);
    }
}