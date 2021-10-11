using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.NhanViens.Dtos
{
    public class LienHeKhanCapCreateRequest
    {
        public string hoTen { get; set; }
        public string quanHe { get; set; }
        public string dienThoai { get; set; }
        public string email { get; set; }
        public string diaChi { get; set; }
        public string maNhanVien { get; set; }
    }
}
