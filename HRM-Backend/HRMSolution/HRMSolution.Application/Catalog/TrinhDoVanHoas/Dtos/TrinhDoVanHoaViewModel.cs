using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.TrinhDoVanHoas.Dtos
{
    public class TrinhDoVanHoaViewModel
    {
        public int id { get; set; }
        public string tenTruong { get; set; }
        public string chuyenMon { get; set; }
        public DateTime? tuThoiGian { get; set; }
        public DateTime? denThoiGian { get; set; }
        public string hinhThucDaoTao { get; set; }
        public string trinhDo { get; set; }
        public string maNhanVien { get; set; }
        public string tenNhanVien { get; set; }
    }
}
