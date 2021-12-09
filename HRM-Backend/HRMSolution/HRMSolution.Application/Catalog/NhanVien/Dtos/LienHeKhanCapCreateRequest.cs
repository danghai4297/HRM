using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.NhanViens.Dtos
{
    public class LienHeKhanCapCreateRequest
    {
        public string hoTen { get; set; }
        public string lhkc_quanHe { get; set; }
        public string lhkc_dienThoai { get; set; }
        public string lhkc_email { get; set; }
        public string lhkc_diaChi { get; set; }
        public string lhkc_maNhanVien { get; set; }
    }
}
