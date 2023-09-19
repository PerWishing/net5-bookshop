using BookShop.Domain.Enums;
using BookShop.Domain.Infrastructure;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Application.Orders
{
    [Service]
    public class UpdateOrder
    {
        private IOrderManager _orderManager;
        private IProductManager _productManager;
        IDataProtector _protector;

        public UpdateOrder(IOrderManager orderManager, IProductManager productManager, IDataProtectionProvider provider)
        {
            _orderManager = orderManager;
            _productManager = productManager;
            _protector = provider.CreateProtector("Order");
        }

        public async Task<Response> UpdateAllOrder(Request request)
        {
            var order = _orderManager.GetOrderById(request.Id, x => x);

            order.Email = request.Email;
            order.FIO = _protector.Protect(request.FIO);
            order.PhoneNumber = _protector.Protect(request.PhoneNumber);
            order.Adress = _protector.Protect(request.Adress1);
            order.City = _protector.Protect(request.City);
            order.PostCode = _protector.Protect(request.PostCode);

            await _orderManager.UpdateOrder(order);

            var response =  new Response()
            {
                FIO = request.FIO,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Adress1 = request.Adress1,
                City = request.City,
                PostCode = request.PostCode,
                TrackNum = request.TrackNum
            };

            return response;
        }
        public async Task<int> UpdateStatusForCustomer(int id, int status)
        {
            var order = _orderManager.GetOrderById(id, x => x);

            order.StatusForCustomer = (OrderStatusForCustomer)status;

            await _orderManager.UpdateOrder(order);

            return status;
        }

        public async Task<int> UpdateStatusForSeller(int id, int status)
        {
            var order = _orderManager.GetOrderById(id, x => x);

            order.StatusForSeller = (OrderStatusForSeller)status;

            await _orderManager.UpdateOrder(order);

            return status;
        }

        public async Task<int> UpdateStatusOpenOrClosed(int id, int status)
        {
            var order = _orderManager.GetOrderById(id, x => x);

            order.StatusOpenOrClosed = (OrderStatusOpenOrClosed)status;
            order.DateOfClosingOrder = DateTime.Today;

            if ((int)order.StatusForCustomer == 1 && (int)order.StatusForSeller == 3)
            {
                var product = order.Product;
                product.Available = 1;

                await _productManager.UpdateProduct(product);
            }

            await _orderManager.UpdateOrder(order);

            return status;
        }

        

        public async Task<string> UpdateTrackNumForSeller(RequestForTrackNum request)
        {
            var order = _orderManager.GetOrderById(request.Id, x => x);

            order.TrackNumber = _protector.Protect(request.TrackNum);

            await _orderManager.UpdateOrder(order);
            
            
            return request.TrackNum;
        }

        public async Task<byte[]> UpdateSellerImage(RequestForSellerImage request)
        {
            var order = _orderManager.GetOrderById(request.Id, x => x);

            if (request.SellerImage != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(request.SellerImage.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)request.SellerImage.Length);
                }
                // установка массива байтов
                order.SellerImage = imageData;
            }

            await _orderManager.UpdateOrder(order);


            return order.SellerImage;
        }

        public async Task<byte[]> UpdateCustomerImage(RequestForCustomerImage request)
        {
            var order = _orderManager.GetOrderById(request.Id, x => x);

            if (request.CustomerImage != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(request.CustomerImage.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)request.CustomerImage.Length);
                }
                // установка массива байтов
                order.CustomerImage = imageData;
            }

            await _orderManager.UpdateOrder(order);

            return order.CustomerImage;
        }

        public async Task<string> UpdateCommentOfCancelForSeller(RequestForCommentOfCancel request)
        {
            var order = _orderManager.GetOrderById(request.Id, x => x);

            order.CommentOfCancel = request.Comment;

            await _orderManager.UpdateOrder(order);


            return request.Comment;
        }

        public class Response
        {
            public string OrderRef { get; set; }

            public string Seller { get; set; }
            public string Customer { get; set; }


            public string FIO { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }

            public string Adress1 { get; set; }
            public string Adress2 { get; set; }
            public string City { get; set; }
            public string PostCode { get; set; }

            public int ProductId { get; set; }
            public Product Product { get; set; }
           

            public string TrackNum { get; set; }
        }
        public class Request
        {
            public int Id { get; set; }
            public string OrderRef { get; set; }

            public string Seller { get; set; }
            public string Customer { get; set; }


            public string FIO { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }

            public string Adress1 { get; set; }
            public string City { get; set; }
            public string PostCode { get; set; }

            public int ProductId { get; set; }
            public Product Product { get; set; }
           

            public string TrackNum { get; set; }
        }

        public class RequestForTrackNum
        {
            public int Id { get; set; }
            public string TrackNum { get; set; }
        }

        public class RequestForSellerImage
        {
            public int Id { get; set; }
            public IFormFile SellerImage { get; set; }
        }

        public class RequestForCustomerImage
        {
            public int Id { get; set; }
            public IFormFile CustomerImage { get; set; }
        }

        public class RequestForCommentOfCancel
        {
            public int Id { get; set; }
            public string Comment { get; set; }
        }

        public class Product
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Value { get; set; }
            public int Qty { get; set; }
            public string StockDescription { get; set; }
            public int Available { get; set; }
        }
    }
}
