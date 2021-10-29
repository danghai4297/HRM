using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.LichSus.Dtos
{
    public class LichSuViewModel
    {
        public int id { get; set; }
        public string tenTaiKhoan { get; set; }
        public string thaoTac { get; set; }
        public string maNhanVien { get; set; }
        public string tenNhanVien { get; set; }
        public DateTime ngayThucHien { get; set; }
    }
}
