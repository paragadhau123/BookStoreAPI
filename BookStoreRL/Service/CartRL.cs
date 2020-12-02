using BookStoreRL.Interface;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRL.Service
{
    public class CartRL : ICartRL
    {

        private readonly IMongoCollection<Cart> _Cart;
        private readonly IMongoCollection<Book> _Book;

        public CartRL(IBookStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _Cart = database.GetCollection<Cart>(settings.CartCollectionName);
            _Book = database.GetCollection<Book>(settings.BooksCollectionName);
        }

        public Cart AddBookToCart(string userId, string bookId)
        {
            List<Book> details = this._Book.Find(book => book.BookId == bookId).ToList();

            Cart cart = new Cart()
            {
                UserId = userId,
                BookId = details[0].BookId
            };
            this._Cart.InsertOne(cart);
            return cart;
        }

        public bool DeleteFromCart(string cartId)
        {
            this._Cart.DeleteOne(wishList => wishList.CartId == cartId);
            return true;
        }

        public List<Cart> GetAllCarts(string userId)
        {
            return null;
        }
    }
}
