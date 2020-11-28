using BookStoreCL.Models;
using BookStoreRL.Interface;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRL.Service
{
    public class AdminRL : IAdminRL
    {
        private readonly IMongoCollection<Admin> _User;

        public AdminRL(IBookStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            this._Admin = database.GetCollection<Admin>(settings.UsersCollectionName);
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
                    AdminGender=adminModel.AdminGender
                };
                this._Admin.InsertOne(admin);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
