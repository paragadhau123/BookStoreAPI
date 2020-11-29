using BookStoreBL.Interface;
using BookStoreCL;
using BookStoreCL.Models;
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

        public string ForgetPassword(UserForgetPasswordModel userForgetPasswordModel)
        {
            return this.userRL.ForgetPassword(userForgetPasswordModel);
        }

        public List<User> GetAllUserDetails()
        {
            return this.userRL.GetAllUserDetails();
        }

        public User LoginAdmin(UserLoginModel userLoginModel)
        {
            return this.userRL.LoginAdmin(userLoginModel);
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
