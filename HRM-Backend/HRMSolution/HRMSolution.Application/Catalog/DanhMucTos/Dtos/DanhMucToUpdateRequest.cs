﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.DanhMucTos.Dtos
{
    public class DanhMucToUpdateRequest
    {
        public string maTo { get; set; }
        public string tenTo { get; set; }
        public int idPhongBan { get; set; }
    }
}
