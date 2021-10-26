using HRMSolution.Application.System.Users.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.System.Users.Dtos
{
    public class RoleAssignRequest
    {
        public Guid Id { get; set; }
        public List<SelectItem> Roles { get; set; } = new List<SelectItem>();
    }
}
