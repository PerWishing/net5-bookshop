using BookShop.Domain.Enums;
using BookShop.Application;
using BookShop.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Application.Products
{
    [Service]
    public class GetProducts
    {
        private IProductManager _productManager;

        public GetProducts(IProductManager productManager)
        {
            _productManager = productManager;
        }

        public IndexViewModel GetAll(int page) {
            var productVM = _productManager.GetProductsWithStock(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Value = x.Value.GetValueString(),
                Seller = x.Seller,
                Image = x.Image,
                Author = x.Author
            }).AsQueryable();

            int pageSize = 8;

            var count = productVM.Count();
            var items = productVM.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Products = items.AsQueryable()
            };

            return viewModel;
        }

        public IndexViewModel GetBySearch(int page, string search)
        {
            var productVM = _productManager.GetProductsBySearch(search ,x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Value = x.Value.GetValueString(),
                Seller = x.Seller,
                Image = x.Image,
                Author = x.Author
            }).AsQueryable();

            int pageSize = 8;

            var count = productVM.Count();
            var items = productVM.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Products = items.AsQueryable()
            };

            return viewModel;
        }


        public IndexViewModel GetByGenre(int page, string genre)
        {
            Enum.TryParse(genre, out Genres g);
            var productVM = _productManager.GetProductsByGenre(g, x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Value = x.Value.GetValueString(),
                Seller = x.Seller,
                Image = x.Image,
                Author = x.Author
            });
            int pageSize = 8;

            var count = productVM.Count();
            var items = productVM.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Products = items.AsQueryable()
            };

            return viewModel;
        }

        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Value { get; set; }
            public string Seller { get; set; }
            public string Author { get; set; }
            public byte[] Image { get; set; }

        }

        public class IndexViewModel
        {
            public IQueryable<ProductViewModel> Products { get; set; }
            public PageViewModel PageViewModel { get; set; }
            public string Text { get; set; }
        }
    }
}
