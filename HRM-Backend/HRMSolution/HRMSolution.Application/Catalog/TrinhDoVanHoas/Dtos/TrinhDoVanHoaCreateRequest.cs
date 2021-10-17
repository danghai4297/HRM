using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.TrinhDoVanHoas.Dtos
{
    public class TrinhDoVanHoaCreateRequest
    {
        public string tenTruong { get; set; }
        public int idChuyenMon { get; set; }
        public string tuThoiGian { get; set; }
        public string denThoiGian { get; set; }
        public int idHinhThucDaoTao { get; set; }
        public int idTrinhDo { get; set; }
        public string maNhanVien { get; set; }
    }
}
