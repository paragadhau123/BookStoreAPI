using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRL.Interface
{
    public interface IWishListRl
    {
        WishList AddBookToWishList(string userId, string bookId);
        List<WishList> GetAllWishListValues(string userId);
    }
}
