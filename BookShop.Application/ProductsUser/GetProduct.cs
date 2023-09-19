using BookShop.Domain.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace BookShop.Application.ProductsUser
{
    [Service]
    public class GetProduct
    {
        private IProductManager _productManager;

        public GetProduct(IProductManager productManager)
        {
            _productManager = productManager;
        }

        public ProductViewModel Do(int id) {
            
            var product = _productManager.GetProductById(id, x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Value = x.Value,
                Image = x.Image
            });

            return product;
        }

        public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public byte[] Image { get; set; }
    }
    }
}
