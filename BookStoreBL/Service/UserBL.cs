using BookStoreBL.Interface;
using BookStoreCL;
using BookStoreRL;
using BookStoreRL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBL.Service
{
    public class UserBL : IUserBL
    {
        public IUserRL userRL;

        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }

        public bool DeleteUserById(string id)
        {
            return this.userRL.DeleteUserById(id);
        }

        public List<User> GetAccountsDetails()
        {
            return this.userRL.GetAccountsDetails();
        }

        public bool RegisterUser(UserModel userModel)
        {
            return this.userRL.RegisterUser(userModel);
        }

        public bool UpdateAccountDetails(string id, User user)
        {
            return this.userRL.UpdateAccountDetails(id,user);
        }
    }
}
