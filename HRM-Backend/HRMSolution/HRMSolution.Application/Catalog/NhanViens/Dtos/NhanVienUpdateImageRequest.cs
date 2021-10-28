using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.NhanViens.Dtos
{
    public class NhanVienUpdateImageRequest
    {
        public IFormFile anh { get; set; }
    }
}
