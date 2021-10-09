using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.NhanViens.Dtos
{
    public class HopDongViewModel
    {
        public string maHopDong { get; set; }
        public float? luongCoBan { get; set; }
        public DateTime? hdHopDongTuNgay { get; set; }
        public DateTime? hdHopDongDenNgay { get; set; }
        public string hdGhiChu { get; set; }
        public string trangThai { get; set; }
        public List<LuongViewModel> luongs { get; set; }
    }
}
