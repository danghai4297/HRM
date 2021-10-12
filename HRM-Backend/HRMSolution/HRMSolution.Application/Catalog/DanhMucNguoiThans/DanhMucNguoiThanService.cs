using HRMSolution.Application.Catalog.DanhMucNguoiThans.Dtos;
using HRMSolution.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HRMSolution.Data.Entities;
using HRMSolution.Utilities.Exceptions;

namespace HRMSolution.Application.Catalog.DanhMucNguoiThans
{
    public class DanhMucNguoiThanService : IDanhMucNguoiThanService
    {
        private readonly HRMDbContext _context;
        public DanhMucNguoiThanService(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(DanhMucNguoiThanCreateRequest request)
        {
            var danhMucNguoiThan = new DanhMucNguoiThan()
            {
                tenDanhMuc = request.tenDanhMuc

            };
            _context.danhMucNguoiThans.Add(danhMucNguoiThan);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int idDanhMucNguoiThan)
        {
            var danhMucNguoiThan = await _context.danhMucNguoiThans.FindAsync(idDanhMucNguoiThan);
            if (danhMucNguoiThan == null) throw new HRMException($"Không tìm thấy danh mục người thân : {idDanhMucNguoiThan}");

            _context.danhMucNguoiThans.Remove(danhMucNguoiThan);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<DanhMucNguoiThanViewModel>> GetAll()
        {
            var query = from p in _context.danhMucNguoiThans select p;

            var data = await query.Select(x => new DanhMucNguoiThanViewModel()
            {
                id = x.id,
                tenDanhMuc = x.tenDanhMuc
            }).ToListAsync();


            return data;
        }

        public async Task<DanhMucNguoiThanViewModel> GetById(int id)
        {
            var query = from p in _context.danhMucNguoiThans select p;

            var data = await query.Select(x => new DanhMucNguoiThanViewModel()
            {
                id = x.id,
                tenDanhMuc = x.tenDanhMuc
            }).FirstAsync();


            return data;
        }

        public async Task<int> Update(DanhMucNguoiThanUpdateRequest request)
        {
            var danhMucNguoiThan = await _context.danhMucNguoiThans.FindAsync(request.id);
            if (danhMucNguoiThan == null) throw new HRMException($"Không tìm thấy danh mục người thân có id: {request.id }");

            danhMucNguoiThan.tenDanhMuc = request.tenDanhMuc;
            return await _context.SaveChangesAsync();
        }
    }
}
