using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Database;
using BookShop.Domain.Infrastructure;
using BookShop.Domain.Models;

namespace BookShop.Application.ProductsAdmin
{
    [Service]
    public class UpdateProduct
    {
        private IProductManager _productManager;

        public UpdateProduct(IProductManager productManager)
        {
            _productManager = productManager;
        }
    

        public async Task<Response> Do(Request request)
        {
            var product = _productManager.GetProductById(request.Id, x=>x);
            
            product.Name = request.Name;
            product.Description = request.Description;
            product.Value = request.Value;

            await _productManager.UpdateProduct(product);

            return new Response()
            {
                Id = product.Id,
                Name = product.Name,
                Description= product.Description,
                Value = product.Value
            };
        }

        public class Request
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }
        }
        public class Response
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }
        }
    }
    
}
