using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.NhanViens.Dtos
{
    public class TrinhDoVanHoaViewModel
    {
        public string tdvhTenTruong { get; set; }
        public string tdvhChuyenMon { get; set; }
        public DateTime? tdvhtuThoiGian { get; set; }
        public DateTime? tdvhdenThoiGian { get; set; }
        public string tdvhHinhThucDaoTao { get; set; }
        public string tdvhTrinhDo { get; set; }
    }
}
