
using HRMSolution.Application.Catalog.DanhMucChucDanhs.DchucDanhs;
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

namespace HRMSolution.Application.Catalog.DanhMucChucDanhs
{
    public class DanhMucChucDanhService : IDanhMucChucDanhService
    {
        private readonly HRMDbContext _context;
        public DanhMucChucDanhService(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(DanhMucChucDanhCreateRequest request)
        {
            var danhMucChucDanh = new DanhMucChucDanh()
            {
                tenChucDanh = request.tenChucDanh,
                maChucDanh = request.maChucDanh,
                phuCap = request.phuCap
            };
            _context.danhMucChucDanhs.Add(danhMucChucDanh);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int idDanhMucChucDanh)
        {
            var danhMucChucDanh = await _context.danhMucChucDanhs.FindAsync(idDanhMucChucDanh);
            if (danhMucChucDanh == null) throw new HRMException($"Không tìm thấy danh mục chức danh : {idDanhMucChucDanh}");

            _context.danhMucChucDanhs.Remove(danhMucChucDanh);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<DanhMucChucDanhViewModel>> GetAll()
        {
            var query = from p in _context.danhMucChucDanhs select p;

            var data = await query.Select(x => new DanhMucChucDanhViewModel()
            {
                id = x.id,
                maChucDanh = x.maChucDanh,
                tenChucDanh =x.tenChucDanh,
                phuCap=x.phuCap
            }).ToListAsync();


            return data;
        }

        public async Task<DanhMucChucDanhViewModel> GetById(int id)
        {
            var query = from p in _context.danhMucChucDanhs select p;

            var data = await query.Select(x => new DanhMucChucDanhViewModel()
            {
                id = x.id,
                maChucDanh = x.maChucDanh,
                tenChucDanh = x.tenChucDanh,
                phuCap = x.phuCap
            }).FirstAsync();


            return data;
        }

        public async Task<int> Update(DanhMucChucDanhUpdateRequest request)
        {
            var danhMucChucDanh = await _context.danhMucChucDanhs.FindAsync(request.id);
            if (danhMucChucDanh == null) throw new HRMException($"Không tìm thấy danh mục chức danh có id: {request.id }");

            danhMucChucDanh.maChucDanh = request.maChucDanh;
            danhMucChucDanh.tenChucDanh = request.tenChucDanh;
            danhMucChucDanh.phuCap = request.phuCap;
            return await _context.SaveChangesAsync();
        }
    }
}