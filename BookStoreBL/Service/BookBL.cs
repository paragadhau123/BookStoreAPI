using BookStoreBL.Interface;
using BookStoreCL.Models;
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
    }
}
