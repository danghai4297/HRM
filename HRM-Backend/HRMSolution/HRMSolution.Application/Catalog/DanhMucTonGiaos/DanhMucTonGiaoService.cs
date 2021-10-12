using HRMSolution.Application.Catalog.DanhMucTonGiaos.DtonGiaos;
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

namespace HRMSolution.Application.Catalog.DanhMucTonGiaos
{
    public class DanhMucTonGiaoService : IDanhMucTonGiaoService
    {
        private readonly HRMDbContext _context;
        public DanhMucTonGiaoService(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(DanhMucTonGiaoCreateRequest request)
        {
            var danhMucTonGiao = new DanhMucTonGiao()
            {

                tenDanhMuc = request.tenDanhMuc

            };
            _context.danhMucTonGiaos.Add(danhMucTonGiao);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int idDanhMucTonGiao)
        {
            var danhMucTonGiao = await _context.danhMucTonGiaos.FindAsync(idDanhMucTonGiao);
            if (danhMucTonGiao == null) throw new HRMException($"Không tìm thấy danh mục tôn giáo : {idDanhMucTonGiao}");

            _context.danhMucTonGiaos.Remove(danhMucTonGiao);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<DanhMucTonGiaoViewModel>> GetAll()
        {
            var query = from p in _context.danhMucTonGiaos select p;

            var data = await query.Select(x => new DanhMucTonGiaoViewModel()
            {
                id = x.id,
                tenDanhMuc = x.tenDanhMuc
            }).ToListAsync();


            return data;
        }

        public async Task<DanhMucTonGiaoViewModel> GetById(int id)
        {
            var query = from p in _context.danhMucTonGiaos select p;

            var data = await query.Select(x => new DanhMucTonGiaoViewModel()
            {
                id = x.id,
                tenDanhMuc = x.tenDanhMuc
            }).FirstAsync();


            return data;
        }

        public async Task<int> Update(DanhMucTonGiaoUpdateRequest request)
        {
            var danhMucTonGiao = await _context.danhMucTonGiaos.FindAsync(request.id);
            if (danhMucTonGiao == null) throw new HRMException($"Không tìm thấy danh mục tôn giáo có id: {request.id }");

            danhMucTonGiao.tenDanhMuc = request.tenDanhMuc;

            return await _context.SaveChangesAsync();
        }
    }
}