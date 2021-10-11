using HRMSolution.Application.Catalog.DanhMucTinhChatLaoDongs.DtinhChatLaoDongs;
using HRMSolution.Data.EF;
using HRMSolution.Data.Entities;
using HRMSolution.Utilities.Exceptions;
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

        public async Task<int> Create(DanhMucTinhChatLaoDongCreateRequest request)
        {
            var danhMucTinhChatLaoDong = new DanhMucTinhChatLaoDong()
            {
                
                tenTinhChat = request.tenLaoDong

            };
            _context.danhMucTinhChatLaoDongs.Add(danhMucTinhChatLaoDong);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int idDanhMucTinhChatLaoDong)
        {
            var danhMucTinhChatLaoDong = await _context.danhMucTinhChatLaoDongs.FindAsync(idDanhMucTinhChatLaoDong);
            if (danhMucTinhChatLaoDong == null) throw new HRMException($"Không tìm thấy danh mục tính chất lao động : {idDanhMucTinhChatLaoDong}");

            _context.danhMucTinhChatLaoDongs.Remove(danhMucTinhChatLaoDong);
            return await _context.SaveChangesAsync();
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

        public async Task<int> Update(DanhMucTinhChatLaoDongUpdateRequest request)
        {
            var danhMucTinhChatLaoDong = await _context.danhMucTinhChatLaoDongs.FindAsync(request.id);
            if (danhMucTinhChatLaoDong == null) throw new HRMException($"Không tìm thấy danh mục phòng ban có id: {request.id }");

            danhMucTinhChatLaoDong.tenTinhChat = request.tenLaoDong;
            
            return await _context.SaveChangesAsync();
        }
    }
}