using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.NhanViens.Dtos
{
    public class YTeCreateRequest
    {
        public string yt_nhomMau { get; set; }
        public float? yt_chieuCao { get; set; }
        public float? yt_canNang { get; set; }
        public string yt_tinhTrangSucKhoe { get; set; }
        public string yt_benhTat { get; set; }
        public string yt_luuY { get; set; }
        public bool? yt_khuyetTat { get; set; }
        public string yt_maNhanVien { get; set; }
    }
}
