using HRMSolution.Application.Catalog.DanhMucTrinhDos;
using HRMSolution.Application.Catalog.DanhMucTrinhDos.dTrinhDos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSolution.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucTrinhDoController : ControllerBase
    {
        private readonly IDanhMucTrinhDoService _danhMucTrinhDoService;
        public DanhMucTrinhDoController(IDanhMucTrinhDoService danhMucTrinhDoService)
        {
            _danhMucTrinhDoService = danhMucTrinhDoService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var danhMucTrinhDo = await _danhMucTrinhDoService.GetAll();
            return Ok(danhMucTrinhDo);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DanhMucTrinhDoCreateRequest request)
        {
            var result = await _danhMucTrinhDoService.Create(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _danhMucTrinhDoService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _danhMucTrinhDoService.GetById(id);
            if (result == null)
                return BadRequest("Không tìm thấy Danh mục trình độ");
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DanhMucTrinhDoUpdateRequest request)
        {
            var result = await _danhMucTrinhDoService.Update(request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }

}
