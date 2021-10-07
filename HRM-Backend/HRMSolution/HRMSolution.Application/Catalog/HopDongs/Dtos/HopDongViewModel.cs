using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.HopDongs.Dtos
{
    public class HopDongViewModel
    {
        public string maHopDong { get; set; }
        public string idLoaiHopDong { get; set; }
        public string idChucDanh { get; set; }

        public DateTime? hopDongTuNgay { get; set; }
        public DateTime? hopDongDenNgay { get; set; }
        public string ghiChu { get; set; }
        public string maNhanVien { get; set; }
        public string tenNhanVien { get; set; }
    }
}
