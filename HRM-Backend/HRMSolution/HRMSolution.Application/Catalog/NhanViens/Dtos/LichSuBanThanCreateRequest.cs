using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.NhanViens.Dtos
{
    public class LichSuBanThanCreateRequest
    {
        public string biBatDiTu { get; set; }
        public string thamGiaChinhTri { get; set; }
        public string thanNhanNuocNgoai { get; set; }

        public string maNhanVien { get; set; }
    }
}
