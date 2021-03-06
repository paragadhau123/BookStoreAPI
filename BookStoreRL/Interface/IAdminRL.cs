﻿using BookStoreCL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRL.Interface
{
    public interface IAdminRL
    {
        bool RegisterAdmin(AdminModel adminModel);

        Admin LoginAdmin(AdminLoginModel adminLoginModel);

        string ForgetPassword(AdminForgetPasswordModel adminForgetPasswordModel);

        bool ResetPassword(AdminResetPasswordModel adminResetPasswordModel, string adminId);

        bool DeleteAdminById(string id);

        bool UpdateAdminDetails(string id, Admin admin);
    }
}
