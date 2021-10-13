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
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var danhMucDanToc = await _danhMucDanTocService.GetAll();
            return Ok(danhMucDanToc);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var danhMucDanToc = await _danhMucDanTocService.GetById(id);
            if (danhMucDanToc == null)
                return BadRequest("Không tìm thấy Danh mục dân tộc");
            return Ok(danhMucDanToc);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]DanhMucDanTocCreateRequest request)
        {
            var dmdt = await _danhMucDanTocService.Create(request);
            if(dmdt == 0)
                return BadRequest();
            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _danhMucDanTocService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

<<<<<<< HEAD
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, DanhMucDanTocUpdateRequest request)
        {
            var result = await _danhMucDanTocService.Update(id, request);
=======
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,DanhMucDanTocUpdateRequest request)
        {
            var result = await _danhMucDanTocService.Update(id,request);
>>>>>>> fec998c699e1da5c5acb2a969f82391a75a1b459
            if (result == 0)
                return BadRequest();
            return Ok();
        }

    }
}
