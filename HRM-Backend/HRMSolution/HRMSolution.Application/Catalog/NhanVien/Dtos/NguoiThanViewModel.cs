using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.NhanViens.Dtos
{
    public class NguoiThanViewModel
    {
        public int id { get; set; }
        public string ntTenNguoiThan { get; set; }
        public string ntGioiTinh { get; set; }
        public DateTime? ntNgaySinh { get; set; }
        public string ntQuanHe { get; set; }
        public string ntNgheNghiep { get; set; }
        public string ntDiaChi { get; set; }
        public string ntDienThoai { get; set; }
        public string ntKhac { get; set; }
    }
}
