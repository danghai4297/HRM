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
            var check = await _context.danhMucTinhChatLaoDongs.Where(x => x.tenTinhChat == request.tenLaoDong).FirstOrDefaultAsync();
            if (request.tenLaoDong == null || check != null)
            {
                return 0;
            }
            else
            {
                var danhMucTinhChatLaoDong = new DanhMucTinhChatLaoDong()
                {
                    tenTinhChat = request.tenLaoDong
                };
                _context.danhMucTinhChatLaoDongs.Add(danhMucTinhChatLaoDong);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }

        public async Task<int> Delete(int idDanhMucTinhChatLaoDong)
        {
            var danhMucTinhChatLaoDong = await _context.danhMucTinhChatLaoDongs.FindAsync(idDanhMucTinhChatLaoDong);
            if (danhMucTinhChatLaoDong == null)
            {
                return 0;
            }
            else
            {
                _context.danhMucTinhChatLaoDongs.Remove(danhMucTinhChatLaoDong);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }

        public async Task<List<DanhMucTinhChatLaoDongViewModel>> GetAll()
        {
            var query = from p in _context.danhMucTinhChatLaoDongs select p;
            if (query == null)
            {
                return null;
            }
            else
            {
                var data = await query.Select(x => new DanhMucTinhChatLaoDongViewModel()
                {
                    id = x.id,
                    tenLaoDong = x.tenTinhChat
                }).ToListAsync();
                return data;
            }
        }

        public async Task<DanhMucTinhChatLaoDongViewModel> GetById(int id)
        {
            var danhMucTinhChatLaoDong = await _context.danhMucTinhChatLaoDongs.FindAsync(id);
            if (danhMucTinhChatLaoDong == null)
            {
                return null;
            }
            else
            {
                var query = from p in _context.danhMucTinhChatLaoDongs where p.id == id select p;
                var check = await _context.nhanViens.Where(x => x.tinhChatLaoDong == id).FirstOrDefaultAsync();
                var data = await query.Select(x => new DanhMucTinhChatLaoDongViewModel()
                {
                    id = x.id,
                    tenLaoDong = x.tenTinhChat,
                    trangThai = check == null ? "Chưa sử dụng" : "Đang sử dụng"
                }).FirstAsync();
                return data;
            }
        }

        public async Task<int> Update(int id, DanhMucTinhChatLaoDongUpdateRequest request)
        {
            var danhMucTinhChatLaoDong = await _context.danhMucTinhChatLaoDongs.FindAsync(id);
            if (danhMucTinhChatLaoDong == null || request.tenLaoDong == null)
            {
                return 0;
            }
            else
            {
                danhMucTinhChatLaoDong.tenTinhChat = request.tenLaoDong;
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }
    }
}
