using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Entities
{
    public class LichSu
    {
        public int id { get; set; }
        public string tenTaiKhoan { get; set; }
        public string thaoTac { get; set; }
        public string hanhDong { get; set; }
        public string maNhanVien { get; set; }
        public DateTime ngayThucHien { get; set; }
    }
}
