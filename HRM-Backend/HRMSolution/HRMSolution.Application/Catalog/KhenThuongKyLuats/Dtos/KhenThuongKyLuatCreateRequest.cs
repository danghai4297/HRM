using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.KhenThuongKyLuats.Dtos
{
    public class KhenThuongKyLuatCreateRequest
    {
        public int idDanhMucKhenThuong { get; set; }
        public string noiDung { get; set; }
        public string lyDo { get; set; }
        public bool loai { get; set; }
        public IFormFile bangChung { get; set; }
        public string maNhanVien { get; set; }
    }
}
