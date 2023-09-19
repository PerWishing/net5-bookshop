using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Database;
using BookShop.Domain.Enums;
using BookShop.Domain.Infrastructure;
using BookShop.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace BookShop.Application.ProductsUser
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
            product.Author = request.Author;
            product.Genre = request.Genre;
            product.Publishing = request.Publishing;
            product.Series = request.Series;
            product.Year = request.Year;
            product.ISBN = request.ISBN;
            

                 if (request.Image != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(request.Image.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)request.Image.Length);
                }
                // установка массива байтов
                product.Image = imageData;
            }

            await _productManager.UpdateProduct(product);

            return new Response()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Value = product.Value,
                Author = product.Author,
                Genre = product.Genre,
                Publishing = product.Publishing,
                Series = product.Series,
                Year = product.Year,
                ISBN = product.ISBN
            };
        }

        public async Task<Response> UpdateAvailable(int id, int available)
        {
            var product = _productManager.GetProductById(id, x => x);

            product.Available = available;

            await _productManager.UpdateProduct(product);

            return new Response()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Value = product.Value,
                Author = product.Author,
                Genre = product.Genre,
                Publishing = product.Publishing,
                Series = product.Series,
                Year = product.Year,
                ISBN = product.ISBN,
                Image = product.Image
            };
        }

        public class Request
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }

            public Genres Genre { get; set; }
            public string Author { get; set; }
            public string ISBN { get; set; }
            public string Publishing { get; set; }
            public int Year { get; set; }
            public string Series { get; set; }

            public IFormFile Image { get; set; }
        }
        public class Response
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }

            public Genres Genre { get; set; }
            public string Author { get; set; }
            public string ISBN { get; set; }
            public string Publishing { get; set; }
            public int Year { get; set; }
            public string Series { get; set; }
            public byte[] Image { get; set; }
        }
    }
    
}
