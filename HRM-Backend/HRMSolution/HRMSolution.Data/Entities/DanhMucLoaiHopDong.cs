using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Entities
{
    public class DanhMucLoaiHopDong
    {
        public int id { get; set; }
        public string maLoaiHopDong { get; set; }
        public string tenLoaiHopDong { get; set; }
        public List<HopDong> hopDongs { get; set; }
    }
}
