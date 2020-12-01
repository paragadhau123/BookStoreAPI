using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRL.Interface
{
    public interface ICartRL
    {
        Cart AddBookToCart(string userId, string bookId);
    }
}
