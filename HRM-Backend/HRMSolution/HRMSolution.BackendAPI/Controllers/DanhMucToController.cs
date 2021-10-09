using HRMSolution.Application.Catalog.DanhMucTos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSolution.BackendAPI.Controllers
{
    
        [Route("api/[controller]")]
        [ApiController]
        public class DanhMucToController : ControllerBase
        {
            private readonly IDanhMucToService _danhMucToService;
            public DanhMucToController(IDanhMucToService danhMucToService)
            {
                _danhMucToService = danhMucToService;
            }
            [HttpGet]
            public async Task<IActionResult> Get()
            {
                var danhMucTo = await _danhMucToService.GetAll();
                return Ok(danhMucTo);
            }

        }
    
}
