using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HRMSolution.Application.System.Users.Dtos
{
    public class RegisterRequest
    {
        public string maNhanVien { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
