using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreBL.Interface;
using BookStoreCL.Models;
using BookStoreRL;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public IAdminBL adminBL;

        public AdminController(IAdminBL adminBL)
        {
            this.adminBL = adminBL;
        }

        [HttpPost("RegisterAdmin")]
        public IActionResult RegisterAdmin(AdminModel adminModel)
        {
            try
            {
                bool result = this.adminBL.RegisterAdmin(adminModel);

                if (!result.Equals(false))
                {
                    return this.Ok(new { sucess = true, message = "Admin Added Succesfully" });
                }
                else
                {
                    return this.BadRequest(new { sucess = false, message = "Admin Not Added" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { sucess = false, message = e.Message });
            }
        }

        [HttpPost("AdminLogin")]
        public IActionResult LoginAdmin(AdminLoginModel adminLoginModel)
        {
            try
            {
                if (adminLoginModel != null)
                {
                    Admin Data = adminBL.LoginAdmin(adminLoginModel);
                    if (Data != null)
                    {
                        return Ok(new { Success = true, Message = " Admin Login Successful", Data });
                    }
                    else
                    {
                        return BadRequest(new { Success = false, Message = "Wrong Email or Password" });
                    }
                }
                else
                {
                    return BadRequest(new { Success = false, Message = "Invalid credentials" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { Success = false, message = e.Message });
            }

        }

        [HttpPost("AdminForgetPassword")]
        public IActionResult ForgetPassword(AdminForgetPasswordModel adminForgetPasswordModel)
        {
            try
            {
                if (adminForgetPasswordModel != null)
                {
                    string result = adminBL.ForgetPassword(adminForgetPasswordModel);
                    return Ok(new { success = true, Message = "Reset password link has been sent to your email" });
                }
                else
                {
                    return BadRequest(new { Suceess = false, Meassage = "Email field can not be empty" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { Suceess = false, Meassage = e.Message });
            }
        }


        [HttpPost("AdminResetPassword")]
        public IActionResult ResetPassword(AdminResetPasswordModel adminResetPasswordModel)
        {
            try
            {
                if (adminResetPasswordModel != null)
                {
                    string adminId = this.GetAdminId();
                    bool pass = this.adminBL.ResetPassword(adminResetPasswordModel, adminId);
                    return this.Ok(new { Success = true, Message = "Password is changed succesfully" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, Message = "NewPassword can not be empty" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message });
            }
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult DeleteAdminById(string id)
        {
            try
            {
                bool result = this.adminBL.DeleteAdminById(id);

                if (!result.Equals(false))
                {
                    return this.Ok(new { sucess = true, message = "Admin Deleted Succesfully" });
                }
                else
                {
                    return this.NotFound(new { sucess = false, message = "No Admin To Delete" });
                }
            }
            catch (Exception e)
            {
                bool success = false;
                return this.BadRequest(new { success, message = e.Message });
            }

        }

        [HttpPut("{id:length(24)}")]
        public IActionResult UpdateAdminDetails(string id, Admin admin)
        {
            try
            {
                bool result = this.adminBL.UpdateAdminDetails(id, admin);

                if (!result.Equals(false))
                {
                    return this.Ok(new { sucess = true, message = "Admin Details Updated Succesfully" });
                }
                else
                {
                    return this.NotFound(new { sucess = false, message = "No Admin To Updated" });
                }
            }
            catch (Exception e)
            {
                bool success = false;
                return this.BadRequest(new { success, message = e.Message });
            }
        }
        private string GetAdminId()
        {
            return User.FindFirst("Id").Value;
        }
    }
}
