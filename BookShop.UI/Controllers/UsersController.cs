using BookShop.Application;
using BookShop.Application.ProductsAdmin;
using BookShop.Application.StockAdmin;
using BookShop.Application.Users;
using BookShop.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.UI.Controllers
{
    [Route("[controller]")]
    //[Authorize(Policy = "Manager")]
    public class UsersController : Controller
    {
        int page;

        public UsersController()
        {
            page = 1;
        }
        [HttpGet("")]
        public IActionResult GetPubUsers([FromServices] GetPublicUsers getPublicUsers) => Ok(getPublicUsers.GetPubUsers(page));
        
        [HttpGet("{p}")]
        public IActionResult GetPubUsersByPage(int p, [FromServices] GetPublicUsers getPublicUsers) => Ok(getPublicUsers.GetPubUsers(p));
        [HttpGet("{p}/{search}")]
        public IActionResult GetPubUsersBySearch(int p, string search, [FromServices] GetPublicUsers getPublicUsers) => Ok(getPublicUsers.GetPubUsersBySearch(p, search));

        [HttpGet("{name}/{a}/{b}")]
        public IActionResult GetPubUser(string name, [FromServices] GetUserPublic getUserPublic)
        {

            var result = getUserPublic.GetPublicUser(name);
            return Ok(result);
        }

    }
}

