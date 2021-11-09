using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Entities
{
    public class LichSuBanThan
    {
        public int id { get; set; }
        public string biBatDiTu { get; set; }
        public string thamGiaChinhTri { get; set; }
        public string thanNhanNuocNgoai { get; set; }

        public string maNhanVien { get; set; }
        public NhanVien NhanVien { get; set; }

    }
}
