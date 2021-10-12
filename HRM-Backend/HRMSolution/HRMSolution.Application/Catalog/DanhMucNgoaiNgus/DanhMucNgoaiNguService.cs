
using HRMSolution.Application.Catalog.DanhMucNgoaiNgus.Dtos;
using HRMSolution.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HRMSolution.Data.Entities;
using HRMSolution.Utilities.Exceptions;

namespace HRMSolution.Application.Catalog.DanhMucNgoaiNgus
{
    public class DanhMucNgoaiNguService : IDanhMucNgoaiNguService
    {
        private readonly HRMDbContext _context;
        public DanhMucNgoaiNguService(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(DanhMucNgoaiNguCreateRequest request)
        {
            var danhMucNgoaiNgu = new DanhMucNgoaiNgu()
            {
                tenDanhMuc = request.tenDanhMuc

            };
            _context.danhMucNgoaiNgus.Add(danhMucNgoaiNgu);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int idDanhMucNgoaiNgu)
        {
            var danhMucNgoaiNgu = await _context.danhMucNgoaiNgus.FindAsync(idDanhMucNgoaiNgu);
            if (danhMucNgoaiNgu == null) throw new HRMException($"Không tìm thấy danh mục ngoại ngữ : {idDanhMucNgoaiNgu}");

            _context.danhMucNgoaiNgus.Remove(danhMucNgoaiNgu);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<DanhMucNgoaiNguViewModel>> GetAll()
        {
            var query = from p in _context.danhMucNgoaiNgus select p;

            var data = await query.Select(x => new DanhMucNgoaiNguViewModel()
            {
                id = x.id,
                tenDanhMuc = x.tenDanhMuc
            }).ToListAsync();


            return data;
        }

        public async Task<DanhMucNgoaiNguViewModel> GetById(int id)
        {
            var query = from p in _context.danhMucNgoaiNgus select p;

            var data = await query.Select(x => new DanhMucNgoaiNguViewModel()
            {
                id = x.id,
                tenDanhMuc = x.tenDanhMuc
            }).FirstAsync();


            return data;
        }

        public async Task<int> Update(DanhMucNgoaiNguUpdateRequest request)
        {
            var danhMucNgoaiNgu = await _context.danhMucNgoaiNgus.FindAsync(request.id);
            if (danhMucNgoaiNgu == null) throw new HRMException($"Không tìm thấy danh mục ngoại ngữ có id: {request.id }");

            danhMucNgoaiNgu.tenDanhMuc = request.tenDanhMuc;
            return await _context.SaveChangesAsync();
        }
    }
}
