using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.HopDongs.Dtos
{
    public class HopDongUpdateBangChungRequest
    {
        public IFormFile bangChung { get; set; }
        public string tenFile { get; set; }
    }
}
