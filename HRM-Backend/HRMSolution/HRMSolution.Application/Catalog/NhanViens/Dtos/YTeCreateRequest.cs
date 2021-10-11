using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.NhanViens.Dtos
{
    public class YTeCreateRequest
    {
        public string nhomMau { get; set; }
        public float? chieuCao { get; set; }
        public float? canNang { get; set; }
        public string tinhTrangSucKhoe { get; set; }
        public string benhTat { get; set; }
        public string luuY { get; set; }
        public bool? khuyetTat { get; set; }
        public string maNhanVien { get; set; }
    }
}
