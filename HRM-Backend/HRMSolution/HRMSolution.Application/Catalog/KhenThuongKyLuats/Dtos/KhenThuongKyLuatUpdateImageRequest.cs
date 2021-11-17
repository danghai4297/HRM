using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.KhenThuongKyLuats.Dtos
{
    public class KhenThuongKyLuatUpdateImageRequest
    {
        public IFormFile anh { get; set; }
    }
}
