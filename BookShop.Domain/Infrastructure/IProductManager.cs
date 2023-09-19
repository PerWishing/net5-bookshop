using BookShop.Domain.Enums;
using BookShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Domain.Infrastructure
{
    public interface IProductManager
    {
        Task<int> CreateProduct(Product product);
        Task<int> DeleteProduct(int id);
        Task<int> UpdateProduct(Product product);

        TResult GetProductById<TResult>(int id, Func<Product, TResult> selector);
        TResult GetProductByName<TResult>(string name, Func<Product, TResult> selector);
        IEnumerable<TResult> GetProductsBySeller<TResult>(string seller, Func<Product, TResult> selector);
        IEnumerable<TResult> GetProductsWithStock<TResult>(Func<Product, TResult> selector);
        IEnumerable<TResult> GetProductsByGenre<TResult>(Genres genre, Func<Product, TResult> selector);

        IEnumerable<TResult> GetProductsBySearch<TResult>(string search, Func<Product, TResult> selector);

        IEnumerable<Product> GetProductFromFav(string username);
    }
}
