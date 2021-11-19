using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HRMSolution.Application.System.Users.Dtos
{
    public class UserVm
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string maNhanVien { get; set; }


        public DateTime Dob { get; set; }

        public IList<string> Roles { get; set; }
    }
}
