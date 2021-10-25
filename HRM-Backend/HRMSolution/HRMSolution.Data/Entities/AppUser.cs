using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string hoTen { get; set; }
        public DateTime ngaySinh { get; set; }
    }
}
