using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.NguoiThans.Dtos
{
    public class NguoiThanViewModel
    {
        public int id { get; set; }
        public string tenNguoiThan { get; set; }
        public string gioiTinh { get; set; }
        public DateTime? ngaySinh { get; set; }
        public string danhMucNguoiThan { get; set; }
        public string quanHe { get; set; }
        public string ngheNghiep { get; set; }
        public string diaChi { get; set; }
        public string dienThoai { get; set; }
        public string khac { get; set; }

        public string maNhanVien { get; set; }
        public string tenNhanVien { get; set; }
    }
}
