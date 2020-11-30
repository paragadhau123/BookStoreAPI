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

        public bool DeleteAdminById(string id)
        {
            return this.adminRL.DeleteAdminById(id);
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

        public bool ResetPassword(AdminResetPasswordModel adminResetPasswordModel, string adminId)
        {
            return this.adminRL.ResetPassword(adminResetPasswordModel, adminId);
        }

        public bool UpdateAdminDetails(string id, Admin admin)
        {
            return this.adminRL.UpdateAdminDetails(id, admin);
        }
    }
}
