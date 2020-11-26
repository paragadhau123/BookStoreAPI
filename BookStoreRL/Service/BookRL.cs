using BookStoreCL.Models;
using BookStoreRL.Interface;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRL.Service
{
    public class BookRL : IBookRL
    {
        private readonly IMongoCollection<Book> _Book;

        public BookRL(IBookStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            this._Book = database.GetCollection<Book>(settings.BooksCollectionName);
        }

        public bool AddBook(BookModel bookModel)
        {
            try
            {
                Book book = new Book()
                {
                    BookName = bookModel.BookName,
                    AuthorName = bookModel.AuthorName,
                    Description = bookModel.Description,
                    Price = bookModel.Price,
                    Quantity = bookModel.Quantity,
                    Image = bookModel.Image
                };
                this._Book.InsertOne(book);
                return true;
            }
            catch
            {
                return false;
            }
           
        }
    }
}
