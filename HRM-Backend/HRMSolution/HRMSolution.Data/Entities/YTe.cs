using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Entities
{
    public class YTe
    {
        public int id { get; set; }
        public string nhomMau { get; set; }
        public float? chieuCao { get; set; }
        public float? canNang { get; set; }
        public string tinhTrangSucKhoe { get; set; }
        public string benhTat { get; set; }
        public string luuY { get; set; }
        public bool? khuyetTat { get; set; }
        public string maNhanVien { get; set; }
        public NhanVien NhanVien { get; set; }
    }
}
