using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRL.Interface
{
    public interface IWishListRl
    {
        WishList AddBookToWishList(string userId, string bookId);

        dynamic GetAllWishListValues(string userId);

        Cart MoveToCart(string userId, string wishListId);

        bool DeleteFromWishList(string wishListId);
    }
}
