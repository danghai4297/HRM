﻿
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Entities
{
    public class NguoiThan
    {
        public int id { get; set; }
        public string tenNguoiThan { get; set; }
        public bool gioiTinh { get; set; }
        public DateTime ngaySinh { get; set; }
        public int quanHe { get; set; }
        public string ngheNghiep { get; set; }
        public string diaChi { get; set; }
        public string dienThoai { get; set; }
        public string khac { get; set; }

        public string maNhanVien { get; set; }
        public int idDanhMucNguoiThan { get; set; }

        public NhanVien nhanVien { get; set; }
        public DanhMucNguoiThan danhMucNguoiThan { get; set; }
    }
}
