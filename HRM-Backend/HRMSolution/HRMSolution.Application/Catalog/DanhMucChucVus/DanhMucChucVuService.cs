
using HRMSolution.Application.Catalog.DanhMucChucVus;
using HRMSolution.Application.Catalog.DanhMucChucVus.DchucVus;
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
    public class DanhMucChucVuService : IDanhMucChucVuService
    {
        private readonly HRMDbContext _context;
        public DanhMucChucVuService(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(DanhMucChucVuCreateRequest request)
        {
            var danhMucChucVu = new DanhMucChucVu()
            {
                tenChucVu = request.tenChucVu,
                maChucVu = request.maChucVu,
                phuCap = request.phuCap
            };
            _context.danhMucChucVus.Add(danhMucChucVu);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int idDanhMucChucVu)
        {
            var danhMucChucVu = await _context.danhMucChucVus.FindAsync(idDanhMucChucVu);
            if (danhMucChucVu == null) throw new HRMException($"Không tìm thấy danh mục chức vụ : {idDanhMucChucVu}");

            _context.danhMucChucVus.Remove(danhMucChucVu);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<DanhMucChucVuViewModel>> GetAll()
        {
            var query = from p in _context.danhMucChucVus select p;

            var data = await query.Select(x => new DanhMucChucVuViewModel()
            {
                id = x.id,
                maChucVu = x.maChucVu,
                tenChucVu = x.tenChucVu,
                phuCap = x.phuCap
            }).ToListAsync();


            return data;
        }

        public async Task<DanhMucChucVuViewModel> GetById(int id)
        {
            var query = from p in _context.danhMucChucVus select p;

            var data = await query.Select(x => new DanhMucChucVuViewModel()
            {
                id = x.id,
                tenChucVu = x.tenChucVu,
                phuCap = x.phuCap
            }).FirstAsync();


            return data;
        }

        public async Task<int> Update(DanhMucChucVuUpdateRequest request)
        {
            var danhMucChucVu = await _context.danhMucChucVus.FindAsync(request.id);
            if (danhMucChucVu == null) throw new HRMException($"Không tìm thấy danh mục chức vụ có id: {request.id }");

            danhMucChucVu.maChucVu = request.maChucVu;
            danhMucChucVu.tenChucVu = request.tenChucVu;
            danhMucChucVu.phuCap = request.phuCap;
            return await _context.SaveChangesAsync();
        }
    }
}