using BookShop.Domain.Infrastructure;
using BookShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Application.Reviews
{
    [Service]
    public class ReviewService
    {
        private IUserManager _userManager;
        private IOrderManager _orderManager;

        public ReviewService(IUserManager userManager, IOrderManager orderManager)
        {
            _userManager = userManager;
            _orderManager = orderManager;
        }

        public async Task<bool> CrateReview(Request request)
        {
            var review = new Review 
            {
            PositiveOrNegative = request.PositiveOrNegative,
            CustomerOrSeller = request.CustomerOrSeller,
            Text = request.Text,
            Recipient = request.Recipient,
            Sender = request.Sender,
            Order = _orderManager.GetOrderById(request.OrderId, x=> x)
            };

            var succes = await _userManager.CreateReview(review) > 0;
            if (succes)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<Response> GetReviewsByRecipient(string username)
        {
            var response = _userManager.GetReviewsByRecipient(username, x=> new Response 
            {
            PositiveOrNegative = x.PositiveOrNegative,
            CustomerOrSeller = x.CustomerOrSeller,
            Recipient = x.Recipient,
            Sender = x.Sender,
            Text = x.Text,
            OrderId = x.Order.Id
            });

            return response;
        }

        public bool DeleteReviewById(int id)
        {
            return _userManager.DeleteReview(id).Result >0;
            
        }

        public IEnumerable<Response> GetReviewsByOrder(int orderId)
        {
            var response = _userManager.GetReviewsByOrder(orderId, x => new Response
            {
                Id = x.Id,
                PositiveOrNegative = x.PositiveOrNegative,
                CustomerOrSeller = x.CustomerOrSeller,
                Recipient = x.Recipient,
                Sender = x.Sender,
                Text = x.Text,
                OrderId = x.Order.Id
            });

            return response;
        }

        public IEnumerable<Response> GetReviewsByRecipientPos(string username)
        {
            var response = _userManager.GetReviewsByRecipient(username, x => new Response
            {
                PositiveOrNegative = x.PositiveOrNegative,
                CustomerOrSeller = x.CustomerOrSeller,
                Recipient = x.Recipient,
                Sender = x.Sender,
                Text = x.Text,
                OrderId = x.Order.Id
            });

            var responsePos = new List<Response>();

            foreach (var r in response)
            {
                if(r.PositiveOrNegative == 0)
                {
                    responsePos.Add(r);
                }
            }

            return responsePos;
        }

        public IEnumerable<Response> GetReviewsByRecipientNeg(string username)
        {
            var response = _userManager.GetReviewsByRecipient(username, x => new Response
            {
                PositiveOrNegative = x.PositiveOrNegative,
                CustomerOrSeller = x.CustomerOrSeller,
                Recipient = x.Recipient,
                Sender = x.Sender,
                Text = x.Text,
                OrderId = x.Order.Id
            });

            var responsePos = new List<Response>();

            foreach (var r in response)
            {
                if (r.PositiveOrNegative == 1)
                {
                    responsePos.Add(r);
                }
            }

            return responsePos;
        }

        public Response GetReviewBySenderAndOrder(string username, int orderId)
        {
            var response = _userManager.GetReviewBySenderAndOrder(username, orderId, x => new Response
            {
                PositiveOrNegative = x.PositiveOrNegative,
                CustomerOrSeller = x.CustomerOrSeller,
                Recipient = x.Recipient,
                Sender = x.Sender,
                Text = x.Text,
                OrderId = x.Order.Id
            });

            return response;
        }

        public class Request
        {
            public int PositiveOrNegative { get; set; }
            public int CustomerOrSeller { get; set; }
            public string Text { get; set; }
            public string Recipient { get; set; }
            public string Sender { get; set; }
            public int OrderId { get; set; }
        }
        public class Response
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
