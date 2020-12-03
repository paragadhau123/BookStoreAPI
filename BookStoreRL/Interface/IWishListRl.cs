using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRL.Interface
{
    public interface IWishListRl
    {
        WishList AddBookToWishList(string userId, string bookId);

        List<WishList> GetAllWishListValues(string userId);

        Cart MoveToCart(string userId, string wishListId);

        bool DeleteFromWishList(string wishListId);
    }
}
