using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Entities
{
    public class LienHeKhanCap
    {
        public int id { get; set; }
        public string hoTen { get; set; }
        public int quanHe { get; set; }
        public string dienThoai { get; set; }
        public string email { get; set; }
        public string diaChi { get; set; }
        public string maNhanVien { get; set; }
        public NhanVien NhanVien { get; set; }
    }
}
