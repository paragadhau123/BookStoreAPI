using BookStoreCL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRL.Interface
{
    public interface IBookRL
    {
      public bool AddBook(BookModel bookModel);
    }
}
