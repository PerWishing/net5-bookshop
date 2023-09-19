using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Domain.Models
{
    public class UserPublic
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] Avatar { get; set; }
        public int Blocked { get; set; }

        public ICollection<Product> Products { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<Product> FavoritesProducts { get; set; }//Добавленные в избранное
    }
}
