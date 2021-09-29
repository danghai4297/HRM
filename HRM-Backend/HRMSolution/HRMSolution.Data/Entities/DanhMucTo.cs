using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Entities
{
    public class DanhMucTo
    {
        public int idTo { get; set; }
        public string maTo { get; set; }
        public string tenTo { get; set; }
        public int idPhongBan { get; set; }
        public DanhMucPhongBan DanhMucPhongBan { get; set; }
    }
}
