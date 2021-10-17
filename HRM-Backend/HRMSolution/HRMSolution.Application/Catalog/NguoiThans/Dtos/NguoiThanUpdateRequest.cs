using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.NguoiThans.Dtos
{
    public class NguoiThanUpdateRequest
    {
        public int idDanhMucNguoiThan { get; set; }
        public string tenNguoiThan { get; set; }
        public bool? gioiTinh { get; set; }
        public string ngaySinh { get; set; }
        public string quanHe { get; set; }
        public string ngheNghiep { get; set; }
        public string diaChi { get; set; }
        public string dienThoai { get; set; }
        public string khac { get; set; }
        public string maNhanVien { get; set; }
    }
}
