using BookShop.Application.Orders;
using BookShop.Application.OrdersAdmin;
using BookShop.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.UI.Controllers
{
    [Route("[controller]")]
    [Authorize(Policy = "Manager")]
    public class OrdersController : Controller
    {
        //[HttpGet("")]
        //public IActionResult GetOrders(
        //    int status,
        //    [FromServices] GetOrders getOrders) => Ok(getOrders.Do());

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id,
            [FromServices] Application.Orders.GetOrder getOrder) => Ok(getOrder.Do(id));

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateOrder(int id,
        //    [FromServices] UpdateOrder updateOrder) => Ok(await updateOrder.DoAsync(id));


    }
}
