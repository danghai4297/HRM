using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Entities
{
    public class NgoaiNgu
    {
        public int id { get; set; }
        public int idDanhMucNgoaiNgu { get; set; }
        public DateTime ngayCap { get; set; }
        public string trinhDo { get; set; }
        public string noiCap { get; set; }
        public string maNhanVien { get; set; }
        public DanhMucNgoaiNgu danhMucNgoaiNgu { get; set; }
        public NhanVien NhanVien { get; set; }
    }
}
