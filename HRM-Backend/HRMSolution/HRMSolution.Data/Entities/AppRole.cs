using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Entities
{
    public class AppRole : IdentityRole<Guid>
    {
        public string ghiChu { get; set; }
    }
}
