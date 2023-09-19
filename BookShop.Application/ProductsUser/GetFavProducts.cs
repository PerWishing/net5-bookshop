using BookShop.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Application.ProductsUser
{
    [Service]
    public class GetFavProducts
    {
        private IProductManager _productManager;

        public GetFavProducts(IProductManager productManager)
        {
            _productManager = productManager;
        }

        public class Request
        {
            public string Username { get; set; }
            public int ProductId { get; set; }
        }

         public IList<ProductViewModel> Do(string userId) 
         {
            var products = _productManager.GetProductFromFav(userId);
            IList<ProductViewModel> pvms = new List<ProductViewModel>();
            foreach (var p in products)
            {
                pvms.Add(new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Value = p.Value.GetValueString(),
                    Description = p.Description,
                    Seller = p.Seller,
                    Author = p.Author,
                    Image = p.Image
                });
            }
            return pvms;
         }
        

        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Value { get; set; }
            public string Description { get; set; }
            public string Seller { get; set; }
            public string Author { get; set; }
            public byte[] Image { get; set; }

        }
    }
}
