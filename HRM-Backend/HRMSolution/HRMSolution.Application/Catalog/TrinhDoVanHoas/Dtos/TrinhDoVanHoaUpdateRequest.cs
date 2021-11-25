using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.TrinhDoVanHoas.Dtos
{
    public class TrinhDoVanHoaUpdateRequest
    {
        public string tenTruong { get; set; }
        public int idChuyenMon { get; set; }
        public DateTime tuThoiGian { get; set; }
        public DateTime denThoiGian { get; set; }
        public int idHinhThucDaoTao { get; set; }
        public int idTrinhDo { get; set; }
        public string maNhanVien { get; set; }
    }
}
