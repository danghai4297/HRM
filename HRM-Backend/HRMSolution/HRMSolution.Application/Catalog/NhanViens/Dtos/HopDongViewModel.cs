using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.NhanViens.Dtos
{
    public class HopDongViewModel
    {
        public string id { get; set; }
        public string idLoaiHopDong { get; set; }
        public string idChucDanh { get; set; }
        public string idChucVu { get; set; }
        public DateTime? hdHopDongTuNgay { get; set; }
        public DateTime? hdHopDongDenNgay { get; set; }
        public string hdGhiChu { get; set; }
        public string trangThai { get; set; }
    }
}
