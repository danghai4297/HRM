using HRMSolution.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using HRMSolution.Application.Catalog.DanhMucLoaiHopDongs.Dtos;
using Microsoft.EntityFrameworkCore;
using HRMSolution.Data.Entities;
using HRMSolution.Utilities.Exceptions;

namespace HRMSolution.Application.Catalog.DanhMucLoaiHopDongs
{
    public class DanhMucLoaiHopDongService : IDanhMucLoaiHopDongService
    {
        private readonly HRMDbContext _context;
        public DanhMucLoaiHopDongService(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(DanhMucLoaiHopDongCreateRequest request)
        {
            var danhMucLoaiHopDong = new DanhMucLoaiHopDong()
            {
                maLoaiHopDong=request.maLoaiHopDong,
                tenLoaiHopDong = request.tenLoaiHopDong

            };
            _context.danhMucLoaiHopDongs.Add(danhMucLoaiHopDong);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int idDanhMucLoaiHopDong)
        {
            var danhMucLoaiHopDong = await _context.danhMucLoaiHopDongs.FindAsync(idDanhMucLoaiHopDong);
            if (danhMucLoaiHopDong == null) throw new HRMException($"Không tìm thấy danh mục hôn nhân : {idDanhMucLoaiHopDong}");

            _context.danhMucLoaiHopDongs.Remove(danhMucLoaiHopDong);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<DanhMucLoaiHopDongViewModel>> GetAll()
        {
            var query = from p in _context.danhMucLoaiHopDongs
                        select p;
            var data = await query.Select(x => new DanhMucLoaiHopDongViewModel()
            {
                id = x.id,
                maLoaiHopDong = x.maLoaiHopDong,
                tenLoaiHopDong = x.tenLoaiHopDong
            }).ToListAsync();

            return data;
        }

        public async Task<DanhMucLoaiHopDongViewModel> GetById(int id)
        {
            var query = from p in _context.danhMucLoaiHopDongs where p.id == id select p;

            var data = await query.Select(x => new DanhMucLoaiHopDongViewModel()
            {
                id = x.id,
                maLoaiHopDong = x.maLoaiHopDong,
                tenLoaiHopDong = x.tenLoaiHopDong
            }).FirstAsync();


            return data;
        }

        public async Task<int> Update(int id,DanhMucLoaiHopDongUpdateRequest request)
        {
            var danhMucLoaiHopDong = await _context.danhMucLoaiHopDongs.FindAsync(id);
            if (danhMucLoaiHopDong == null) throw new HRMException($"Không tìm thấy danh mục hôn nhân có id: {id }");

            danhMucLoaiHopDong.maLoaiHopDong = request.maLoaiHopDong;
            danhMucLoaiHopDong.tenLoaiHopDong = request.tenLoaiHopDong;
            return await _context.SaveChangesAsync();
        }
    }
}
