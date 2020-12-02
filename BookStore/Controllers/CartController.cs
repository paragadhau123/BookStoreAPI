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
    public class CartController : ControllerBase
    {
        public ICartBL cartBL;

        public CartController(ICartBL cartBL)
        {
            this.cartBL = cartBL;
        }

        [Authorize(Roles = "User")]
        [HttpPost("{BookId:length(24)}")]
        public IActionResult AddWishList(string BookId)
        {
            try
            {
                string userId = this.GetUserId();
                var data = this.cartBL.AddBookToCart(userId, BookId);
                if (data != null)
                {
                    return this.Ok(new { status = "True", message = "Book Added To Cart Successfully", data });
                }
                else
                {
                    return this.BadRequest(new { status = "False", message = "Failed To Add Cart" });
                }
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }

        [HttpDelete("{CartId:length(24)}")]
        [Authorize(Roles = "User")]
        public IActionResult DeleteFromCart(string CartId)
        {
            try
            {
                bool result = this.cartBL.DeleteFromCart(CartId);

                if (!result.Equals(false))
                {
                    return this.Ok(new { sucess = true, message = "Deleted Succesfully" });
                }
                else
                {
                    return this.NotFound(new { sucess = false, message = "No Such Cart present To Delete" });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Authorize(Roles = "User")]
        public IActionResult GetAllCarts()
        {
            try
            {
                string userId = this.GetUserId();
                var response = this.cartBL.GetAllCarts(userId);
                if (!response.Equals(null))
                {
                    bool status = true;
                    var message = "Carts Data Read Successfully";
                    return this.Ok(new { status, message, data = response });
                }
                else
                {
                    bool status = false;
                    var message = "Carts are Empty";
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
