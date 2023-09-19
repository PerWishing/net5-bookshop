using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Domain.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int UserOrAdmin { get; set; }
        public int Status { get; set; }
        public string Text { get; set; }
        public string Recipient { get; set; }
        public string Sender { get; set; }
        public byte[] Image { get; set; }
        public DateTime DateOfSend { get; set; }
    }
}
