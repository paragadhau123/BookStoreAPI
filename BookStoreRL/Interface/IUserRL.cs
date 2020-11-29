using BookStoreCL;
using BookStoreCL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRL.Interface
{
    public interface IUserRL
    {
      public bool RegisterUser(UserModel userModel);

       public List<User> GetAllUserDetails();

       public bool DeleteUserById(string id);

       public bool UpdateAccountDetails(string id, User user);

       User LoginAdmin(UserLoginModel userLoginModel);
        string ForgetPassword(UserForgetPasswordModel userForgetPasswordModel);
    }
}
