using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.TaiKhoan.Dtos
{
    public class AccountUpdateRequest
    {
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
        public string confirmPassword { get; set; }
    }
}
