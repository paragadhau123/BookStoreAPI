using BookStoreCL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRL.Interface
{
    public interface IUserRL
    {
      public bool RegisterUser(UserModel userModel);

       public List<User> GetAccountsDetails();

       public bool DeleteUserById(string id);
       public bool UpdateAccountDetails(string id, User user);
    }
}
