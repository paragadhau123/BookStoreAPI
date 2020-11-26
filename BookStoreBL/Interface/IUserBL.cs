using BookStoreCL;
using BookStoreRL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBL.Interface
{
    public interface IUserBL
    {
       public bool RegisterUser(UserModel userModel);
       public List<User> GetAllUserDetails();
       public bool DeleteUserById(string id);
       public bool UpdateAccountDetails(string id, User user);
    }
}
