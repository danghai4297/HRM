using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.DanhMucLoaiHopDongs.Dtos
{
    public class DanhMucLoaiHopDongUpdateRequest
    {
        public int id { get; set; }
        public string maLoaiHopDong { get; set; }
        public string tenLoaiHopDong { get; set; }
    }
}
