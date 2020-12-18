using BookStoreCL.Models;
using BookStoreRL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBL.Interface
{
    public interface ICartBL
    {
        Cart AddBookToCart(string userId, string bookId);
        bool DeleteFromCart(string cartId);
        dynamic GetAllCarts(string userId);
        bool UpdateCart(string cartId, CartModel cartModel);
        bool IncreaseQuantity(string bookId, string userId);
        bool DecreaseQuantity(string bookId, string userId);
    }
}
