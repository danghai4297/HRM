﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.HopDongs.Dtos
{
    public class HopDongCreateRequest
    {
        public int idCre { get; set; }
        public string maHopDong { get; set; }
        public int idLoaiHopDong { get; set; }
        public int idChucDanh { get; set; }
        public int idChucVu { get; set; }
        public DateTime hopDongTuNgay { get; set; }
        public DateTime hopDongDenNgay { get; set; }
        public string ghiChu { get; set; }
        public bool trangThai { get; set; }
        public string maNhanVien { get; set; }
    }
}
