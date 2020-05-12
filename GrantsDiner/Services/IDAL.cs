using GrantsDiner.Models;
using System.Collections.Generic;

namespace GrantsDiner.Services
{
    public interface IDAL
    {
        IEnumerable<string> GetMenuCategories();
        MenuItem GetMenuItemDetail(int id);
        IEnumerable<MenuItem> GetMenuItems();
        IEnumerable<MenuItem> GetMenuItemsByCategory(string cat);
        IEnumerable<JoinedItem> GetCart(int id);
        int AddToCart(ShoppingCart cartItem);
        int DeleteFromCart(int id);
        int UpdateInCart(ShoppingCart item);
    }
}