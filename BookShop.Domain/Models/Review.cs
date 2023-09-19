using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Domain.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int PositiveOrNegative { get; set; }
        public int CustomerOrSeller { get; set; }
        public string Text { get; set; }
        public string Recipient { get; set; }
        public string Sender { get; set; }

        public Order Order { get; set; }
    }
}
