using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.TaiKhoan.Dtos
{
    public class CreateAccountRequest
    {
        public string maNhanVien { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
