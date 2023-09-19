using BookShop.Domain.Enums;
using BookShop.Domain.Infrastructure;
using BookShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Database
{
    public class OrderManager : IOrderManager
    {
        private readonly ApplicationDbContext _ctx;

        public OrderManager(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public bool OrderReferenceExists(string reference)
        {
            return _ctx.Orders.Any(x => x.OrderRef == reference);
        }

        //public IEnumerable<TResult> GetOrdersByStatus<TResult>(OrderStatus status, Func<Order, TResult> selector)
        //{
        //    return _ctx.Orders
        //    .Where(x => x.Status == status)
        //    .Select(selector).ToList();
        //}

        public Task<int> UpdateOrder(Order order)
        {
            _ctx.Orders.Update(order);
            return _ctx.SaveChangesAsync();
        }

        private TResult GetOrder<TResult>(
            Func<Order, bool> condition,
            Func<Order, TResult> selector)
        {

            return _ctx.Orders
                .Include(x => x.Product).AsEnumerable()
                .Where(x => condition(x))
                .Select(selector)
                .FirstOrDefault();
        }

        private IEnumerable<TResult> GetOrders<TResult>(
            Func<Order, bool> condition,
            Func<Order, TResult> selector)
        {

            return _ctx.Orders
                .Include(x => x.Product).AsEnumerable()
                .Where(x => condition(x))
                .Select(selector)
                .ToList();
        }

        public TResult GetOrderById<TResult>(int id, Func<Order, TResult> selector)
        {
            return GetOrder(order => order.Id == id, selector);
        }

        public TResult GetOrderBySeller<TResult>(string seller, Func<Order, TResult> selector)
        {
            return GetOrder(order => order.SellerName == seller, selector);
        }
        public IEnumerable<TResult> GetOrdersBySeller<TResult>(string seller, Func<Order, TResult> selector)
        {
            return GetOrders(order => order.SellerName == seller && (int)order.StatusOpenOrClosed == 0, selector);
        }

        public IEnumerable<TResult> GetOrdersBySellerClosed<TResult>(string seller, Func<Order, TResult> selector)
        {
            return GetOrders(order => order.SellerName == seller && (int)order.StatusOpenOrClosed == 1, selector);
        }

        public TResult GetOrderByCustomer<TResult>(string customer, Func<Order, TResult> selector)
        {
            return GetOrder(order => order.CustomerName == customer, selector);
        }

        public IEnumerable<TResult> GetOrdersByCustomer<TResult>(string customer, Func<Order, TResult> selector)
        {
            return GetOrders(order => order.CustomerName == customer && order.StatusOpenOrClosed == 0, selector);
        }

        public IEnumerable<TResult> GetOrdersByCustomerClosed<TResult>(string customer, Func<Order, TResult> selector)
        {
            return GetOrders(order => order.CustomerName == customer && (int)order.StatusOpenOrClosed == 1, selector);
        }

        public TResult GetOrderByReference<TResult>(string reference, Func<Order, TResult> selector)
        {
            return GetOrder(order => order.OrderRef == reference, selector);
        }

        public Task<int> CreateOrder(Order order)
        {
            _ctx.Orders.Add(order);

            return _ctx.SaveChangesAsync();

        }

        //public Task<int> AdvanceOrder(int id)
        //{
        //    _ctx.Orders.FirstOrDefault(x => x.Id == id).Status++;

        //    return _ctx.SaveChangesAsync();
        //}
    }
}
