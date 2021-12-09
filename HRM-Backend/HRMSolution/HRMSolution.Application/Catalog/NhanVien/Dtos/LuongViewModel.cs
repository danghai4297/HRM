﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.NhanViens.Dtos
{
    public class LuongViewModel
    {
        public int id { get; set; }
        public string maHopDong { get; set; }
        public string nhomLuong { get; set; }
        public float? heSoLuong { get; set; }
        public string bacLuong { get; set; }
        public float? luongCoBan { get; set; }
        public float? phuCapTrachNhiem { get; set; }
        public float? phuCapKhac { get; set; }
        public float? tongLuong { get; set; }
        public string thoiHanLenLuong { get; set; }
        public DateTime? ngayHieuLuc { get; set; }
        public DateTime? ngayKetThuc { get; set; }
        public string trangThai { get; set; }
    }
}
