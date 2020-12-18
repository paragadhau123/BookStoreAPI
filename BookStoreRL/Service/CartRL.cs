using BookStoreCL.Models;
using BookStoreRL.Interface;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver.Linq;
using System.Linq;

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
                BookId = details[0].BookId,
                OrderQuantity=1
            };
            var filter = Builders<Book>.Filter.Eq("BookId", bookId);
            var update = Builders<Book>.Update.Set("IsAddedToCart", true);
            _Book.UpdateOne(filter, update);
            this._Cart.InsertOne(cart);
            return cart;
        }

        public bool DeleteFromCart(string cartId)
        {
            List<Cart> details = this._Cart.Find(book => book.CartId == cartId).ToList();
            var filter = Builders<Book>.Filter.Eq("BookId", details[0].BookId);
            var update = Builders<Book>.Update.Set("IsAddedToCart", false);
            _Book.UpdateOne(filter, update);
            this._Cart.DeleteOne(cart => cart.CartId == cartId);
            return true;
        }

        public dynamic GetAllCarts(string userId)
        {
            try
            {
                var query = from c in _Cart.AsQueryable()
                            join b in _Book.AsQueryable()
                            on c.BookId equals b.BookId into newItem
                            where c.UserId == userId
                            select new
                            {
                                CartId = c.CartId,
                                BookId = c.BookId,
                                BookName = newItem.First().BookName,
                                AuthorName = newItem.First().AuthorName,
                                Price = newItem.First().Price,
                                OrderQuantity = c.OrderQuantity,
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

        public bool UpdateCart(string cartId, CartModel cartModel)
        {
            var filter = Builders<Cart>.Filter.Eq("CartId", cartId);
            var update = Builders<Cart>.Update.Set("OrderQuantity", cartModel.OrderQuantity);
            _Cart.UpdateOne(filter, update);
            return true;
        }

        public bool IncreaseQuantity(string bookId, string userId)
        {
            try
            {
                List<Cart> list1 = this._Cart.Find<Cart>(book => book.BookId == bookId && book.UserId == userId).ToList();
                int quantity = list1[0].OrderQuantity + 1;
                if (list1.Count == 0)
                {
                    return false;
                }
                else
                {
                    var filter = Builders<Cart>.Filter.Eq("BookId", bookId);
                    var update = Builders<Cart>.Update.Set("OrderQuantity", quantity);
                    _Cart.UpdateOne(filter, update);
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool DecreaseQuantity(string bookId, string userId)
        {

            try
            {
                List<Cart> list1 = this._Cart.Find<Cart>(book => book.BookId == bookId && book.UserId == userId).ToList();

                if (list1[0].OrderQuantity <= 1)
                {
                    return false;
                }

                int quantity = list1[0].OrderQuantity - 1;
                if (list1.Count == 0)
                {
                    return false;
                }
                else
                {
                    var filter = Builders<Cart>.Filter.Eq("BookId", bookId);
                    var update = Builders<Cart>.Update.Set("OrderQuantity", quantity);
                    _Cart.UpdateOne(filter, update);
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
