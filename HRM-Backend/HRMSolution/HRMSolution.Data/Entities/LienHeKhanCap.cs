using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Entities
{
    public class LienHeKhanCap
    {
        public int lhkc_id { get; set; }
        public string lhkc_hoTen { get; set; }
        public string lhkc_quanHe { get; set; }
        public string lhkc_dienThoai { get; set; }
        public string lhkc_email { get; set; }
        public string lhkc_diaChi { get; set; }
        public string lhkc_maNhanVien { get; set; }
        public NhanVien NhanVien { get; set; }
    }
}
