using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.NgoaiNgus.Dtos
{
    public class NgoaiNguViewModel
    {
        public int id { get; set; }
        public string danhMucNgoaiNgu { get; set; }
        public DateTime? ngayCap { get; set; }
        public string trinhDo { get; set; }
        public string noiCap { get; set; }
        public string maNhanVien { get; set; }
        public string tenNhanVien { get; set; }
    }
}
