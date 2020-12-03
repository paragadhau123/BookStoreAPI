using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreBL.Interface;
using BookStoreCL.Models;
using BookStoreCL.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        public IOrderBL orderBL;

        public OrderController(IOrderBL orderBL)
        {
            this.orderBL = orderBL;
        }

        [HttpPost]
        [Route("")]
        [Authorize(Roles = "User")]
        public IActionResult BookOrder(string CartId)
        {
            try
            {
                string userId = this.GetUserId();
                var response = this.orderBL.BookOrder(userId, CartId);

                if (!response.Equals(null))
                {
                    bool status = true;
                    var message = "Order Book Successfully";
                    return this.Ok(new { status, message, data = response });
                }
                else
                {
                    bool status = false;
                    var message = "Failed To Book Order";
                    return this.BadRequest(new { status, message });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { status = false, message = e.Message });
            }
        }

        [HttpPost]
        [Route("OrderAll")]
        [Authorize(Roles = "User")]
        public IActionResult OrderAllBook()
        {
            try
            {
                string userId = this.GetUserId();
                var response = this.orderBL.OrderAllBook(userId);

                if (!response.Equals(null))
                {
                    bool status = true;
                    var message = "All Book Ordered Successfully";
                    return this.Ok(new { status, message, data = response });
                }
                else
                {
                    bool status = false;
                    var message = "Failed To Book Order";
                    return this.BadRequest(new { status, message });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { status = false, message = e.Message });
            }
        }

        [HttpDelete("{orderId:length(24)}")]
        [Authorize(Roles = "User")]
        public IActionResult DeleteOrder(string orderId)
        {
            try
            {
                bool response = this.orderBL.DeleteOrder(orderId);

                if (!response.Equals(null))
                {
                    bool status = true;
                    var message = "Order deleted Successfully";
                    return this.Ok(new { status, message});
                }
                else
                {
                    bool status = false;
                    var message = "Failed To delete Order";
                    return this.BadRequest(new { status, message });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { status = false, message = e.Message });
            }
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult GetAllCarts()
        {
            try
            {
                string userId = this.GetUserId();
                var response = this.orderBL.GetAllOrders(userId);
                if (!response.Equals(null))
                {
                    bool status = true;
                    var message = "Order Data Read Successfully";
                    return this.Ok(new { status, message, data = response });
                }
                else
                {
                    bool status = false;
                    var message = "No Order present";
                    return this.NotFound(new { status, message });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { status = false, message = e.Message });
            }
        }

        [HttpPost]
        [Route("AddAddress")]
        [Authorize(Roles = "User")]
        public IActionResult AddAddress(AddressModel addressModel )
        {
            try
            {
                string userId = this.GetUserId();
                var response = this.orderBL.AddAddress(userId, addressModel);

                if (!response.Equals(null))
                {
                    bool status = true;
                    var message = "Address Added Successfully";
                    return this.Ok(new { status, message, data = response });
                }
                else
                {
                    bool status = false;
                    var message = "Failed To Add Address";
                    return this.BadRequest(new { status, message });
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
