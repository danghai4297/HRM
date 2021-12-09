using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.DieuChuyens.Dtos
{
    public class QuaTrinhCongTacViewModel
    {
        public int id { get; set; }
        public string maNhanVien { get; set; }
        public DateTime? ngayHieuLuc { get; set; }
        public string PhongBan { get; set; }
        public string to { get; set; }
        public string chiTiet { get; set; }
        public string trangThai { get; set; }
        public string tenNhanVien { get; set; }
        public int idPhongBan { get; set; }

        public int idTo { get; set; }
        public string bangChung { get; set; }
    }
}
