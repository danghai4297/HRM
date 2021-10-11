using HRMSolution.Application.Catalog.TrinhDoVanHoas;
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
    public class TrinhDoVanHoaController : ControllerBase
    {
        private readonly ITrinhDoVanHoaService _trinhDoVanHoaService;
        public TrinhDoVanHoaController(ITrinhDoVanHoaService trinhDoVanHoaService)
        {
            _trinhDoVanHoaService = trinhDoVanHoaService;
        }
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var trinhDoVanHoa = await _trinhDoVanHoaService.GetAll();
            return Ok(trinhDoVanHoa);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            var trinhDoVanHoa = await _trinhDoVanHoaService.GetAllById(id);
            return Ok(trinhDoVanHoa);
        }
    }
}
