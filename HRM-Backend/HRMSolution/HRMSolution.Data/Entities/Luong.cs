using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Entities
{
    public class Luong
    {
        public int id { get; set; }
        public string maHopDong { get; set; }
        public int? nhomLuong { get; set; }
        public float? heSoLuong { get; set; }
        public string bacLuong { get; set; }
        public float? luongCoBan { get; set; }
        public float? phuCapTrachNhiem { get; set; }
        public float? phuCapKhac { get; set; }
        public float? tongLuong { get; set; }
        public string thoiHanLenLuong { get; set; }
        public DateTime? ngayHieuLuc { get; set; }
        public DateTime? ngayKetThuc { get; set; }
        public string ghiChu { get; set; }

        public HopDong HopDong { get; set; }
    }
}
