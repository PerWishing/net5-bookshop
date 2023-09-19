using BookShop.Database;
using BookShop.Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BookShop.Application.Cart
{
    [Service]
    public class GetOrder
    {
        private ISessionManager _sessionManager;

        public GetOrder(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        public class Response
        {
            public IEnumerable<Product> Products { get; set; }
            public CustomerInformation CustomerInformation { get; set; }

            public int GetTotalCharge() => Products.Sum(x => x.Value * x.Qty);
        }

        public class Product
        {
            public int ProductId { get; set; }
            public int StockId { get; set; }
            public int Qty { get; set; }
            public int Value { get; set; }
        }

        public class CustomerInformation
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }

            public string Adress1 { get; set; }
            public string Adress2 { get; set; }
            public string City { get; set; }
            public string PostCode { get; set; }
        }

        public Response Do()
        {
            var listOfProducts = _sessionManager.GetCart(x => new Product
            {
                ProductId = x.ProductId,
                StockId = x.StockId,
                Value = (int)x.Value,
                Qty = x.Qty
            });


            var customerInformation = _sessionManager.GetCustomerInformation();

            return new Response 
            {
                Products = listOfProducts,
                CustomerInformation = new CustomerInformation
                {
                    //FirstName = customerInformation.FIO,
                    //LastName = customerInformation.LastName,
                    //Email = customerInformation.Email,
                    //PhoneNumber = customerInformation.PhoneNumber,
                    //Adress1 = customerInformation.Adress1,
                    //Adress2 = customerInformation.Adress2,
                    //City = customerInformation.City,
                    //PostCode = customerInformation.PostCode
                }
            };
            //var stringObject = _session.GetString("cart");
            //if (string.IsNullOrEmpty(stringObject))
            //{
            //    return new List<Response>();
            //}
            //var cartList = JsonConvert.DeserializeObject<List<CartProduct>>(stringObject);

            //var response = _ctx.Stock
            //    .Include(x => x.Product).AsEnumerable()
            //    .Where(x => cartList.Any(y => y.StockId == x.Id))
            //    .Select(x => new Response
            //    {
            //        Name = x.Product.Name,
            //        Value = $"Р {x.Product.Value.ToString("N2")}",
            //        StockId = x.Id,
            //        Qty = cartList.FirstOrDefault(y => y.StockId == x.Id).Qty
            //    })
            //    .ToList();


        }
    }
}
