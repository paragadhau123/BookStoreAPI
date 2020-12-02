using BookStoreRL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBL.Interface
{
    public interface IWishListBL
    {
        WishList AddBookToWishList(string userId, string bookId);
        List<WishList> GetAllWishListValues(string userId);
        Cart MoveToCart(string userId, string wishListId);
        bool DeleteFromWishList(string wishListId);
    }
}
