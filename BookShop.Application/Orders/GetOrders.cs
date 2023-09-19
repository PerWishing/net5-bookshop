using BookShop.Domain.Enums;
using BookShop.Domain.Infrastructure;
using System.Collections.Generic;

namespace BookShop.Application.Orders
{
    [Service]
    public class GetOrders
    {
        private readonly IOrderManager _orderManager;
        private readonly IProductManager _productManager;

        public GetOrders(IOrderManager orderManager, IProductManager productManager)
        {
            _orderManager = orderManager;
            _productManager = productManager;
        }

        public class Response
        {
            public int Id { get; set; }
            public string OrderRef { get; set; }

            public string Seller { get; set; }
            public string Customer { get; set; }
           

            public int ProductId { get; set; }
            public Product Product { get; set; }

            public OrderStatusForSeller StatusForSeller { get; set; }
            public OrderStatusForCustomer StatusForCustomer { get; set; }

        }
        public class Product
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Value { get; set; }
            public string Author { get; set; }

            public byte[] Image { get; set; }

            public int Available { get; set; }
        }

        public IEnumerable<Response> GetBySeller(string seller)
        {
            var response =  _orderManager.GetOrdersBySeller(seller,x => new Response() {
                Id = x.Id,
                OrderRef = x.OrderRef,

                Seller = x.SellerName,
                Customer = x.CustomerName,
                ProductId = x.ProductId,

                StatusForCustomer = x.StatusForCustomer,
                StatusForSeller = x.StatusForSeller

            });
            foreach(var r in response)
            {
                r.Product = _productManager.GetProductById(r.ProductId, x => new Product
                {
                    Name = x.Name,
                    Description = x.Description,
                    Value = x.Value.GetValueString(),
                    Available = x.Available,
                    Image = x.Image,
                    Author = x.Author
                });
            }
            return response;
        }

        public IEnumerable<Response> GetBySellerClosed(string seller)
        {
            var response = _orderManager.GetOrdersBySellerClosed(seller, x => new Response()
            {
                Id = x.Id,
                OrderRef = x.OrderRef,

                Seller = x.SellerName,
                Customer = x.CustomerName,
                ProductId = x.ProductId,

                StatusForCustomer = x.StatusForCustomer,
                StatusForSeller = x.StatusForSeller
            });
            foreach (var r in response)
            {
                r.Product = _productManager.GetProductById(r.ProductId, x => new Product
                {
                    Name = x.Name,
                    Description = x.Description,
                    Value = x.Value.GetValueString(),
                    Image = x.Image,
                    Author = x.Author,
                    Available = x.Available
                });
            }
            return response;
        }

        public IEnumerable<Response> GetByCustomer(string customer)
        {
            var response = _orderManager.GetOrdersByCustomer(customer, x => new Response()
            {
                Id = x.Id,
                OrderRef = x.OrderRef,

                Seller = x.SellerName,
                Customer = x.CustomerName,
                ProductId = x.ProductId,

                StatusForCustomer = x.StatusForCustomer,
                StatusForSeller = x.StatusForSeller
            });
            foreach (var r in response)
            {
                r.Product = _productManager.GetProductById(r.ProductId, x => new Product
                {

                    Name = x.Name,
                    Description = x.Description,
                    Value = x.Value.GetValueString(),
                    Image = x.Image,
                    Author = x.Author,
                    Available = x.Available
                });
            }
            return response;
        }

        public IEnumerable<Response> GetByCustomerClosed(string customer)
        {
            var response = _orderManager.GetOrdersByCustomerClosed(customer, x => new Response()
            {
                Id = x.Id,
                OrderRef = x.OrderRef,

                Seller = x.SellerName,
                Customer = x.CustomerName,
                ProductId = x.ProductId,

                StatusForCustomer = x.StatusForCustomer,
                StatusForSeller = x.StatusForSeller
            });
            foreach (var r in response)
            {
                r.Product = _productManager.GetProductById(r.ProductId, x => new Product
                {

                    Name = x.Name,
                    Description = x.Description,
                    Value = x.Value.GetValueString(),
                    Image = x.Image,
                    Author = x.Author,
                    Available = x.Available
                });
            }
            return response;
        }
    }
}
