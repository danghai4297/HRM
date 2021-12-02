using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.DanhMucTos.Dtos
{
    public class DanhMucToViewModel
    {
        public int id { get; set; }
        public string maTo { get; set; }
        public string tenTo { get; set; }
        public int idPhongBan { get; set; }
        public string tenPhongBan { get; set; }
        public string trangThai { get; set; }
    }
}
