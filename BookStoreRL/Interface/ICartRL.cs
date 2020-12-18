using BookStoreCL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRL.Interface
{
    public interface ICartRL
    {
        Cart AddBookToCart(string userId, string bookId);

        bool DeleteFromCart(string cartId);

        dynamic GetAllCarts(string userId);
        bool UpdateCart(string cartId, CartModel cartModel);
        bool IncreaseQuantity(string bookId, string userId);
        bool DecreaseQuantity(string bookId, string userId);
    }
}
