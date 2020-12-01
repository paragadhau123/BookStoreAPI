using BookStoreCL.Models;
using BookStoreRL.Interface;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool DeleteBookById(string id)
        {
            try
            {
                this._Book.DeleteOne(book => book.BookId == id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Book> GetAllBooks()
        {
            return this._Book.Find(book => true).ToList();
        }

        public List<Book> SerchBookByID(string id)
        {
            return this._Book.Find(book => book.BookId == id).ToList();
        }

        public List<Book> SortBooks()
        {           
          return _Book.AsQueryable().OrderBy(c => c.Price).ToList();           
        }

        public List<Book> SortHighToLow()
        {
            return _Book.AsQueryable().OrderByDescending(c => c.Price).ToList();
        }

        public bool UpdateBookDetails(string id, Book book)
        {
            try
            {
                this._Book.ReplaceOne(book => book.BookId == id, book);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
