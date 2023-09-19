using BookShop.Domain.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.UI.Hubs
{
    public class ChatHub :Hub
    {

        public async Task Send(string message, string to)
        {
            var userName = Context.User.Identity.Name;

            //if (Context.UserIdentifier != to) // если получатель и текущий пользователь не совпадают
            //    await Clients.User(Context.UserIdentifier).SendAsync("Receive", message, userName);
            await Clients.User(to).SendAsync("Receive", message, userName);
        }

        public async Task NotifyOrder(string to, int orderId)
        {
            var userName = Context.User.Identity.Name;

            //if (Context.UserIdentifier != to) // если получатель и текущий пользователь не совпадают
            //    await Clients.User(Context.UserIdentifier).SendAsync("Receive", message, userName);
            await Clients.User(to).SendAsync("ReceiveNotyOrder", userName, orderId);
        }
    }
}
