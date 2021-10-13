using HRMSolution.Application.Catalog.DanhMucTrinhDos.dTrinhDos;
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

namespace HRMSolution.Application.Catalog.DanhMucTrinhDos
{
    public class DanhMucTrinhDoService : IDanhMucTrinhDoService
    {
        private readonly HRMDbContext _context;
        public DanhMucTrinhDoService(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(DanhMucTrinhDoCreateRequest request)
        {
            var danhMucTrinhDo = new DanhMucTrinhDo()
            {

                tenTrinhDo = request.tenTrinhDo

            };
            _context.danhMucTrinhDos.Add(danhMucTrinhDo);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int idDanhMucTrinhDo)
        {
            var danhMucTrinhDo = await _context.danhMucTrinhDos.FindAsync(idDanhMucTrinhDo);
            if (danhMucTrinhDo == null) throw new HRMException($"Không tìm thấy danh mục trình độ : {idDanhMucTrinhDo}");

            _context.danhMucTrinhDos.Remove(danhMucTrinhDo);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<DanhMucTrinhDoViewModel>> GetAll()
        {
            var query = from p in _context.danhMucTrinhDos select p;

            var data = await query.Select(x => new DanhMucTrinhDoViewModel()
            {
                id = x.id,
                tenTrinhDo=x.tenTrinhDo
            }).ToListAsync();
            return data;
        }

        public async Task<DanhMucTrinhDoViewModel> GetById(int id)
        {
            var query = from p in _context.danhMucTrinhDos where p.id == id select p;

            var data = await query.Select(x => new DanhMucTrinhDoViewModel()
            {
                id = x.id,
                tenTrinhDo = x.tenTrinhDo
            }).FirstAsync();
            return data;
        }

        public async Task<int> Update(int id,DanhMucTrinhDoUpdateRequest request)
        {
            var danhMucTrinhDo = await _context.danhMucTrinhDos.FindAsync(id);
            if (danhMucTrinhDo == null) throw new HRMException($"Không tìm thấy danh mục trình độ có id: {id }");

            danhMucTrinhDo.tenTrinhDo = request.tenTrinhDo;

            return await _context.SaveChangesAsync();
        }
    }
}