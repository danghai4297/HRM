using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.Luongs.Dtos
{
    public class LuongUpdateBangChungRequest
    {
        public IFormFile bangChung { get; set; }
    }
}
