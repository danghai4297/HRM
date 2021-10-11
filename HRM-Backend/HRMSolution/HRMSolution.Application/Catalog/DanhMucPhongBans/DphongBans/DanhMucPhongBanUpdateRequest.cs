using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.DanhMucPhongBans.DphongBans
{
    public class DanhMucPhongBanUpdateRequest
    {
        public int id { get; set; }
        public string maPhongBan { get; set; }
        public string tenPhongBan { get; set; }
    }
}
