﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Domain.Models
{
    public class CustomerInformation
    {
        public string CustomerId { get; set; }//Id покупателя
        public string FIO { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string Adress1 { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
    }
}
