using BookStoreCL.Models;
using BookStoreRL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBL.Interface
{
    public interface IBookBL
    {
      public bool AddBook(BookModel bookModel);

       public List<Book> GetAllBooks();

       public bool DeleteBookById(string id);

       public bool UpdateBookDetails(string id, Book book);

       public List<Book> SerchBookByID(string id);
    }
}
