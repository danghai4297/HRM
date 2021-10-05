using HRMSolution.Application.Catalog.DanhMucDanTocs;
using HRMSolution.Application.Catalog.DanhMucDanTocs.Dtos;
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
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var danhMucDanToc = await _danhMucDanTocService.GetAll();
            return Ok(danhMucDanToc);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]DanhMucDanTocCreateRequest request)
        {
            var result = await _danhMucDanTocService.Create(request);
            if(result == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
            
        }
    }
}
