using BookShop.Domain.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace BookShop.Application.OrdersAdmin
{
    [Service]
    public class GetOrder
    {
        private readonly IOrderManager _orderManager;

        public GetOrder(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }
        public class Response
        {
            public int Id { get; set; }
            public string OrderRef { get; set; }

            public string FIO { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }

            public string Adress1 { get; set; }
            public string City { get; set; }
            public string PostCode { get; set; }

            public IEnumerable<Product> Products { get; set; }
        }

        public class Product
        {
            public string Name{ get; set; }
            public string Description{ get; set; }
            public int Qty{ get; set; }
            public string StockDescription { get; set; }
        }

        public Response Do(int id) =>
            _orderManager.GetOrderById(id, x => new Response
            {
                Id = x.Id,
                OrderRef = x.OrderRef,

                FIO = x.FIO,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                Adress1 = x.Adress,
                City = x.City,
                PostCode = x.PostCode,
            });
           
    }
}
