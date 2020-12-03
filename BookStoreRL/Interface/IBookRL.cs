using BookStoreCL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRL.Interface
{
    public interface IBookRL
    {
       public bool AddBook(BookModel bookModel);

        public List<Book> GetAllBooks();

       public bool DeleteBookById(string id);

       public  bool UpdateBookDetails(string id, Book book);

       public List<Book> SerchBookByID(string id);

       List<Book> SortBooks();

       List<Book> SortHighToLow();
    }
}
