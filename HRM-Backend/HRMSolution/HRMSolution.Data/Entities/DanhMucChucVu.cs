using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Entities
{
    public class DanhMucChucVu
    {
        public int id { get; set; }
        public string maChucVu { get; set; }
        public string tenChucVu { get; set; }
        public float phuCap { get; set; }
        public List<HopDong> HopDongs { get; set; }
    }
}
