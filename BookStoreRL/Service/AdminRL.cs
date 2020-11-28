using BookStoreCL.Models;
using BookStoreRL.Interface;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
                    AdminRole=adminModel.AdminRole
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
            admin.AdminRole = validation[0].AdminRole;
            admin.AdminGender = validation[0].AdminGender;
            admin.Token = CreateToken(admin, "authenticate Admin role");

            return admin; 
        }

        private string CreateToken(Admin responseModel, string type)
        {
            try
            {
                var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecretKey@345fghhhhhhhhhhhhhhhhhhhhhhhhhhhhhfggggggg"));
                var signinCredentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Role, responseModel.AdminRole),

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


    }
}
