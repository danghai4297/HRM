using HRMSolution.Application.Catalog.DanhMucHonNhans.DhonNhans;
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

namespace HRMSolution.Application.Catalog.DanhMucHonNhans
{
    public class DanhMucHonNhanService : IDanhMucHonNhanService
    {
        private readonly HRMDbContext _context;
        public DanhMucHonNhanService(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(DanhMucHonNhanCreateRequest request)
        {
            var danhMucHonNhan = new DanhMucHonNhan()
            {
                tenDanhMuc = request.tenDanhMuc
               
            };
            _context.danhMucHonNhans.Add(danhMucHonNhan);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int idDanhMucHonNhan)
        {
            var danhMucHonNhan = await _context.danhMucHonNhans.FindAsync(idDanhMucHonNhan);
            if (danhMucHonNhan == null) throw new HRMException($"Không tìm thấy danh mục hôn nhân : {idDanhMucHonNhan}");

            _context.danhMucHonNhans.Remove(danhMucHonNhan);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<DanhMucHonNhanViewModel>> GetALL()
        {
            var query = from p in _context.danhMucHonNhans select p;

            var data = await query.Select(x => new DanhMucHonNhanViewModel()
            {
                id = x.id,
                tenDanhMuc = x.tenDanhMuc
            }).ToListAsync();


            return data;
        }

        public async Task<int> Update(DanhMucHonNhanUpdateRequest request)
        {
            var danhMucHonNhan = await _context.danhMucHonNhans.FindAsync(request.id);
            if (danhMucHonNhan == null) throw new HRMException($"Không tìm thấy danh mục hôn nhân có id: {request.id }");

            danhMucHonNhan.tenDanhMuc = request.tenDanhMuc;
            return await _context.SaveChangesAsync();
        }
    }
}