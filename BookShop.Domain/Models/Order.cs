using BookShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderRef { get; set; }
        public string StripeReference { get; set; } //ссылка на покупателя, содержащая информацию о покупателе и заказе


        public string CustomerName { get; set; }//Имя покупателя
        public DateTime DateOfStatusChangeForCustomer { get; set; }

        public string SellerName { get; set; }//Имя продавца
        public DateTime DateOfStatusChangeForSeller { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public string FIO { get; set; }
        
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string Adress { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }

        public OrderStatusForSeller StatusForSeller { get; set; }
        public OrderStatusForCustomer StatusForCustomer { get; set; }

        public string TrackNumber { get; set; }
        public string CommentOfCancel { get; set; }

        public OrderStatusOpenOrClosed StatusOpenOrClosed { get; set; }
        public DateTime DateOfClosingOrder { get; set; }

        public byte [] SellerImage { get; set; }
        public byte [] CustomerImage { get; set; }

    }
}
