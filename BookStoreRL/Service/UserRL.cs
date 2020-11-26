using BookStoreCL;
using BookStoreRL.Interface;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

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
    }
}
  