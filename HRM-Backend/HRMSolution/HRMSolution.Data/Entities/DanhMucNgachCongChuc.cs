using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Entities
{
    public class DanhMucNgachCongChuc
    {
        public int id { get; set; }
        public string tenNgach { get; set; }
        public List<NhanVien> nhanViens { get; set; }
    }
}
