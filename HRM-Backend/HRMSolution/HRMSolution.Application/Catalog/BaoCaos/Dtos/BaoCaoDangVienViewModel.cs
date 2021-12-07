﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.BaoCaos.Dtos
{
    public class BaoCaoDangVienViewModel
    {
        public string id { get; set; }
        public string hoTen { get; set; }
        public string gioiTinh { get; set; }
        public DateTime ngaySinh { get; set; }
        public string dienThoai { get; set; }
        public DateTime? ngayVaoDangChinhThuc { get; set; }
        public string tenPhongBan { get; set; }
    }
}
