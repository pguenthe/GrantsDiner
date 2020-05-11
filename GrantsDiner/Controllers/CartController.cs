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
    public class CartController : ControllerBase
    {
        private string connString;

        public CartController(IConfiguration config)
        {
            connString = config.GetConnectionString("default");
        }

        //get: all the menu items (api/menu)
        [HttpGet] //api/menu
        public IEnumerable<ShoppingCart> Get()
        {
            SqlConnection conn = new SqlConnection(connString);
            string command = "SELECT * FROM ShoppingCart INNER JOIN MenuItems";
            command += " ON ShoppingCart.ItemID = MenuItems.ID";

            IEnumerable<ShoppingCart> result = conn.Query<ShoppingCart>(command);

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

            return new
            {
                result = result,
                success = result == 1 ? true : false
            };
        }

        //getByUserID

        //delete (to remove an item from the cart)

        //put/patch (to change quantities)

    }
}