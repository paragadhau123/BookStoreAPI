using BookStoreRL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBL.Interface
{
    public interface IWishListBL
    {
        WishList AddBookToWishList(string userId, string bookId);
        List<WishList> GetAllWishListValues(userId);
    }
}
