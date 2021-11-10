using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HRMSolution.Application.System.Users.Dtos
{
    public class UserVm
    {
        public Guid Id { get; set; }

        [Display(Name = "Họ Tên")]
        public string FullName { get; set; }

        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Tài khoản")]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Mã nhân viên")]
        public string maNhanVien { get; set; }
        [Display(Name = "Mật Khẩu")]
        public string password { get; set; }

        [Display(Name = "Ngày sinh")]
        public DateTime Dob { get; set; }

        public IList<string> Roles { get; set; }
    }
}
