using BookShop.Domain.Infrastructure;
using BookShop.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Application.Messages
{
    [Service]
    public class MessageService
    {
        private IUserManager _userManager;

        public MessageService(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> CrateMessage(Request request)
        {
            var message = new Message
            {
                UserOrAdmin = request.UserOrAdmin,
                DateOfSend = DateTime.Now,
                Status = request.Status,
                Recipient = request.Recipient,
                Sender = request.Sender,
                Text = request.Text
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
                message.Image = imageData;
            }

            var succes = await _userManager.CreateMessage(message) > 0;
            if (succes)
            {
                return true;
            }
            return false;
        }

        public int GetMessagesByRecipientByStatus(string username, int status)
        {
            var response = _userManager.GetMessagesByRecipientByStatus(username, status,x => x);

            return response.Count();
        }

        public IEnumerable<Response> GetMessagesBySender(string username)
        {
            var response = _userManager.GetMessagesBySender(username, x => new Response
            {
                Id = x.Id,
                UserOrAdmin = x.UserOrAdmin,
                DateOfSend = x.DateOfSend,
                Status = x.Status,
                Recipient = x.Recipient,
                Sender = x.Sender,
                Text = x.Text,
                Image = x.Image
            });

            return response;
        }

        public IEnumerable<Response> GetDialogsByUser(string username)
        {
            var response = _userManager.GetAllMessagesByUser(username, x => x);
            var names = new List<string>();
            foreach (var r in response)
            {
                if (!names.Contains(r.Recipient)&& r.Recipient!=username)
                {
                    names.Add(r.Recipient);
                }
                if (!names.Contains(r.Sender) && r.Sender != username)
                {
                    names.Add(r.Sender);
                }

            }
            var items = new List<Response>();
            foreach (var n in names)
            {
                items.Add(_userManager.GetLastMessage(username, n, x => new Response {
                    Id = x.Id,
                    UserOrAdmin = x.UserOrAdmin,
                    DateOfSend = x.DateOfSend,
                    Status = x.Status,
                    Recipient = x.Recipient,
                    Sender = x.Sender,
                    Text = x.Text,
                    Image = x.Image
                }));
            }
            
                return items;
        }

        public IEnumerable<Response> GetMessagesBySenderAndRecipient(string sen, string rec)
        {
            var response = _userManager.GetMessagesBySenderAndRecipient(sen,rec, x => new Response
            {
                Id = x.Id,
                UserOrAdmin = x.UserOrAdmin,
                DateOfSend = x.DateOfSend,
                Status = x.Status,
                Recipient = x.Recipient,
                Sender = x.Sender,
                Text = x.Text,
                Image = x.Image
            });

            return response;
        }

        public bool DeleteMessageById(int id)
        {
            return _userManager.DeleteMessage(id).Result > 0;

        }

        public async Task<int> UpdateMessage(int id, int status)
        {
            var res =  await _userManager.UpdateMessage(id, status);
            return res;
        }

        public class Request
        {
            public int Id { get; set; }
            public int UserOrAdmin { get; set; }
            public int Status { get; set; }
            public string Text { get; set; }
            public string Recipient { get; set; }
            public string Sender { get; set; }
            public IFormFile Image { get; set; }
            public DateTime DateOfSend { get; set; }
        }
        public class Response
        {
            public int Id { get; set; }
            public int UserOrAdmin { get; set; }
            public int Status { get; set; }
            public string Text { get; set; }
            public string Recipient { get; set; }
            public string Sender { get; set; }
            public byte[] Image { get; set; }
            public DateTime DateOfSend { get; set; }
            public byte[] Avatar { get; set; }
        }
    }
}
