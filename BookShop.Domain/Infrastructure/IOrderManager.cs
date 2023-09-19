using BookShop.Domain.Enums;
using BookShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Domain.Infrastructure
{
    public interface IOrderManager
    {
        bool OrderReferenceExists(string reference);


        Task<int> UpdateOrder(Order order);

        //IEnumerable<TResult> GetOrdersByStatus<TResult>(OrderStatus status, Func<Order, TResult> selector);
        TResult GetOrderById<TResult>(int id, Func<Order, TResult> selector);
        TResult GetOrderByReference<TResult>(string reference, Func<Order, TResult> selector);

        TResult GetOrderBySeller<TResult>(string seller, Func<Order, TResult> selector);
        IEnumerable<TResult> GetOrdersBySeller<TResult>(string seller, Func<Order, TResult> selector);
        IEnumerable<TResult> GetOrdersBySellerClosed<TResult>(string seller, Func<Order, TResult> selector);

        TResult GetOrderByCustomer<TResult>(string customer, Func<Order, TResult> selector);
        IEnumerable<TResult> GetOrdersByCustomer<TResult>(string customer, Func<Order, TResult> selector);
        IEnumerable<TResult> GetOrdersByCustomerClosed<TResult>(string customer, Func<Order, TResult> selector);

        Task<int> CreateOrder(Order order);
        //Task<int> AdvanceOrder(int id);
    }
}
