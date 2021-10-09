using HRMSolution.Application.Catalog.DanhMucChucDanhs;
using HRMSolution.Application.Catalog.DanhMucChucDanhs.DchucDanhs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSolution.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucChucDanhController: ControllerBase
    {
        private readonly IDanhMucChucDanhService _danhMucChucDanhService;
        public DanhMucChucDanhController(IDanhMucChucDanhService danhMucChucDanhService)
        {
            _danhMucChucDanhService = danhMucChucDanhService;
        }
<<<<<<< HEAD

        [HttpGet]
=======
        [HttpGet()]
>>>>>>> b8e6e78fb57d80658a20020cbbe1000a8b084e4a
        public async Task<IActionResult> Get()
        {
            var danhMucChucDanh = await _danhMucChucDanhService.GetAll();
            return Ok(danhMucChucDanh);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]DanhMucChucDanhCreateRequest request)
        {
            var result = await _danhMucChucDanhService.Create(request);
            if (result == 0)
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
