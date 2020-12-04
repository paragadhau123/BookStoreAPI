﻿using BookStoreCL.Models;
using BookStoreRL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBL.Interface
{
    public interface ICartBL
    {
        Cart AddBookToCart(string userId, string bookId, CartModel cartModel);
        bool DeleteFromCart(string cartId);
        List<Cart> GetAllCarts(string userId);
        bool UpdateCart(string cartId, CartModel cartModel);
    }
}
