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
            int result = dal.AddToCart(cartItem);

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

    }
}