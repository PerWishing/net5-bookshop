using BookShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public Genres Genre { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public string ISBN { get; set; }
        public string Publishing { get; set; }
        public int Year { get; set; }
        public string Series { get; set; }

        public string Seller { get; set; }              //Username продавца

        public int Available { get; set; }

        public byte[] Image { get; set; }

        public ICollection<Stock> Stock { get; set; }
    }
}
