using BookStoreCL.Models;
using BookStoreRL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBL.Interface
{
    public interface IAdminBL
    {
        bool RegisterAdmin(AdminModel adminModel);

        Admin LoginAdmin(AdminLoginModel adminLoginModel);


        string ForgetPassword(AdminForgetPasswordModel adminForgetPasswordModel);

        bool ResetPassword(AdminResetPasswordModel adminResetPasswordModel, string adminId);
    }
}
