﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Entities
{
    public class DanhMucPhongBan
    {
        public int id { get; set; }
        public string maPhongBan { get; set; }
        public string tenPhongBan { get; set; }
        public List<DanhMucTo> danhMucTos { get; set; }
        public List<NhanVien> nhanViens { get; set; }
    }
}
