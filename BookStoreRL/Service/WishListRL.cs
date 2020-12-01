using BookStoreRL.Interface;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStoreRL.Service
{
    public class WishListRL : IWishListRl
    {
        private readonly IMongoCollection<WishList> _WishList;
        private readonly IMongoCollection<Book> _Book;
        private readonly IMongoCollection<Cart> _Cart;

        public WishListRL(IBookStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            this._WishList = database.GetCollection<WishList>(settings.WishListCollectionName);
            this._Book= database.GetCollection<Book>(settings.BooksCollectionName);
            _Cart = database.GetCollection<Cart>(settings.CartCollectionName);
        }

        public WishList AddBookToWishList(string userId, string bookId)
        {
           List<Book> details = this._Book.Find(book => book.BookId == bookId).ToList();

            WishList wishList = new WishList()
            {
                UserId = userId,
                BookId= details[0].BookId
            };
            this._WishList.InsertOne(wishList);
            return wishList;
        }

        public List<WishList> GetAllWishListValues(string userId)
        {
            List<WishList> details = this._WishList.Find(wishlist => wishlist.UserId == userId).ToList();

            if (details.Count == 0)
            {
                return null;
            }
            else
            {
                return null;

            }
        }

        public Cart MoveToCart(string userId, string wishListId)
        {
            List<WishList> details = this._WishList.Find(wishlist => wishlist.WishListId == wishListId).ToList();
            Cart cart = new Cart()
            {
                UserId = userId,
                BookId = details[0].BookId
            };
            this._Cart.InsertOne(cart);
            this._WishList.DeleteOne(wishList => wishList.WishListId == wishListId);
            return cart;
        }
    }
}
