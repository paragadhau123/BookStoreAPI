using BookStoreCL;
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
    public class UserRL : IUserRL
    {
        private readonly IMongoCollection<User> _User;

        public UserRL(IBookStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            this._User = database.GetCollection<User>(settings.UsersCollectionName);
        }

        public bool DeleteUserById(string id)
        {
            try
            {
                this._User.DeleteOne(user => user.Id == id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<User> GetAllUserDetails()
        {
            return this._User.Find(user => true).ToList();
        }

        public User LoginAdmin(UserLoginModel userLoginModel)
        {
            List<User> validation = _User.Find(user => user.EmailId == userLoginModel.UserEmailId && user.Password == userLoginModel.UserPassword).ToList();
            User user = new User();
            user.Id = validation[0].Id;
            user.FirstName = validation[0].FirstName;
            user.LastName = validation[0].LastName;
            user.EmailId = validation[0].EmailId;
            user.PhoneNumber = validation[0].PhoneNumber;
            user.Gender = validation[0].Gender;
            user.Token= CreateToken(user, "User");

            return user;
        }

        private string CreateToken(User responseModel, string role)
        {
            try
            {
                var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecretKey@345fghhhhhhhhhhhhhhhhhhhhhhhhhhhhhfggggggg"));
                var signinCredentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Role, role),

                            new Claim("email", responseModel.EmailId.ToString() ),

                            new Claim("id",responseModel.Id.ToString()),

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

        public bool RegisterUser(UserModel userModel)
        {
            try
            {
                User user = new User()
                {
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    Gender = userModel.Gender,
                    EmailId = userModel.EmailId,
                    PhoneNumber = userModel.PhoneNumber,
                    Password = userModel.Password,
                  //  Role="User",
                    RegistrationDate = userModel.RegistrationDate
                };
                this._User.InsertOne(user);
                return true;
            }
            catch
            {
                return false;
            }
           
        }

        public bool UpdateAccountDetails(string id, User user)
        {
            try
            {
                this._User.ReplaceOne(user => user.Id == id, user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string ForgetPassword(UserForgetPasswordModel userForgetPasswordModel)
        {
            List<User> details = this._User.Find(user => user.EmailId == userForgetPasswordModel.EmailId).ToList();
            User user = new User();
            user.EmailId = details[0].EmailId;
            user.Id = details[0].Id;
            string Token = CreateToken(user, "User");


            String body = "http://localhost:4200/resetPassword/" + Token;
            MailMessage mailMessage = new MailMessage(userForgetPasswordModel.EmailId, userForgetPasswordModel.EmailId);
            mailMessage.Subject = "reset password";
            mailMessage.Body = body;
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential()
            {
                UserName = userForgetPasswordModel.EmailId,
                Password = "parag123#"
            };
            smtpClient.EnableSsl = true;

            smtpClient.Send(mailMessage);
            return Token;
        }

        public bool ResetPassword(UserResetPasswordModel userResetPasswordModel, string userId)
        {
            var filter = Builders<User>.Filter.Eq("Id", userId);
            var update = Builders<User>.Update.Set("Password", userResetPasswordModel.NewPassword);
            _User.UpdateOne(filter, update);
            return true;
        }
    }
}
  