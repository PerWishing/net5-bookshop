using System.Threading.Tasks;
using BookShop.Domain.Infrastructure;

namespace BookShop.Application.ProductsUser
{
    [Service]
    public class DeleteProduct
    {
        private IProductManager _productManager;

        public DeleteProduct(IProductManager productManager)
        {
            _productManager = productManager;
        }

        public Task<int> DeleteAbs(int id)
        {
            return _productManager.DeleteProduct(id);
        }
        
    }
}
