using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrantsDiner.Models;
using GrantsDiner.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrantsDiner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private IDAL dal;

        public CartController(IDAL dal)
        {
            this.dal = dal;
        }

        //get: all this user's cart items (api/cart)
        [HttpGet("{id}")] //api/menu
        public IEnumerable<JoinedItem> Get(int id)
        {
            return dal.GetCart(id);
        }

        //post (to add an item to the cart)
        [HttpPost]
        public Object AddToCart(ShoppingCart cartItem)
        {
            IEnumerable<JoinedItem> cart = dal.GetCart(cartItem.UserID);

            int result = 0;

            foreach (JoinedItem item in cart)
            {
                //check if the same item is already in cart
                if (item.ItemID == cartItem.ItemID)
                {
                    result = dal.UpdateInCart(
                        new ShoppingCart {
                            ID = item.ID,
                            ItemID = item.ItemID,
                            UserID = item.UserID,
                            Quantity = item.Quantity + 1
                        });

                    return result;
                }
            }

            result = dal.AddToCart(cartItem);

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
            int result = dal.DeleteFromCart(id);

            //TODO: Return success or error code
            return new
            {
                result = result,
                success = result == 1 ? true : false
            };
        }

        //put/patch (to change quantities)
        [HttpPut]
        public Object Put (ShoppingCart item)
        {
            if (item.Quantity == 0)
            {
                return Delete(item.ID);
            }

            int result = dal.UpdateInCart(item);

            //TODO: Return success or error code
            return new
            {
                result = result,
                success = result == 1 ? true : false
            };
        }
    }
}