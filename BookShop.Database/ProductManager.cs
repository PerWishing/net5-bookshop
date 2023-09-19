using BookShop.Domain.Enums;
using BookShop.Domain.Infrastructure;
using BookShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Korzh.EasyQuery.Linq;

namespace BookShop.Database
{
    public class ProductManager : IProductManager
    {
        private ApplicationDbContext _ctx;

        public ProductManager(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public Task<int> CreateProduct(Product product)
        {
            _ctx.Products.Add(product);

            return _ctx.SaveChangesAsync();
        }

        public Task<int> DeleteProduct(int id)
        {
            var product = _ctx.Products.FirstOrDefault(x => x.Id == id);
            _ctx.Remove(product);
            return _ctx.SaveChangesAsync();
        }
        public Task<int> UpdateProduct(Product product)
        {
            _ctx.Products.Update(product);
            return _ctx.SaveChangesAsync();
        }

        public TResult GetProductById<TResult>(int id, Func<Product, TResult> selector)
        {
            return _ctx.Products
                .Include(x => x.Stock)
                .Where(x => x.Id == id)
                .Select(selector)
                .FirstOrDefault();
        }

        public TResult GetProductByName<TResult>(string name, Func<Product, TResult> selector)
        {
            return _ctx.Products
                .Include(x => x.Stock)
                .Where(x => x.Name == name)
                .Select(selector)
                .FirstOrDefault();
        }

        public IEnumerable<TResult> GetProductsBySeller<TResult>(string seller, Func<Product, TResult> selector)
        {
            return _ctx.Products
            .Include(x => x.Stock)
            .Where(x => x.Seller == seller)
            .Select(selector).ToList();
        }

        public IEnumerable<TResult> GetProductsBySearch<TResult>(string search, Func<Product, TResult> selector)
        {
            return _ctx.Products
            .Include(x => x.Stock)
            .FullTextSearchQuery(search)
            .Select(selector).ToList();
        }

        public IEnumerable<Product> GetProductFromFav(string username)
        {
             var favProd = _ctx.FavoritesProducts
                 .Include(x => x.Product)
                 .Where(x => x.ApplicationUser.UserName == username)
                 .ToList();

            List<Product> products = new List<Product>();
            
                foreach (var fp in favProd)
                {
                    products.Add(fp.Product);
                }
            
                return products;
            
        }

        public IEnumerable<TResult> GetProductsWithStock<TResult>(Func<Product, TResult> selector)
        {
            return _ctx.Products
             .Where(product => product.Available == 0)
            .Include(x => x.Stock)
            .Select(selector).ToList();
        }

        public IEnumerable<TResult> GetProductsByGenre<TResult>(Genres genre,Func<Product, TResult> selector)
        {
            return _ctx.Products
             .Where(product => product.Available == 0 && product.Genre == genre)
            .Include(x => x.Stock)
            .Select(selector).ToList();
        }

    }
}
