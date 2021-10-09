using HRMSolution.Application.Catalog.DanhMucTinhChatLaoDongs.DtinhChatLaoDongs;
using HRMSolution.Data.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucTinhChatLaoDongs
{
    public class DanhMucTinhChatLaoDongService : IDanhMucTinhChatLaoDongService
    {
        private readonly HRMDbContext _context;
        public DanhMucTinhChatLaoDongService(HRMDbContext context)
        {
            _context = context;
        }
        public async Task<List<DanhMucTinhChatLaoDongViewModel>> GetAll()
        {
            var query = from p in _context.danhMucTinhChatLaoDongs select p;

            var data = await query.Select(x => new DanhMucTinhChatLaoDongViewModel()
            {
                id = x.id,
                tenLaoDong = x.tenTinhChat
            }).ToListAsync();
            return data;
        }
    }
}