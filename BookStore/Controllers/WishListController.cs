﻿using System;
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
        [HttpPost("{BookId:length(24)}")]
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
                dynamic response = this.wishlistBL.GetAllWishListValues(userId);
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

        [HttpPost("MoveToCart/{WishListId:length(24)}")]
       // [Route("MoveToCart")]
        [Authorize(Roles = "User")]
        public IActionResult MoveToCart(string WishListId)
        {
            try
            {
                string userId = this.GetUserId();
                var response = this.wishlistBL.MoveToCart(userId, WishListId);             
                if (!response.Equals(null))
                {
                    bool status = true;
                    var message = "Successfully Move To Cart";
                    return this.Ok(new { status, message, data = response });
                }
                else
                {
                    bool status = false;
                    var message = "Failed To Move";
                    return this.NotFound(new { status, message });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { status = false, message = e.Message });
            }
        }

        [HttpDelete("{WishListId:length(24)}")]
        [Authorize(Roles = "User")]
        public IActionResult DeleteFromWishList(string WishListId)
        {
            try
            {
                bool result = this.wishlistBL.DeleteFromWishList(WishListId);

                if (!result.Equals(false))
                {
                    return this.Ok(new { sucess = true, message = "Deleted Succesfully" });
                }
                else
                {
                    return this.NotFound(new { sucess = false, message = "No Such WishList present To Delete" });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private string GetUserId()
        {
            return User.FindFirst("Id").Value;
        }
    }
}
