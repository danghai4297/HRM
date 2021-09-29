using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Entities
{
    public class DanhMucNguoiThan
    {
        public int id { get; set; }
        public string tenDanhMuc { get; set; }
        public List<NguoiThan> nguoiThans { get; set; }
    }
}
