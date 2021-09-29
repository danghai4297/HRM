﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Entities
{
    public class DieuChuyen
    {
        public int id { get; set; }
        public string maNhanVien { get; set; }
        public DateTime? ngayHieuLuc { get; set; }
        public int phong { get; set; }
        public int to { get; set; }
        public string chiTiet { get; set; }
        public int idChucVu { get; set; }

        public DanhMucChucVu DanhMucChucVu { get; set; }
        public NhanVien NhanVien { get; set; }
    }
}
