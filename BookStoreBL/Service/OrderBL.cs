using BookStoreBL.Interface;
using BookStoreCL.Models;
using BookStoreCL.RequestModels;
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

        public AddressModel AddAddress(string userId, AddressModel addressModel)
        {
            return this.orderRL.AddAddress(userId, addressModel);
        }

        public Order BookOrder(string userId, string cartId )
        {
            return this.orderRL.BookOrder(userId, cartId);
        }

        public bool DeleteOrder(string orderId)
        {
            return this.orderRL.DeleteOrder(orderId);
        }

        public List<Order> GetAllOrders(string userId)
        {
            return this.orderRL.GetAllOrders(userId);
        }

        public List<Order> OrderAllBook(string userId )
        {
            return this.orderRL.OrderAllBook(userId);
        }
    }
}
