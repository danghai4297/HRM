using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.NgoaiNgus.Dtos
{
    public class NgoaiNguUpdateRequest
    {
        public int idDanhMucNgoaiNgu { get; set; }
        public string ngayCap { get; set; }
        public string trinhDo { get; set; }
        public string noiCap { get; set; }
        public string maNhanVien { get; set; }
    }
}
