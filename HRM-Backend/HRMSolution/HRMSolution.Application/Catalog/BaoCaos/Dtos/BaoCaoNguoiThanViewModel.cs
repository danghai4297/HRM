using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.BaosCao.Dtos
{
    public class BaoCaoNguoiThanViewModel
    {
        public string id { get; set; }
        public string hoTen { get; set; }
        public string dienThoai { get; set; }
        public int nt_id { get; set; }
        public string nt_tenNguoiThan { get; set; }
        public string nt_gioiTinh { get; set; }
        public DateTime nt_ngaySinh { get; set; }
        public string nt_quanHe { get; set; }
        public string nt_ngheNghiep { get; set; }
        public string nt_diaChi { get; set; }
        public string nt_dienThoai { get; set; }
        public string nt_khac { get; set; }
        public string nt_tenDanhMucNguoiThan { get; set; }
        public string tenPhongBan { get; set; }
    }
}
