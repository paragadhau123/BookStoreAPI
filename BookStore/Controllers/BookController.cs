using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreBL.Interface;
using BookStoreCL.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        public IBookBL bookBL;
         
        [HttpPost("AddBook")]
        public IActionResult AddBook(BookModel bookModel)
        {
            try
            {
                bool result = this.bookBL.AddBook(bookModel);

                if (!result.Equals(false))
                {
                    return this.Ok(new { sucess = true, message = "Book Added Succesfully" });
                }
                else
                {
                    return this.BadRequest(new { sucess = false, message = "Book Not Added" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { sucess = false, message = e.Message });
            }
        }
    }
}
