using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreBL.Interface;
using BookStoreCL.Models;
using BookStoreRL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class BookController : ControllerBase
    {
        public IBookBL bookBL;

        public BookController(IBookBL bookBL)
        {
            this.bookBL = bookBL;
        }


       
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

        [HttpGet("GetAllBooks")]
        [AllowAnonymous]
        public IActionResult GetAllBooks()
        {
            try
            {

                var result = this.bookBL.GetAllBooks();
                if (!result.Equals(null))
                {
                    return this.Ok(new { sucess = true, message = "All Books are displayed below succesfully", data = result });
                }
                else
                {
                    return this.NotFound(new { sucess = true, message = "No Books Are Present" });
                }
            }
            catch (Exception e)
            {
                bool success = false;
                return this.BadRequest(new { success, message = e.Message });
            }
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult DeleteBookById(string id)
        {
            try
            {
                bool result = this.bookBL.DeleteBookById(id);

                if (!result.Equals(false))
                {
                    return this.Ok(new { sucess = true, message = "Book Deleted Succesfully" });
                }
                else
                {
                    return this.NotFound(new { sucess = false, message = "No Such Book To Delete" });
                }
            }
            catch (Exception e)
            {
                bool success = false;
                return this.BadRequest(new { success, message = e.Message });
            }

        }

        [HttpPut("{id:length(24)}")]
        public IActionResult UpdateBookDetails(string id, Book book)
        {
            try
            {
                bool result = this.bookBL.UpdateBookDetails(id, book);

                if (!result.Equals(false))
                {
                    return this.Ok(new { sucess = true, message = "Book Details Updated Succesfully" });
                }
                else
                {
                    return this.NotFound(new { sucess = false, message = "No Such Book To Updated" });
                }
            }
            catch (Exception e)
            {
                bool success = false;
                return this.BadRequest(new { success, message = e.Message });
            }

        }

        [HttpGet("{id:length(24)}")]
        [AllowAnonymous]
        public IActionResult SerchBookByID(string id)
        {
            try
            {
                var result = this.bookBL.SerchBookByID(id);

                if (!result.Equals(null))
                {
                    return this.Ok(new { sucess = true, message = "Book details are displayed below",data=result });
                }
                else
                {
                    return this.NotFound(new { sucess = false, message = "No Such Book" });
                }
            }
            catch (Exception e)
            {
                bool success = false;
                return this.BadRequest(new { success, message = e.Message });
            }

        }
    }
}
