﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.DanhMucChucVus.DchucVus
{
    public class DanhMucChucVuUpdateRequest
    {
        public int id { get; set; }
        public string maChucVu { get; set; }
        public string tenChucVu { get; set; }
        public float phuCap { get; set; }
    }
}
