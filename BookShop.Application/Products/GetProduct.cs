using BookShop.Domain.Enums;
using BookShop.Domain.Infrastructure;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Application.Products
{
    [Service]
    public class GetProduct
    {
        private readonly IStockManager _stockManager;
        private readonly IProductManager _productManager;

        public GetProduct(IStockManager stockManager, IProductManager productManager)
        {
            _stockManager = stockManager;
            _productManager = productManager;
        }

        public async Task<ProductViewModel> Do(int id) 
        {
            await _stockManager.RetrieveExpiredStockOnHold();

            return _productManager.GetProductById(id, x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Value = x.Value.GetValueString(),
                Seller = x.Seller,
                Author = x.Author,
                Genre = x.Genre.GetAttributeOfType<DescriptionAttribute>().Description,
                Publishing = x.Publishing,
                Series = x.Series,
                Year = x.Year,
                ISBN = x.ISBN,

                Available = x.Available,

                Image = x.Image,

                Stock = x.Stock.Select(y => new StockViewModel
                {
                    Id = y.Id,
                    Description = y.Description,
                    Qty = y.Qty
                })
            }); 
        }

        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Value { get; set; }
            public string Description { get; set; }
            public string Seller { get; set; }
            public IEnumerable<StockViewModel> Stock { get; set; }
            public int Available { get; set; }

            public string Genre { get; set; }
            public string Author { get; set; }
            public string ISBN { get; set; }
            public string Publishing { get; set; }
            public int Year { get; set; }
            public string Series { get; set; }


            public byte[] Image { get; set; }
        }

        public class StockViewModel
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public int Qty { get; set; }
        }
    }
}
