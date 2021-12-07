using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.BaoCaos.Dtos
{
    public class BaoCaoLenLuongViewModel
    {
        public string id { get; set; }
        public string hoTen { get; set; }
        public string maHopDong { get; set; }
        public string tenHopDong { get; set; }
        public float? luongCoBan { get; set; }
        public float? tongLuong { get; set; }
        public DateTime? thoiGianLenLuong { get; set; }
        public string tenPhongBan { get; set; }
    }
}
