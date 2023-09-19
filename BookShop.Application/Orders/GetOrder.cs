using BookShop.Database;
using BookShop.Domain.Enums;
using BookShop.Domain.Infrastructure;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Application.Orders
{
    [Service]
    public class GetOrder
    {
        private readonly IOrderManager _orderManager;
        private readonly IProductManager _productManager;
        private readonly IUserManager _userManager;
        IDataProtector _protector;

        public GetOrder(IOrderManager orderManager, IProductManager productManager, IUserManager userManager, IDataProtectionProvider provider)
        {
            _orderManager = orderManager;
            _productManager = productManager;
            _userManager = userManager;
            _protector = provider.CreateProtector("Order");
        }

        public class Response
        {
            public int Id { get; set; }

            public string OrderRef { get; set; }

            public string Seller { get; set; }
            public string Customer { get; set; }


            public string FIO { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }

            public string Adress1 { get; set; }
            public string Adress2 { get; set; }
            public string City { get; set; }
            public string PostCode { get; set; }

            public int ProductId { get; set; }
            public Product Product { get; set; }
            public OrderStatusForSeller StatusForSeller { get; set; }
            public OrderStatusForCustomer StatusForCustomer { get; set; }

            public string TrackNumber { get; set; }

            public OrderStatusOpenOrClosed StatusOpenOrClosed { get; set; }

            public string CommentOfCancel { get; set; }

            public DateTime DateOfClosing { get; set; }

            public byte[] SellerImage { get; set; }
        }

        public class Product
        {

            public int Id { get; set; }
            public string Name { get; set; }
            public string Value { get; set; }
            public string Description { get; set; }
            public string Seller { get; set; }
            public int Available { get; set; }
            public string Genre { get; set; }
            public string Author { get; set; }
            public string ISBN { get; set; }
            public string Publishing { get; set; }
            public int Year { get; set; }
            public string Series { get; set; }

            public byte[] Image { get; set; }


        }

        public Response Do(int id)
        {
            var response = _orderManager.GetOrderById(id, x => new Response
            {
                Id = x.Id,
                
                OrderRef = x.OrderRef,

                Seller = x.SellerName,
                Customer = x.CustomerName,
                ProductId = x.ProductId,
                

                Email = x.Email,
                FIO = _protector.Unprotect(x.FIO),
                PhoneNumber = _protector.Unprotect(x.PhoneNumber),
                Adress1 = _protector.Unprotect(x.Adress),
                City = _protector.Unprotect(x.City),
                PostCode = _protector.Unprotect(x.PostCode),

                StatusForCustomer = x.StatusForCustomer,
                StatusForSeller = x.StatusForSeller,

                TrackNumber = _protector.Unprotect(x.TrackNumber),

                CommentOfCancel = x.CommentOfCancel,
                StatusOpenOrClosed = x.StatusOpenOrClosed,
                DateOfClosing = x.DateOfClosingOrder,
                SellerImage = x.SellerImage
            });

            response.Product = _productManager.GetProductById(response.ProductId, x => new Product
            {
                
                Name = x.Name,
                Description = x.Description,
                Value = x.Value.GetValueString(),
                Image = x.Image,
                Author = x.Author,
                Genre = x.Genre.GetAttributeOfType<DescriptionAttribute>().Description,
                ISBN = x.ISBN,
                Publishing = x.Publishing,
                Series = x.Series,
                Year = x.Year
            });

            

            if (response.TrackNumber == null)
            {
                response.TrackNumber = "0";
            }

            return response;
        }
    }
}
