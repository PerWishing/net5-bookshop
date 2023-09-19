using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using BookShop.Domain.Enums;
using BookShop.Domain.Infrastructure;
using BookShop.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace BookShop.Application.ProductsUser
{
    [Service]
    public class CreateProduct
    {
        private IProductManager _productManager;

        public CreateProduct(IProductManager productManager)
        {
            _productManager = productManager;
        }

        public async Task<Response> Do(Request request)
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Value = request.Value,
                Seller = request.Username,
                Author = request.Author,
                Genre = request.Genre,
                Publishing = request.Publishing,
                Series = request.Series,
                Year = request.Year,
                ISBN = request.ISBN
            };
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



            if (await _productManager.CreateProduct(product) <= 0)
            {
                throw new Exception("Failed to create product");
            }

            return new Response
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

        public class Request
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }

            public Genres Genre { get; set; }
            public string Author { get; set; }
            public string ISBN { get; set; }
            public string Publishing { get; set; }
            public int Year { get; set; }
            public string Series { get; set; }

            public string Username { get; set; }

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
        }
    }
}
