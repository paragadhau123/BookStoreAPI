using BookStoreRL.Interface;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRL.Service
{
   public class ReviewRL:IReviewRL
    {
        private readonly IMongoCollection<Book> _Book;
        private readonly IMongoCollection<Cart> _Cart;
        private readonly IMongoCollection<review> _Review;
        private readonly IMongoCollection<User> _User;


        public ReviewRL(IBookStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _Book = database.GetCollection<Book>(settings.BooksCollectionName);
            _Cart = database.GetCollection<Cart>(settings.CartCollectionName);
            _Review = database.GetCollection<review>(settings.reviewCollectionName);
            _User = database.GetCollection<User>(settings.UsersCollectionName);
        }

        public review AddReview(string bookId, string userId, review review)
        {
            List<User> list = this._User.Find(user => user.Id == userId).ToList();
            review newReviewModel = new review()
            {
                BookId = bookId,
                UserId = userId,
                UserName = list[0].FirstName + " " + list[0].LastName,
                Review = review.Review
            };
            _Review.InsertOne(newReviewModel);
            return newReviewModel;
        }
        public List<review> getReview(string bookId)
        {
            List<review> list = this._Review.Find(review => review.BookId == bookId).ToList();
            return list;
        }
    }
}
