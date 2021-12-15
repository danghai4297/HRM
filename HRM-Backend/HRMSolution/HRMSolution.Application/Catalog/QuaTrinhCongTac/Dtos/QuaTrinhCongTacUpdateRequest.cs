using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.DieuChuyens.Dtos
{
    public class QuaTrinhCongTacUpdateRequest
    {
        public string ngayHieuLuc { get; set; }
        public int idPhongBan { get; set; }
        public int to { get; set; }
        public string chiTiet { get; set; }
        public bool trangThai { get; set; }
        public string maNhanVien { get; set; }
        public IFormFile bangChung { get; set; }
        public string tenFile { get; set; }
    }
}
