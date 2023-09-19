using BookShop.Database;
using BookShop.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Application.ProductsUser
{
    [Service]
    public class GetProducts
    {
        private IProductManager _productManager;

        public GetProducts(IProductManager productManager)
        {
            _productManager = productManager;
        }

        public IEnumerable<ProductViewModel> Do(string seller) =>
            _productManager.GetProductsBySeller(seller, x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Value = x.Value.GetValueString(),
                Description = x.Description,
                Seller = x.Seller,
                Available = x.Available,
                Image = x.Image,
                Author = x.Author
            });
        
        public class ProductViewModel
        {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public string Seller { get; set; }
        public string Author { get; set; }
        public int Available { get; set; }
        public byte[] Image { get; set; }

        }
    }
}
