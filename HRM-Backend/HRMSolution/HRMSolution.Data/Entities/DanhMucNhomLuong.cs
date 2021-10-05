using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Entities
{
    public class DanhMucNhomLuong
    {
        public int id { get; set; }
        public string maNhomLuong { get; set; }
        public string tenNhomLuong { get; set; }
        public List<Luong> Luongs { get; set; }
    }
}
