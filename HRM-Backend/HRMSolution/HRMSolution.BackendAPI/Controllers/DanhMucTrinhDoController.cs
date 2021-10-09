using HRMSolution.Application.Catalog.DanhMucTrinhDos;
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

    }

}
