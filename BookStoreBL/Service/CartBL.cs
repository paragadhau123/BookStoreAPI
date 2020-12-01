using BookStoreBL.Interface;
using BookStoreRL;
using BookStoreRL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBL.Service
{
    public class CartBL : ICartBL
    {
        public ICartRL cartRL;

        public CartBL(ICartRL cartRL)
        {
            this.cartRL = cartRL;
        }

        public Cart AddBookToCart(string userId, string bookId)
        {
            return this.cartRL.AddBookToCart(userId,bookId);
        }
    }
}
