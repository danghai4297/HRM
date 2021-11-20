using HRMSolution.Application.Catalog.DanhMucDanTocs;
using HRMSolution.Application.Catalog.DanhMucDanTocs.Dtos;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class DanhMucDanTocController : ControllerBase
    {
        private readonly IDanhMucDanTocService _danhMucDanTocService;
        public DanhMucDanTocController(IDanhMucDanTocService danhMucDanTocService) {
            _danhMucDanTocService = danhMucDanTocService;
        }
        [HttpGet()]
        public async Task<IActionResult> GetAllCategory()
        {
            var danhMucDanToc = await _danhMucDanTocService.GetAll();
            return Ok(danhMucDanToc);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var danhMucDanToc = await _danhMucDanTocService.GetById(id);
            if (danhMucDanToc == null)
                return BadRequest("Không tìm thấy Danh mục dân tộc");
            return Ok(danhMucDanToc);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody]DanhMucDanTocCreateRequest request)
        {
            var dmdt = await _danhMucDanTocService.Create(request);
            if(dmdt == 0)
                return BadRequest();
            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _danhMucDanTocService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id,DanhMucDanTocUpdateRequest request)
        {
            var result = await _danhMucDanTocService.Update(id,request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

    }
}
