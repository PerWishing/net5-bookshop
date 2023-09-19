using BookShop.Database;
using BookShop.Domain.Enums;
using BookShop.Domain.Infrastructure;
using BookShop.Domain.Models;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Application.Orders
{
    [Service]
    public class CreateOrder
    {
        private IOrderManager _orderManager;
        IDataProtector _protector;
        public CreateOrder(IOrderManager orderManager, IDataProtectionProvider provider)
        {
            _orderManager = orderManager;
            _protector = provider.CreateProtector("Order");
        }

        public class Request 
        {
            public string CustomerName { get; set; }

            public string SellerName { get; set; }
            public int ProductId { get; set; }

            public string StripeReference { get; set; }// у меня нет stripe
            public string SessionId { get; set; }

            public string FIO { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }

            public string Adress1 { get; set; }
            public string Adress2 { get; set; }
            public string City { get; set; }
            public string PostCode { get; set; }

            
        }

        public class Stock 
        {
            public int StockId { get; set; }
            public int Qty { get; set; }
        }

        public async Task<bool> Do(Request request)
        {
            var order = new Order
            {
                OrderRef = CreateOrderReference(),
                
                CustomerName = request.CustomerName,

                SellerName = request.SellerName,
                ProductId = request.ProductId,
                Email = request.Email,
                FIO = _protector.Protect(request.FIO),
                PhoneNumber = _protector.Protect(request.PhoneNumber),
                Adress = _protector.Protect(request.Adress1),
                City = _protector.Protect(request.City),
                PostCode = _protector.Protect(request.PostCode),

                StatusForCustomer = 0,
                StatusForSeller = 0,
                TrackNumber = _protector.Protect("0")
            };

            var succes = await _orderManager.CreateOrder(order) > 0;
            if (succes)
            {
                return true;
            }
            return false;
        }

        public string CreateOrderReference()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var result = new char[12];
            var random = new Random();

            do
            {
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = chars[random.Next(chars.Length)];
                }
            } while (_orderManager.OrderReferenceExists(new string(result)));
            return new string(result);
        }
    }
}
