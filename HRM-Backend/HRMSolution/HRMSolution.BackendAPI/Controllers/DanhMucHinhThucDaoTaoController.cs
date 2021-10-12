using HRMSolution.Application.Catalog.DanhMucHinhThucDaoTaos;
using HRMSolution.Application.Catalog.DanhMucHinhThucDaoTaos.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSolution.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucHinhThucDaoTaoController: ControllerBase
    {
        private readonly IDanhMucHinhThucDaoTaoService _danhMucHinhThucDaoTaoService;
        public DanhMucHinhThucDaoTaoController(IDanhMucHinhThucDaoTaoService danhMucHinhThucDaoTaoService)
        {
            _danhMucHinhThucDaoTaoService = danhMucHinhThucDaoTaoService;
        }
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var danhMucHinhThucDaoTao = await _danhMucHinhThucDaoTaoService.GetAll();
            return Ok(danhMucHinhThucDaoTao);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DanhMucHinhThucDaoTaoCreateRequest request)
        {
            var dmhtdt = await _danhMucHinhThucDaoTaoService.Create(request);
            if (dmhtdt == 0)
                return BadRequest();
            return Ok();

        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _danhMucHinhThucDaoTaoService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DanhMucHinhThucDaoTaoUpdateRequest request)
        {
            var result = await _danhMucHinhThucDaoTaoService.Update(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
