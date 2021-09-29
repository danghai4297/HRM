using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Entities
{
    public class KhenThuongKyLuat
    {
        public int id { get; set; }
        public int idDanhMucKhenThuong { get; set; }
        public string noiDung { get; set; }
        public string lyDo { get; set; }
        public bool? loai { get; set; }
        public string maNhanVien { get; set; }

        public DanhMucKhenThuongKyLuat DanhMucKhenThuongKyLuat { get; set; }
        public NhanVien NhanVien { get; set; }
    }
}
