using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreBL.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        public IWishListBL wishlistBL;

        public WishListController(IWishListBL wishlistBL)
        {
            this.wishlistBL = wishlistBL;
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        [Route("")]
        public IActionResult AddWishList(string BookId)
        {
            try
            {
                string userId = this.GetUserId();
                var data = this.wishlistBL.AddBookToWishList(userId, BookId);
                if (data != null)
                {
                    return this.Ok(new { status = "True", message = "Book Added To WishList Successfully", data });
                }
                else
                {
                    return this.BadRequest(new { status = "False", message = "Failed To Add WishList" });
                }
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Authorize(Roles = "User")]
        public IActionResult GetAllWishListValues()
        {
            try
            {
                string userId = this.GetUserId();
                // Call the GetAllWishListValues Method of Cart class
                var response = this.wishlistBL.GetAllWishListValues(userId);

                // check if Id is not equal to zero
                if (!response.Equals(null))
                {
                    bool status = true;
                    var message = "WishList Data Read Successfully";
                    return this.Ok(new { status, message, data = response });
                }
                else
                {
                    bool status = false;
                    var message = "WishList is Empty";
                    return this.NotFound(new { status, message });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { status = false, message = e.Message });
            }
        }
        private string GetUserId()
        {
            return User.FindFirst("Id").Value;
        }
    }
}
