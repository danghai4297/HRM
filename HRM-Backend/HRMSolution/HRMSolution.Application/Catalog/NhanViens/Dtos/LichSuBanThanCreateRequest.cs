using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.NhanViens.Dtos
{
    public class LichSuBanThanCreateRequest
    {
        public string lsbt_biBatDiTu { get; set; }
        public string lsbt_thamGiaChinhTri { get; set; }
        public string lsbt_thanNhanNuocNgoai { get; set; }

        public string lsbt_maNhanVien { get; set; }
    }
}
