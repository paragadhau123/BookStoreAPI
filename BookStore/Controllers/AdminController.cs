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
                    return Ok(new { success = true, Message = "Reset password link has been sent to your email",Token=result });
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
    }
}
