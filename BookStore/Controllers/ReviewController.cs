using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreBL.Interface;
using BookStoreRL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {

        private IReviewBL bussinessLayer;
        public ReviewController(IReviewBL bussinessLayer)
        {
            this.bussinessLayer = bussinessLayer;
        }



        [HttpPost("{bookId:}")]
        [Authorize(Roles = "User")]

        public IActionResult AddReview(string bookId, review review)
        {
            try
            {
                string userId = this.GetUserId();
                var result = this.bussinessLayer.AddReview(bookId, userId, review);
                return this.Ok(new { success = true, message = "Review Updated", data = result });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message });
            }
        }



        [HttpGet("{bookId:}")]
        [Authorize(Roles = "User")]
        public IActionResult getReview(string bookId)
        {
            try
            {

                var result = this.bussinessLayer.getReview(bookId);
                if (result.Count == 0)
                    return this.Ok(new { success = true, message = "No Review Of This Book", data = result });
                else
                    return this.Ok(new { success = true, data = result });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message });
            }
        }

        private string GetUserId()
        {
            return User.FindFirst("Id").Value;
        }
    }
}
