using BookShop.Domain.Infrastructure;
using BookShop.Domain.Models;
using Korzh.EasyQuery.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Database
{
    public class UserManager : IUserManager
    {

        private UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _ctx;

        public UserManager(UserManager<ApplicationUser> userManager, ApplicationDbContext ctx)
        {
            _userManager = userManager;
            _ctx = ctx;
        }
        

        public async Task<bool> CreateManagerUser(string username, string passowrd, string email)
        {
            var managerUser = new ApplicationUser()
            {
                UserName = username,
                Email = email
            };

            var user = await _userManager.FindByNameAsync(username);//сразу можно чекнуть в бд по имени
            
            if(user != null) { return false; }

            await _userManager.CreateAsync(managerUser, passowrd);//создает только при сложном пароле, создает и добавляет в бд сразу


            var managerClaim = new Claim("Role", "Manager");

            await _userManager.AddClaimAsync(managerUser, managerClaim);
            return true;
        }

        public async Task<bool> UpdateAvatarManagerUser(string username, byte[] avatar)
        {
            var user = await _userManager.FindByNameAsync(username);//сразу можно чекнуть в бд по имени

            if (user == null) { return false; }
            user.Avatar = avatar;
             await _userManager.UpdateAsync(user);
            return await _ctx.SaveChangesAsync()>0;
        }

        public async Task<bool> UpdateUserBlock(string username, int block)
        {
            var user = await _userManager.FindByNameAsync(username);

            user.Blocked = block;
            await _userManager.UpdateAsync(user);
            return await _ctx.SaveChangesAsync() > 0;
        }


        public async Task<UserPublic> GetUserPublicByName(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if(user != null)
            {

            return new UserPublic() { 
            Username = user.UserName,
            Email = user.Email,
            Avatar = user.Avatar,
                Blocked = user.Blocked
            };
            }
            else
            {
                return new UserPublic();
            }
        }

        public async Task<bool> GiveRole(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            var adminClaim = new Claim("Role", "Admin");

            var result = await _userManager.AddClaimAsync(user, adminClaim);
            return result.Succeeded;
        }

        public async Task<bool> CheckRole(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            var result = await _userManager.GetClaimsAsync(user);

            var res = result.FirstOrDefault();
            if (result.Count ==1)
            {
            res = result[0];

            }
            else
            {
                res = result[1];
            }
            var val = res.Value;
            if (val == "Admin")
            {
            return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<UserPublic> GetUsersPublic()
        {
            var user = _userManager.Users;

            var pubUsers = new List<UserPublic>();
            foreach (var u in user)
            {
                pubUsers.Add(
                new UserPublic()
                {
                    Username = u.UserName,
                    Email = u.Email,
                    Avatar = u.Avatar,
                    Blocked = u.Blocked
                }
                    );
            }
            return pubUsers;
        }

        public IEnumerable<UserPublic> GetUsersPublicBySearch(string search)
        {
            var user = _userManager.Users.FullTextSearchQuery(search);

            var pubUsers = new List<UserPublic>();
            foreach (var u in user)
            {
                pubUsers.Add(
                new UserPublic()
                {
                    Username = u.UserName,
                    Email = u.Email,
                    Avatar = u.Avatar,
                    Blocked = u.Blocked
                }
                    );
            }
            return pubUsers;
        }

        public async Task<bool> CheckProductInFav(string username, int productId)
        {
            var user = await _userManager.FindByNameAsync(username);
            var favoritesProducts = _ctx.FavoritesProducts;
            if (favoritesProducts.Any(x => (x.ProductId == productId) && (x.ApplicationUser.UserName == username)))
            {
                return true;
            }
           
            return false;
        }

        public async Task<bool> DeleteProductFromFav(string username, int productId)
        {
            var user = await _userManager.FindByNameAsync(username);
            var favoritesProducts = _ctx.FavoritesProducts;
            var favoritesProduct = favoritesProducts.FirstOrDefault(x => (x.ProductId == productId) && (x.ApplicationUser.UserName == username));
            _ctx.FavoritesProducts.Remove(favoritesProduct);
            var res = await _ctx.SaveChangesAsync();
            if(res>0)
                return true;
            else
                return false;
        }

        public async Task<bool> AddProductInFav(string username, int productId)
        {
            var user = await _userManager.FindByNameAsync(username);
            var favoritesProducts = _ctx.FavoritesProducts;
            if(favoritesProducts.Any(x => (x.ProductId == productId) &&(x.ApplicationUser.UserName == username)))
            {
                return false;
            }
            favoritesProducts.Add(new FavoritesProducts
            {
                ApplicationUserId = user.Id,
                ApplicationUser = user,
                ProductId = productId,
                Product = _ctx.Products
                .Include(x => x.Stock)
                .Where(x => x.Id == productId)
                .FirstOrDefault()
        });

            await _ctx.SaveChangesAsync();
            return true;
        }

        //Отзывы
        public Task<int> CreateReview(Review review)
        {
            _ctx.Reviews.Add(review);

            return _ctx.SaveChangesAsync();
        }

        public Task<int> DeleteReview(int id)
        {
            var review = _ctx.Reviews.FirstOrDefault(x => x.Id == id);
            _ctx.Remove(review);
            return _ctx.SaveChangesAsync();
        }
        public Task<int> UpdateReview(Review review)
        {
            _ctx.Reviews.Update(review);
            return _ctx.SaveChangesAsync();
        }

        public TResult GetReviewByRecipient<TResult>(string recipient, Func<Review, TResult> selector)
        {
            return _ctx.Reviews
                .Include(x => x.Order)
                .Where(x => x.Recipient == recipient)
                .Select(selector)
                .FirstOrDefault();
            
        }

        public IEnumerable<TResult> GetReviewsByRecipient<TResult>(string recipient, Func<Review, TResult> selector)
        {
            return _ctx.Reviews
                .Include(x => x.Order)
                .Where(x => x.Recipient == recipient)
                .Select(selector)
                .ToList();
        }

        public TResult GetReviewBySender<TResult>(string sender, Func<Review, TResult> selector)
        {
            return _ctx.Reviews
                .Include(x => x.Order)
                .Where(x => x.Sender == sender)
                .Select(selector)
                .FirstOrDefault();
        }

        public TResult GetReviewBySenderAndOrder<TResult>(string sender, int orderId, Func<Review, TResult> selector)
        {
            return _ctx.Reviews
                .Include(x => x.Order)
                .Where(x => x.Sender == sender && x.Order.Id == orderId)
                .Select(selector)
                .FirstOrDefault();
        }

        public IEnumerable<TResult> GetReviewsBySender<TResult>(string sender, Func<Review, TResult> selector)
        {
            return _ctx.Reviews
                .Include(x => x.Order)
                .Where(x => x.Sender == sender)
                .Select(selector)
                .ToList();
        }
        public IEnumerable<TResult> GetReviewsByOrder<TResult>(int OrderId, Func<Review, TResult> selector)
        {
            return _ctx.Reviews
                .Include(x => x.Order)
                .Where(x => x.Order.Id == OrderId)
                .Select(selector)
                .ToList();
        }


        //Сообщения
        public Task<int> CreateMessage(Message message)
        {
            _ctx.Messages.Add(message);

            return _ctx.SaveChangesAsync();
        }

        public Task<int> DeleteMessage(int id)
        {
            var review = _ctx.Messages.FirstOrDefault(x => x.Id == id);
            _ctx.Remove(review);
            return _ctx.SaveChangesAsync();
        }
        public Task<int> UpdateMessage(int id, int status)
        {
            var m = _ctx.Messages.Where(x => x.Id == id).FirstOrDefault();
            m.Status = status;
            var result = _ctx.Messages.Update(m);
            return _ctx.SaveChangesAsync();
        }
       
        public IEnumerable<TResult> GetMessagesByRecipientByStatus<TResult>(string recipient,int status, Func<Message, TResult> selector)
        {
            return _ctx.Messages
                .Where(x => x.Recipient == recipient && x.Status == status)
                .Select(selector)
                .ToList();
        }
        public IEnumerable<TResult> GetMessagesBySender<TResult>(string sender, Func<Message, TResult> selector)
        {
            return _ctx.Messages
                .Where(x => x.Sender == sender)
                .Select(selector)
                .ToList();
        }
        public IEnumerable<TResult> GetMessagesBySenderAndRecipient<TResult>(string sender, string recipient, Func<Message, TResult> selector)
        {
            return _ctx.Messages
                .Where(x => x.Sender == sender && x.Recipient == recipient)
                .Select(selector)
                .ToList();
        }

        public IEnumerable<TResult> GetAllMessagesByUser<TResult>(string user, Func<Message, TResult> selector)
        {
            return _ctx.Messages
                .Where(x => (x.Sender == user || x.Recipient == user))
                .Select(selector)
                .ToList();
        }
        
        public TResult GetLastMessage<TResult>(string user1, string user2, Func<Message, TResult> selector)
        {
            return _ctx.Messages
                .Where(x => (x.Sender == user1 || x.Recipient == user1)&& (x.Sender == user2 || x.Recipient == user2))
                .Select(selector)
                .LastOrDefault();
        }
    }
}
