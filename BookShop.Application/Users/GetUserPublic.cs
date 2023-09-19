using BookShop.Domain.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookShop.Application.Users
{
    [Service]
    public class GetUserPublic
    {
        private IUserManager _userManager;
        private IProductManager _productManager;
        private IOrderManager _orderManager;

        public GetUserPublic(IUserManager userManager, IProductManager productManager, IOrderManager orderManager)
        {
            _userManager = userManager;
            _productManager = productManager;
            _orderManager = orderManager;
        }

        public async Task<Response> GetPublicUser(string username)
        {
            var user = await _userManager.GetUserPublicByName(username);

            var response = new Response()
            {
                UserName = user.Username,
                Email = user.Email,
                Avatar = user.Avatar,
                Blocked = user.Blocked
            };
            
            return response;
        }

        public async Task<bool> CheckRole(string username)
        {
            return await _userManager.CheckRole(username);
        }

        public async Task<Response> GetPublicUserWithProducts(string username)
        {
            var user = await _userManager.GetUserPublicByName(username);

            var response = new Response()
            {
                UserName = user.Username,
                Email = user.Email,
                Avatar = user.Avatar,
                Blocked = user.Blocked
            };

             var avProd = _productManager.GetProductsBySeller(user.Username, x => new Product
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Value = x.Value.GetValueString(),
                Author = x.Author,
                Image = x.Image,
                Available = x.Available
            });

            var prs = new List<Product>();
            foreach (var p in avProd) {

                if (p.Available == 0) {
                    prs.Add(p);
                }
            }
            response.Products = prs;

            response.Reviews = _userManager.GetReviewsByRecipient(user.Username, x => new Review 
            {
            Id = x.Id,
            CustomerOrSeller = x.CustomerOrSeller,
            PositiveOrNegative = x.PositiveOrNegative,
            Text = x.Text,
            Recipient = x.Recipient,
            Sender = x.Sender,
            OrderId = x.Order.Id
            });

            return response;
        }

        public async Task<int> UpdateAvatar(Request request)
        {
            byte[] avatar = new byte[] {};
            if (request.Avatar != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(request.Avatar.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)request.Avatar.Length);
                }
                // установка массива байтов
                avatar = imageData;
            }
            await _userManager.UpdateAvatarManagerUser(request.UserName, avatar);
            return 1;
        }

        public async Task<bool> UpdateBlocked(string username,int block)
        {
             return await _userManager.UpdateUserBlock(username,block);
        }

        public class Request
        {
            public string UserName { get; set; }

            public IFormFile Avatar { get; set; }

        }

        public class Response
        {
            public string UserName { get; set; }
            public string Email { get; set; }

            public byte[] Avatar { get; set; }

            public int Blocked { get; set; }

            public List<Product> Products { get; set; }
            public IEnumerable<Review> Reviews { get; set; }
        }

        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Value { get; set; }
            public string Author { get; set; }
            public byte[] Image { get; set; }
            public int Available { get; set; }
        }

        public class Review
        {
            public int Id { get; set; }
            public int PositiveOrNegative { get; set; }
            public int CustomerOrSeller { get; set; }
            public string Text { get; set; }
            public string Recipient { get; set; }
            public string Sender { get; set; }
            public int OrderId { get; set; }
        }


    }
}
