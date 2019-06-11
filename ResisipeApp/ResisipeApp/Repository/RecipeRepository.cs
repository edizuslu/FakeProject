using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using ResisipeApp.Models;

namespace ResisipeApp.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["mysql"].ConnectionString;


        public void Add(Recipe recipe)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand command = con.CreateCommand();

                con.Open();

                command.CommandText = "INSERT INTO recipe  VALUES (@RecipeId,@RecipeName,@RecipeDetail,@RecipeTags, @RecipeIngredients)";
                command.Parameters.AddWithValue("@RecipeId", recipe.RecipeId);
                command.Parameters.AddWithValue("@RecipeName", recipe.RecipeName);
                command.Parameters.AddWithValue("@RecipeDetail", recipe.RecipeDetail);
                command.Parameters.AddWithValue("@RecipeTags", recipe.RecipeTags);
                command.Parameters.AddWithValue("@RecipeIngredients", recipe.RecipeIngredients);

                command.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Delete(int Id)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                var command = con.CreateCommand();
                con.Open();

                command.CommandText = "DELETE FROM recipe WHERE RecipeId=@Id";
                command.Parameters.AddWithValue("@Id", Id);
                command.ExecuteNonQuery();
                con.Close();


                /*var cmd = new mysqlcommand("delete * from parttime where id=@id", con);
                con.open();
                mysqldatareader rdr = cmd.executereader();
                cmd.commandtype = commandtype.storedprocedure;
                cmd.parameters.addwithvalue("@id", id);
                cmd.parameters.add(new mysqlparameter("id", id));
                cmd.executenonquery();
                con.close();*/
            }
        }

        public Recipe Get(int Id)
        {
            Recipe recipe = new Recipe();

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM recipe WHERE RecipeId= " + Id;
                var cmd = new MySqlCommand("SELECT * FROM recipe WHERE RecipeId=@Id", con);
                cmd.Parameters.Add(new MySqlParameter("Id", Id));
                con.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    recipe.RecipeId = Convert.ToInt32(rdr["RecipeId"]);
                    recipe.RecipeName = rdr["RecipeName"].ToString();
                    recipe.RecipeDetail = rdr["RecipeDetail"].ToString();
                    recipe.RecipeTags = rdr["RecipeTags"].ToString();
                    recipe.RecipeIngredients = rdr["RecipeIngredients"].ToString();
                }
            }
            return recipe;
        }


        public IEnumerable<Recipe> GetAll()
        {
            var lstrecipe = new List<Recipe>();
            using (var con = new MySqlConnection(connectionString))
            {
                var cmd = new MySqlCommand("select * from recipe", con);
                con.Open();
                using (var reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        Recipe recipe = new Recipe();

                        recipe.RecipeId = Convert.ToInt32(reader["RecipeId"]);
                        recipe.RecipeName = reader["RecipeName"].ToString();
                        recipe.RecipeDetail = reader["RecipeDetail"].ToString();
                        recipe.RecipeTags = reader["RecipeTags"].ToString();
                        recipe.RecipeIngredients = reader["RecipeIngredients"].ToString();


                        lstrecipe.Add(recipe);
                    }
                }

                con.Close();

            }
            return lstrecipe;
        }



        public IEnumerable<Recipe> GetTag(string tags)
        {
            Recipe recipe = new Recipe();
            var lstrecipe = new List<Recipe>();

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM recipe WHERE RecipeTags LIKE " + tags;
                var cmd = new MySqlCommand("SELECT * FROM recipe WHERE RecipeTags LIKE @tags", con);
                cmd.Parameters.Add(new MySqlParameter("tags", tags));
                con.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    recipe.RecipeId = Convert.ToInt32(rdr["RecipeId"]);
                    recipe.RecipeName = rdr["RecipeName"].ToString();
                    recipe.RecipeDetail = rdr["RecipeDetail"].ToString();
                    recipe.RecipeTags = rdr["RecipeTags"].ToString();
                    recipe.RecipeIngredients = rdr["RecipeIngredients"].ToString();
                    lstrecipe.Add(recipe);
                }
            }
            return lstrecipe;
        }

        public void Update(Recipe recipe)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                //MySqlCommand cmd = new MySqlCommand("UPDATE 'parttime' SET (firstname=@firstname , lastname=@lastname, email=@email ,workfrom=@workfrom) WHERE id=@id", con);
                //cmd.CommandType = CommandType.StoredProcedure;

                MySqlCommand command = con.CreateCommand();
                var RecipeId = recipe.RecipeId;
                con.Open();

                command.CommandText = "UPDATE recipe SET RecipeName=@RecipeName, RecipeDetail=@RecipeDetail, RecipeTags=@RecipeTags ,RecipeIngredients=@RecipeIngredients WHERE RecipeId=@RecipeId";

                command.Parameters.AddWithValue("@RecipeId", recipe.RecipeId);
                command.Parameters.AddWithValue("@RecipeName", recipe.RecipeName);
                command.Parameters.AddWithValue("@RecipeDetail", recipe.RecipeDetail);
                command.Parameters.AddWithValue("@RecipeTags", recipe.RecipeTags);
                command.Parameters.AddWithValue("@RecipeIngredients", recipe.RecipeIngredients);

                command.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}