using BookShop.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Database
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName ="nvarchar(100)")]
        public ICollection<Product> Products { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public ICollection<Order> Orders { get; set; }
        [PersonalData]
        public ICollection<FavoritesProducts> FavoritesProducts { get; set; }
        [PersonalData]
        public byte[] Avatar { get; set; }
        [PersonalData]
        public int Blocked { get; set; }
    }
}
