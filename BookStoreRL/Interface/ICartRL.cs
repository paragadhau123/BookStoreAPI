using BookStoreCL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRL.Interface
{
    public interface ICartRL
    {
        Cart AddBookToCart(string userId, string bookId, CartModel cartModel);

        bool DeleteFromCart(string cartId);

        List<Cart> GetAllCarts(string userId);
    }
}
