using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.TaiKhoan.Dtos
{
    public class RoleAssignRequest
    {
        public Guid Id { get; set; }
        public List<SelectItem> Roles { get; set; } = new List<SelectItem>();
    }
}
