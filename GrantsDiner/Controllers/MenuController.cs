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
    public class MenuController : ControllerBase
    {
        private IDAL dal;

        public MenuController(IDAL dal)
        {
            this.dal = dal;
        }

        //get: all the menu items (api/menu)
        [HttpGet] //api/menu
        public IEnumerable<MenuItem> Get()
        {
            return dal.GetMenuItems();
        }

        //getDetail: All the info on one menu item
        [HttpGet("{id}")] // /api/1
        public MenuItem GetDetail(int id)
        {
            return dal.GetMenuItemDetail(id);
        }

        //getCategories: Just returns the category names (DISTINCT)
        [HttpGet("categories")] // /api/menu/categories
        public IEnumerable<string> GetCategories()
        {
            return dal.GetMenuCategories();
        }

        //getByCategory: All the info on the menu items within the given category
        [HttpGet("categories/{cat}")] //  /api/menu/categories/entrees
        public IEnumerable<MenuItem> GetByCategory(string cat)
        {
            return dal.GetMenuItemsByCategory(cat);
        }
    }
}