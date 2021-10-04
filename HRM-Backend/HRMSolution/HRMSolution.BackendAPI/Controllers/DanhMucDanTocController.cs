using HRMSolution.Application.Catalog.DanhMucDanTocs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSolution.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucDanTocController : ControllerBase
    {
        private readonly IDanhMucDanTocService _danhMucDanTocService;
        public DanhMucDanTocController(IDanhMucDanTocService danhMucDanTocService) {
            _danhMucDanTocService = danhMucDanTocService;
        }
        public async Task<IActionResult> Get()
        {
            var danhMucDanToc =  _danhMucDanTocService.GetAll();
            return Ok(danhMucDanToc);
        }
    }
}
