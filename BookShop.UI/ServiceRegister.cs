using BookShop.Application;
using BookShop.Application.Cart;
using BookShop.Application.OrdersAdmin;
using BookShop.Application.Users;
using BookShop.Database;
using BookShop.Domain.Infrastructure;
using BookShop.UI.Infrastructure;
using System.Linq;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceRegister
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection @this)
        {
            var serviceType = typeof(Service);
            var definedTypes = serviceType.Assembly.DefinedTypes;

            var services = definedTypes.Where(x => x.GetTypeInfo().GetCustomAttribute<Service>() != null);
            

            foreach(var service in services)
            {
                @this.AddTransient(service);
            }

            @this.AddTransient<IStockManager, StockManager>();
            @this.AddTransient<IProductManager, ProductManager>();
            @this.AddTransient<IOrderManager, OrderManager>();
            @this.AddTransient<IUserManager, UserManager>();
            @this.AddScoped<ISessionManager, SessionManager>();


            return @this;
        }
    }
}
