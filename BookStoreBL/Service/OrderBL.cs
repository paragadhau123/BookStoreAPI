using BookStoreBL.Interface;
using BookStoreCL.Models;
using BookStoreRL;
using BookStoreRL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBL.Service
{
    public class OrderBL : IOrderBL
    {
        public IOrderRL orderRL;

        public OrderBL(IOrderRL orderRL)
        {
            this.orderRL = orderRL;
        }
        public Order BookOrder(string userId, string cartId, OrderModel orderModel)
        {
            return this.orderRL.BookOrder(userId, cartId,orderModel);
        }

        public bool DeleteOrder(string orderId)
        {
            return this.orderRL.DeleteOrder(orderId);
        }

        public List<Order> GetAllOrders(string userId)
        {
            return this.orderRL.GetAllOrders(userId);
        }

        public List<Order> OrderAllBook(string userId, OrderModel orderModel)
        {
            return this.orderRL.OrderAllBook(userId, orderModel);
        }
    }
}
