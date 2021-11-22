using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HRMSolution.Application.Catalog.DanhMucChucDanhs.DchucDanhs
{
    public class DanhMucChucDanhCreateRequest
    {

        [Required]
        public string maChucDanh { get; set; }
        [Required]
        public string tenChucDanh { get; set; }
        public float phuCap { get; set; }
    }
}
