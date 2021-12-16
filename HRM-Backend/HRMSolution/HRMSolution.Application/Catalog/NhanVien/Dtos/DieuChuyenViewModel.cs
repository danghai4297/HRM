using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.NhanViens.Dtos
{
    public class DieuChuyenViewModel
    {
        public int id { get; set; }
        public DateTime? dcNgayHieuLuc { get; set; }
        public string dcPhong { get; set; }
        public string dcTo { get; set; }
        public string dcChiTiet { get; set; }
        public string trangThai { get; set; }
    }
}
