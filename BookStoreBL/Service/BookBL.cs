using BookStoreBL.Interface;
using BookStoreCL.Models;
using BookStoreRL;
using BookStoreRL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBL.Service
{
    public class BookBL : IBookBL
    {
        public IBookRL bookRL;

        public BookBL(IBookRL bookRL)
        {
            this.bookRL = bookRL;
        }
        public bool AddBook(BookModel bookModel)
        {
            return this.bookRL.AddBook(bookModel);
        }

        public bool DeleteBookById(string id)
        {
            return this.bookRL.DeleteBookById(id);
        }

        public List<Book> GetAllBooks()
        {
            return this.bookRL.GetAllBooks();
        }

        public List<Book> SerchBookByID(string id)
        {
            return this.bookRL.SerchBookByID(id);
        }

        public List<Book> SortBooks()
        {
            return this.bookRL.SortBooks();
        }

        public List<Book> SortHighToLow()
        {
            return this.bookRL.SortHighToLow();
        }

        public bool UpdateBookDetails(string id, Book book)
        {
            return this.bookRL.UpdateBookDetails(id,book);
        }
    }
}
