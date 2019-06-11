using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Owin;
using ResisipeApp.Models;
using ResisipeApp.Repository;

namespace ResisipeApp.Controllers
{

    [EnableCors("*", "*", "*")]
    public class RecipeController : ApiController
    {
        private IRecipeRepository repository = new RecipeRepository();
        Recipe mde = new Recipe();
        


        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var recipes = repository.GetAll();

            return Ok(recipes);
        }

        //get name by selecting id
        [HttpGet]
        public IHttpActionResult Get(int Id)
        {

            var recipe = repository.Get(Id);

            return Ok(recipe);
        }

        [AcceptVerbs("GET", "POST")]

        public IHttpActionResult Add([FromBody]Recipe recipe)
        {

            repository.Add(recipe);
            return Ok();
        }

        //Get action methods of the previous section
        [AcceptVerbs("GET", "POST")]

        public IHttpActionResult Update([FromBody]Recipe recipe)
        {
            repository.Update(recipe);
            return Ok();
        }

        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        [Route("api/Recipe/Delete/{id}")]
        public IHttpActionResult Delete(int Id)
        {

            repository.Delete(Id);
         
            return Ok();
        }

        //get name by selecting id
        [HttpGet]
        public IHttpActionResult GetTag(string Id)
        {

            var recipe = repository.GetTag(Id);
            return Ok(recipe);
        }

        [Route("getallandroid")]
        [HttpGet]
        public List<Recipe> getAllAndroid()
         {
            try
            {
                var recipes = repository.GetAll();
                List<Recipe> asList = recipes.ToList();

                return asList;
            }
            catch
            {
                return null;
            }
           
        }


    }

}