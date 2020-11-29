using BookStoreBL.Interface;
using BookStoreCL.Models;
using BookStoreRL;
using BookStoreRL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBL.Service
{
    public class AdminBL : IAdminBL
    {
        public IAdminRL adminRL;

        public AdminBL(IAdminRL adminRL)
        {
            this.adminRL = adminRL;
        }

        public string ForgetPassword(AdminForgetPasswordModel adminForgetPasswordModel)
        {
            return this.adminRL.ForgetPassword(adminForgetPasswordModel);
        }

        public Admin LoginAdmin(AdminLoginModel adminLoginModel)
        {
            return this.adminRL.LoginAdmin(adminLoginModel);
        }

        public bool RegisterAdmin(AdminModel adminModel)
        {
            return this.adminRL.RegisterAdmin(adminModel);
        }
    }
}
