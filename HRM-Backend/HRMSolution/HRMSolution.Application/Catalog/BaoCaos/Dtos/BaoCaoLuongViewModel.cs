using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.BaoCaos.Dtos
{
    public class BaoCaoLuongViewModel
    {
        public string maNhanVien { get; set; }
        public string tenNhanVien { get; set; }
        public string tenPhongBan { get; set; }
        public string tenTo { get; set; }
        public string atm { get; set; }
        public string nganHang { get; set; }
        public int idLuong { get; set; }
        public string maHopDong { get; set; }
        public string tenNhomLuong { get; set; }
        public float heSoLuong { get; set; }
        public string bacLuong { get; set; }
        public float luongCoBan { get; set; }
        public float phuCapChucVu { get; set; }
        public float phuCapChucDanh { get; set; }
        public float? phuCapTrachNhiem { get; set; }
        public float? phuCapKhac { get; set; }
        public float tongLuong { get; set; }
        public string thoiHanLenLuong { get; set; }
        public DateTime ngayHieuLuc { get; set; }
        public DateTime ngayKetThuc { get; set; }
        public string ghiChu { get; set; }
    }
}
