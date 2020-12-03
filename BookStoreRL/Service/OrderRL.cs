using BookStoreCL.Models;
using BookStoreRL.Interface;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRL.Service
{
    public class OrderRL : IOrderRL
    {

        private readonly IMongoCollection<Cart> _Cart;
        private readonly IMongoCollection<Order> _Order;
        private readonly IMongoCollection<Book> _Book;

        public OrderRL(IBookStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _Cart = database.GetCollection<Cart>(settings.CartCollectionName);
            _Order = database.GetCollection<Order>(settings.OrderCollectionName);
            _Book = database.GetCollection<Book>(settings.BooksCollectionName);
        }
        public Order BookOrder(string userId, string cartId, OrderModel orderModel)
        {
            List<Cart> details = this._Cart.Find(cart => cart.CartId == cartId).ToList();
            List<Book> books = this._Book.Find(book => book.BookId == details[0].BookId).ToList();
            Order order = new Order()
            {
                CartId = cartId,
                UserId = userId,
                BookId = details[0].BookId,
                TotalPrice = books[0].Price,
                City = orderModel.City,
                State = orderModel.State,
                Country = orderModel.Country,
                Pincode = orderModel.Pincode
            };
            this._Order.InsertOne(order);

            return order;
        }

        public bool DeleteOrder(string orderId)
        {
            this._Order.DeleteOne(order => order.OrderId == orderId);
            return true;
        }

        public List<Order> GetAllOrders(string userId)
        {
            return this._Order.Find(order => order.UserId==userId).ToList();
        }

        public List<Order> OrderAllBook(string userId, OrderModel orderModel)
        {
            List<Cart> details = this._Cart.Find(cart => cart.UserId == userId).ToList();
            for (int i = 0; i < details.Count; i++)
            {
                List<Book> books = this._Book.Find(book => book.BookId == details[i].BookId).ToList();
                Order order = new Order()
                {
                    CartId = details[i].CartId,
                    UserId = userId,
                    BookId = details[i].BookId,
                    City = orderModel.City,
                    State = orderModel.State,
                    Country = orderModel.Country,
                    Pincode = orderModel.Pincode
                };
                this._Order.InsertOne(order);
            }
            return this._Order.Find(order => order.UserId == userId).ToList();
        }
    }
}
 