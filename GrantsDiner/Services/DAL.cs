using Dapper;
using GrantsDiner.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GrantsDiner.Services
{
    public class DAL : IDAL
    {
        private string connString;

        public DAL(IConfiguration config)
        {
            connString = config.GetConnectionString("default");
        }

        public IEnumerable<MenuItem> GetMenuItems()
        {
            SqlConnection conn = new SqlConnection(connString);
            string command = "SELECT * FROM MenuItems";

            IEnumerable<MenuItem> result = conn.Query<MenuItem>(command);

            conn.Close();

            return result;
        }

        public MenuItem GetMenuItemDetail(int id)
        {
            SqlConnection conn = new SqlConnection(connString);
            string command = "SELECT * FROM MenuItems WHERE ID=@id";

            MenuItem result = conn.QueryFirst<MenuItem>(command, new { id = id });

            conn.Close();

            return result;
        }

        public IEnumerable<string> GetMenuCategories()
        {
            SqlConnection conn = new SqlConnection(connString);
            string command = "SELECT DISTINCT Category FROM MenuItems";

            IEnumerable<string> result = conn.Query<string>(command);

            conn.Close();

            return result;
        }

        public IEnumerable<MenuItem> GetMenuItemsByCategory(string cat)
        {
            SqlConnection conn = new SqlConnection(connString);
            string command = "SELECT * FROM MenuItems WHERE Category=@category";

            IEnumerable<MenuItem> result = conn.Query<MenuItem>(command,
                new { category = cat });

            conn.Close();

            return result;
        }

        public IEnumerable<JoinedItem> GetCart(int id)
        {
            SqlConnection conn = new SqlConnection(connString);
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

        public int AddToCart(ShoppingCart cartItem)
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

            return result;
        }

        public int DeleteFromCart(int id)
        {
            SqlConnection conn = new SqlConnection(connString);
            string command = "DELETE FROM ShoppingCart WHERE ID=@id";

            int result = conn.Execute(command, new { id = id });

            conn.Close();

            return result;
        }

        public int UpdateInCart(ShoppingCart item)
        {
            SqlConnection conn = new SqlConnection(connString);
            string command = "UPDATE ShoppingCart ";
            command += "SET Quantity=@Quantity ";
            command += "WHERE ID=@ID";

            int result = conn.Execute(command, item);

            conn.Close();

            return result;
        }
    }
}
