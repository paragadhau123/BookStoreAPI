using BookStoreCL.Models;
using BookStoreCL.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRL.Interface
{
    public interface IOrderRL
    {
        Order BookOrder(string userId, string cartId, OrderModel orderModel);
        List<Order> OrderAllBook(string userId, OrderModel orderModel);
        bool DeleteOrder(string orderId);
        List<Order> GetAllOrders(string userId);
        AddressModel AddAddress(string userId, AddressModel addressModel);
    }
}
