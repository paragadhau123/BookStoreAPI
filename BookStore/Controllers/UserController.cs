﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreBL.Interface;
using BookStoreCL;
using BookStoreRL;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserBL userBL;

        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }

        [HttpPost("RegisterUser")]
        public IActionResult RegisterUser(UserModel userModel)
        {
            try
            {
                bool result = this.userBL.RegisterUser(userModel);

                if (!result.Equals(false))
                {
                    return this.Ok(new { sucess = true, message = "User Added Succesfully" });
                }
                else
                {
                    return this.BadRequest(new { sucess = false, message = "User Not Added" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { sucess = false, message = e.Message });
            }
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetAllAccountsDetails()
        {
            try
            {

                var result = this.userBL.GetAccountsDetails();
                if (!result.Equals(null))
                {
                    return this.Ok(new { sucess = true, message = "All users are displayed below succesfully", data = result });
                }
                else
                {
                    return this.NotFound(new { sucess = true, message = "No Users Are Present" });
                }
            }
            catch (Exception e)
            {
                bool success = false;
                return this.BadRequest(new { success, message = e.Message });
            }
        }


        [HttpDelete("{id:length(24)}")]
        public IActionResult DeleteUserById(string id)
        {
            try
            {
                bool result = this.userBL.DeleteUserById(id);

                if (!result.Equals(false))
                {
                    return this.Ok(new { sucess = true, message = "User Deleted Succesfully" });
                }
                else
                {
                    return this.NotFound(new { sucess = false, message = "No User To Delete" });
                }
            }
            catch (Exception e)
            {
                bool success = false;
                return this.BadRequest(new { success, message = e.Message });
            }

        }

        [HttpPut("{id:length(24)}")]
        public IActionResult UpdateAccountDetails(string id, User user)
        {
            try
            {
                bool result = this.userBL.UpdateAccountDetails(id, user);

                if (!result.Equals(false))
                {
                    return this.Ok(new { sucess = true, message = "User Details Updated Succesfully" });
                }
                else
                {
                    return this.NotFound(new { sucess = false, message = "No User To Updated" });
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