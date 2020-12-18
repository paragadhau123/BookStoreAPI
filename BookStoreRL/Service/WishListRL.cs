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
        private readonly IMongoCollection<WishList>_WishList;
        private readonly IMongoCollection<Book>_Book;
        private readonly IMongoCollection<Cart>_Cart;

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

        public bool DeleteFromWishList(string wishListId)
        {
            this._WishList.DeleteOne(wishList => wishList.WishListId == wishListId);
            return true;
        }

        public dynamic GetAllWishListValues(string userId)
        {
            try
            {
                var query = from w in _WishList.AsQueryable()
                            join b in _Book.AsQueryable()
                            on w.BookId equals b.BookId into newItem
                            where w.UserId == userId
                            select new
                            {
                                WishListId = w.WishListId,
                                BookId = w.BookId,
                                BookName = newItem.First().BookName,
                                AuthorName = newItem.First().AuthorName,
                                Price = newItem.First().Price,
                                Quantity= newItem.First().Quantity,
                                Image = newItem.First().Image
                            };
                var a = query.ToList();
                return a;
            }

            catch (Exception e)
            {
                throw e;
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
