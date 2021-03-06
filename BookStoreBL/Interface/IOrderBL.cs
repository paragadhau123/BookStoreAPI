﻿using BookStoreCL.Models;
using BookStoreCL.RequestModels;
using BookStoreRL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBL.Interface
{
    public interface IOrderBL
    {
        Order BookOrder(string userId, string cartId);

        List<Order> OrderAllBook(string userId );

        bool DeleteOrder(string orderId);

        List<Order> GetAllOrders(string userId);

        AddressModel AddAddress(string userId, AddressModel addressModel);
    }
}
