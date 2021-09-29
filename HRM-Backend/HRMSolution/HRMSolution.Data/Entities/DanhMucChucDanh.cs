using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Entities
{
    public class DanhMucChucDanh
    {
        public int id { get; set; }
        public string maChucDanh { get; set; }
        public string tenChucDanh { get; set; }
        public float phuCap { get; set; }
        public List<HopDong> HopDongs { get; set; }
    }
}
