using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Domain.Enums
{
    public enum OrderStatusForCustomer
    {
        NotReceived,
        Received,
        Edited,
        Canceled,
        CanceledOnPost
    }
}
