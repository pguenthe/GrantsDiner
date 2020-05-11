using System;
using System.Collections.Generic;
using System.Data;
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
    public class CartController : ControllerBase
    {
        private string connString;

        public CartController(IConfiguration config)
        {
            connString = config.GetConnectionString("default");
        }

        //get: all this user's cart items (api/cart)
        [HttpGet("{id}")] //api/menu
        public IEnumerable<JoinedItem> Get(int id)
        {
            SqlConnection conn = new SqlConnection(connString);
            //string command = "SELECT * FROM ShoppingCart WHERE UserID=@id";
            //todo: stored procedure for below
            string command = "SELECT s.ID, s.ItemID, s.UserID, s.Quantity, ";
            command += "m.Name, m.Category, m.Description, m.Price ";
            command += "FROM ShoppingCart s INNER JOIN MenuItems m";
            command += " ON s.ItemID = m.ID WHERE s.UserID=@id";

            IEnumerable<JoinedItem> result = conn.Query<JoinedItem>(command,
                new { id = id });

            conn.Close();

            return result;
        }

        //post (to add an item to the cart)
        [HttpPost]
        public Object AddToCart(ShoppingCart cartItem)
        {
            SqlConnection conn = new SqlConnection(connString);
            string command = "INSERT INTO ShoppingCart (ItemID, UserID, Quantity) ";
            command += "VALUES (@itemID, @userID, @quantity)";

            int result = conn.Execute(command, new
            {
                itemID = cartItem.ItemID,
                userID = cartItem.UserID,
                quantity = 1
            });

            conn.Close();

            //TODO: Return success or error code
            return new
            {
                result = result,
                success = result == 1 ? true : false
            };
        }

        //getByUserID

        //delete (to remove an item from the cart)
        [HttpDelete("{id}")]
        public Object Delete(int id)
        {
            SqlConnection conn = new SqlConnection(connString);
            string command = "DELETE FROM ShoppingCart WHERE ID=@id";

            int result = conn.Execute(command, new { id = id });

            conn.Close();

            //TODO: Return success or error code
            return new
            {
                result = result,
                success = result == 1 ? true : false
            };
        }

        //put/patch (to change quantities)

    }
}