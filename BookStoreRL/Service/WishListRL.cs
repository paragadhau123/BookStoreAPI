using BookStoreRL.Interface;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRL.Service
{
    public class WishListRL : IWishListRl
    {

        private readonly IMongoCollection<WishList> _WishList;
        private readonly IMongoCollection<Book> _Book;
        public WishListRL(IBookStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            this._WishList = database.GetCollection<WishList>(settings.WishListCollectionName);
            this._Book= database.GetCollection<Book>(settings.BooksCollectionName);
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
            throw new NotImplementedException();
        }
    }
}
