using HRMSolution.Application.Catalog.DanhMucNhomLuongs.DnhomLuongs;
using HRMSolution.Data.EF;
using HRMSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucNhomLuongs
{
    public class DanhMucNhomLuongService : IDanhMucNhomLuongService
    {
        private readonly HRMDbContext _context;
        public DanhMucNhomLuongService(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(DanhMucNhomLuongCreateRequest request)
        {
            var danhMucNhomLuong = new DanhMucNhomLuong()
            {
                maNhomLuong=request.maNhomLuong,
                tenNhomLuong = request.tenNhomLuong

            };
            _context.danhMucNhomLuongs.Add(danhMucNhomLuong);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<DanhMucNhomLuongViewModel>> GetAll()
        {
            var query = from p in _context.danhMucNhomLuongs select p;

            var data = await query.Select(x => new DanhMucNhomLuongViewModel()
            {
                id = x.id,
                maNhomLuong = x.maNhomLuong,
                tenNhomLuong= x.tenNhomLuong
            }).ToListAsync();


            return data;
        }
    }
}