using BookShop.Domain.Infrastructure;
using System.Threading.Tasks;

namespace BookShop.Application.OrdersAdmin
{
    [Service]
    public class UpdateOrder
    {
        private IOrderManager _orderManager;

        public UpdateOrder(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }

        //public Task<int> DoAsync(int id)
        //{
        //    //TODO: this have problem then you reorder
        //    return _orderManager.AdvanceOrder(id);

        //}
    }
}
