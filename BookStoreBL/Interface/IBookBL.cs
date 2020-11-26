using BookStoreCL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBL.Interface
{
    public interface IBookBL
    {
      public bool AddBook(BookModel bookModel);
    }
}
