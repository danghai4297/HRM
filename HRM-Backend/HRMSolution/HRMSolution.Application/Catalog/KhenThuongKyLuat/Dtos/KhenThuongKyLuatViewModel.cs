using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.KhenThuongKyLuats.Dtos
{
    public class KhenThuongKyLuatViewModel
    {
        public int id { get; set; }
        public string DanhMucKhenThuong { get; set; }
        public string noiDung { get; set; }
        public string lyDo { get; set; }
        public string loai { get; set; }
        public string bangChung { get; set; }
        public string maNhanVien { get; set; }
        public string hoTen { get; set; }
        public int idDanhMucKhenThuong { get; set; }
        public string anh { get; set; }

    }
}
