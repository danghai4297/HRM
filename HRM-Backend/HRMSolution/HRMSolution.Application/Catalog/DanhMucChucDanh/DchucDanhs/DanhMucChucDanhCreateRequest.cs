using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HRMSolution.Application.Catalog.DanhMucChucDanhs.DchucDanhs
{
    public class DanhMucChucDanhCreateRequest
    {

        public string maChucDanh { get; set; }
        public string tenChucDanh { get; set; }
        public float phuCap { get; set; }
    }
}
