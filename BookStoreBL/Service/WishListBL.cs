using BookStoreBL.Interface;
using BookStoreRL;
using BookStoreRL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBL.Service
{
    public class WishListBL : IWishListBL
    {
        public IWishListRl wishListRL;

        public WishListBL(IWishListRl wishListRL)
        {
            this.wishListRL = wishListRL;
        }

        public WishList AddBookToWishList(string userId, string bookId)
        {
            return this.wishListRL.AddBookToWishList(userId,bookId);
        }

        public bool DeleteFromWishList(string wishListId)
        {
            return this.wishListRL.DeleteFromWishList(wishListId);
        }

        public List<WishList> GetAllWishListValues(string userId)
        {
            return this.wishListRL.GetAllWishListValues(userId);
        }

        public Cart MoveToCart(string userId, string wishListId)
        {
            return this.wishListRL.MoveToCart(userId,wishListId);
        }
    }
}
