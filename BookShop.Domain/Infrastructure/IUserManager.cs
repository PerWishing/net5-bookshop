using BookShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Domain.Infrastructure
{
    public interface IUserManager
    {
        Task<bool> CreateManagerUser(string username, string passowrd, string email);
        Task<UserPublic> GetUserPublicByName(string username);


        Task<bool> CheckProductInFav(string username, int productId);
        Task<bool> AddProductInFav(string username, int productId);
        Task<bool> DeleteProductFromFav(string username, int productId);

        IEnumerable<UserPublic> GetUsersPublic();
        IEnumerable<UserPublic> GetUsersPublicBySearch(string search);

        //Отзывы
        Task<int> CreateReview(Review review);
        Task<int> DeleteReview(int id);
        Task<int> UpdateReview(Review review);
        TResult GetReviewByRecipient<TResult>(string recipient, Func<Review, TResult> selector);
        IEnumerable<TResult> GetReviewsByRecipient<TResult>(string recipient, Func<Review, TResult> selector);
        TResult GetReviewBySender<TResult>(string sender, Func<Review, TResult> selector);
        TResult GetReviewBySenderAndOrder<TResult>(string sender, int orderId, Func<Review, TResult> selector);
        IEnumerable<TResult> GetReviewsBySender<TResult>(string sender, Func<Review, TResult> selector);
        IEnumerable<TResult> GetReviewsByOrder<TResult>(int OrderId, Func<Review, TResult> selector);
        Task<bool> UpdateAvatarManagerUser(string username, byte[] avatar);
        Task<bool> UpdateUserBlock(string username, int block);
        Task<bool> GiveRole(string username);
        Task<bool> CheckRole(string username);

        //Сообщения
        Task<int> CreateMessage(Message message);
        Task<int> DeleteMessage(int id);
        Task<int> UpdateMessage(int id, int status);
        IEnumerable<TResult> GetMessagesByRecipientByStatus<TResult>(string recipient, int status, Func<Message, TResult> selector);
        IEnumerable<TResult> GetMessagesBySender<TResult>(string sender, Func<Message, TResult> selector);
        IEnumerable<TResult> GetMessagesBySenderAndRecipient<TResult>(string sender, string recipient, Func<Message, TResult> selector);
        IEnumerable<TResult> GetAllMessagesByUser<TResult>(string user, Func<Message, TResult> selector);
        TResult GetLastMessage<TResult>(string user1, string user2, Func<Message, TResult> selector);
    }
}
