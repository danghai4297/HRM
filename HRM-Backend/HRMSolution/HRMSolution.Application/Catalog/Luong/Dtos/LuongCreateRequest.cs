using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.Luongs.Dtos
{
    public class LuongCreateRequest
    {
        public string maHopDong { get; set; }
        public int idNhomLuong { get; set; }
        public float heSoLuong { get; set; }
        public string bacLuong { get; set; }
        public float luongCoBan { get; set; }
        public float phuCapChucVu { get; set; }
        public float phuCapChucDanh { get; set; }
        public float? phuCapTrachNhiem { get; set; }
        public float? phuCapKhac { get; set; }
        public float tongLuong { get; set; }
        public string thoiHanLenLuong { get; set; }
        public string ngayHieuLuc { get; set; }
        public string ngayKetThuc { get; set; }
        public string ghiChu { get; set; }
        public bool trangThai { get; set; }
        public IFormFile bangChung { get; set; }
        public string tenFile { get; set; }
    }
}
