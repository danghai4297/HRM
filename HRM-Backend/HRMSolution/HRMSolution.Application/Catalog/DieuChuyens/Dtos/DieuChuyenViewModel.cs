using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.DieuChuyens.Dtos
{
    public class DieuChuyenViewModel
    {
        public int id { get; set; }
        public string maNhanVien { get; set; }
        public DateTime? ngayHieuLuc { get; set; }
        public string idPhongBan { get; set; }
        public string to { get; set; }
        public string chiTiet { get; set; }
        public string idChucVu { get; set; }
        public string trangThai { get; set; }
        public string tenNhanVien { get; set; }
    }
}
