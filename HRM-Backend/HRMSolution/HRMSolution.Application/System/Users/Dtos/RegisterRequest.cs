using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HRMSolution.Application.System.Users.Dtos
{
    public class RegisterRequest
    {
        public string maNhanVien { get; set; }
        [Display(Name = "Tài khoản")]
        public string UserName { get; set; }

        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Xác nhận mật khẩu")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}
