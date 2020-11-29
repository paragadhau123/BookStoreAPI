using BookStoreCL.Models;
using BookStoreRL.Interface;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;

namespace BookStoreRL.Service
{
    public class AdminRL : IAdminRL
    {
        private readonly IMongoCollection<Admin> _Admin;

        public AdminRL(IBookStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            this._Admin = database.GetCollection<Admin>(settings.AdminCollectionName);
        }


        public bool RegisterAdmin(AdminModel adminModel)
        {
            try
            {
                Admin admin = new Admin()
                {
                    AdminName=adminModel.AdminName,
                    AdminEmailId=adminModel.AdminEmailId,
                    AdminPassword=adminModel.AdminPassword,
                    AdminGender=adminModel.AdminGender,
                };
                this._Admin.InsertOne(admin);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public Admin LoginAdmin(AdminLoginModel adminLoginModel)
        {
            List<Admin> validation = _Admin.Find(admin => admin.AdminEmailId == adminLoginModel.AdminEmailId && admin.AdminPassword == adminLoginModel.AdminPassword).ToList();
            Admin admin = new Admin();
            admin.AdminId = validation[0].AdminId;
            admin.AdminName = validation[0].AdminName;
            admin.AdminEmailId = validation[0].AdminEmailId;
            admin.AdminGender = validation[0].AdminGender;
            admin.Token = CreateToken(admin, "Admin");

            return admin; 
        }

        private string CreateToken(Admin responseModel, string role)
        {
            try
            {
                var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecretKey@345fghhhhhhhhhhhhhhhhhhhhhhhhhhhhhfggggggg"));
                var signinCredentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Role, role),

                            new Claim("email", responseModel.AdminEmailId.ToString() ),

                            new Claim("id",responseModel.AdminId.ToString()),

                        };
                var tokenOptionOne = new JwtSecurityToken(

                    claims: claims,
                    expires: DateTime.Now.AddMinutes(130),
                    signingCredentials: signinCredentials
                    );
                string token = new JwtSecurityTokenHandler().WriteToken(tokenOptionOne);
                return token;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ForgetPassword(AdminForgetPasswordModel adminForgetPasswordModel)
        {
                List<Admin> details = this._Admin.Find(admin => admin.AdminEmailId == adminForgetPasswordModel.AdminEmailId).ToList();
                Admin admin = new Admin();
                admin.AdminEmailId = details[0].AdminEmailId;
                admin.AdminId = details[0].AdminId;
                string Token = CreateToken(admin, "Admin");


                String body = "http://localhost:4200/resetPassword/" + Token;
                MailMessage mailMessage = new MailMessage(adminForgetPasswordModel.AdminEmailId, adminForgetPasswordModel.AdminEmailId);
                mailMessage.Subject = "reset password";
                mailMessage.Body = body;
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential()
                {
                UserName = adminForgetPasswordModel.AdminEmailId,
                Password = "parag123#"
                };
                smtpClient.EnableSsl = true;

                smtpClient.Send(mailMessage);
                return Token;           
        }

        public bool ResetPassword(AdminResetPasswordModel adminResetPasswordModel, string adminId)
        {
            var filter = Builders<Admin>.Filter.Eq("AdminId", adminId);
            var update = Builders<Admin>.Update.Set("AdminPassword", adminResetPasswordModel.AdminNewPassword);
            _Admin.UpdateOne(filter, update);
            return true;
        }

        public bool DeleteAdminById(string id)
        {
            try
            {
                this._Admin.DeleteOne(admin => admin.AdminId == id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateAdminDetails(string id, Admin admin)
        {
            try
            {
                this._Admin.ReplaceOne(admin => admin.AdminId == id, admin);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
