using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Entities
{
    public class HopDong
    {
        public string maHopDong { get; set; }
        public int idLoaiHopDong { get; set; }
        public int idChucDanh { get; set; }
        public float? luongCoBan { get; set; }
        public DateTime? hopDongTuNgay { get; set; }
        public DateTime? hopDongDenNgay { get; set; }
        public string ghiChu { get; set; }
        public string maNhanVien { get; set; }

        public NhanVien NhanVien { get; set; }
        public List<Luong> Luongs { get; set; }
        public DanhMucLoaiHopDong DanhMucLoaiHopDong { get; set; }
        public DanhMucChucDanh DanhMucChucDanh { get; set; }
    }
}