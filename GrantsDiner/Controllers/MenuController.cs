using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using GrantsDiner.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GrantsDiner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private string connString;

        public MenuController(IConfiguration config)
        {
            connString = config.GetConnectionString("default");
        }

        //get: all the menu items (api/menu)
        [HttpGet] //api/menu
        public IEnumerable<MenuItem> Get()
        {
            SqlConnection conn = new SqlConnection(connString);
            string command = "SELECT * FROM MenuItems";

            IEnumerable<MenuItem> result = conn.Query<MenuItem>(command);

            conn.Close();

            return result;
        }

        //getDetail: All the info on one menu item
        [HttpGet("{id}")] // /api/1
        public MenuItem GetDetail(int id)
        {
            SqlConnection conn = new SqlConnection(connString);
            string command = "SELECT * FROM MenuItems WHERE ID=@id";

            MenuItem result = conn.QueryFirst<MenuItem>(command, new { id = id });

            conn.Close();

            return result;
        }

        //getCategories: Just returns the category names (DISTINCT)
        [HttpGet("categories")] // /api/menu/categories
        public IEnumerable<string> GetCategories()
        {
            SqlConnection conn = new SqlConnection(connString);
            string command = "SELECT DISTINCT Category FROM MenuItems";

            IEnumerable<string> result = conn.Query<string>(command);

            conn.Close();

            return result;
        }

        //getByCategory: All the info on the menu items within the given category
        [HttpGet("categories/{cat}")] //  /api/menu/categories/entrees
        public IEnumerable<MenuItem> GetByCategory(string cat)
        {
            SqlConnection conn = new SqlConnection(connString);
            string command = "SELECT * FROM MenuItems WHERE Category=@category";

            IEnumerable<MenuItem> result = conn.Query<MenuItem>(command,
                new { category = cat });

            conn.Close();

            return result;
        }
    }
}