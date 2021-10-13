using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Entities
{
    public class LichSuBanThan
    {
        public int lsbt_id { get; set; }
        public string lsbt_biBatDiTu { get; set; }
        public string lsbt_thamGiaChinhTri { get; set; }
        public string lsbt_thanNhanNuocNgoai { get; set; }

        public string lsbt_maNhanVien { get; set; }
        public NhanVien NhanVien { get; set; }

    }
}
