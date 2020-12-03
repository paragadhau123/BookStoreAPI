using BookStoreCL.Models;
using BookStoreRL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBL.Interface
{
    public interface IOrderBL
    {
        Order BookOrder(string userId, string cartId, OrderModel orderModel);
        List<Order> OrderAllBook(string userId, OrderModel orderModel);
        bool DeleteOrder(string orderId);
        List<Order> GetAllOrders(string userId);
    }
}
