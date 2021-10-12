
using HRMSolution.Application.Catalog.DanhMucHinhThucDaoTaos.Dtos;
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

namespace HRMSolution.Application.Catalog.DanhMucHinhThucDaoTaos
{
    public class DanhMucHinhThucDaoTaoService : IDanhMucHinhThucDaoTaoService
    {
        private readonly HRMDbContext _context;
        public DanhMucHinhThucDaoTaoService(HRMDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(DanhMucHinhThucDaoTaoCreateRequest request)
        {
            var danhMucHinhThucDaoTao = new HinhThucDaoTao()
            {
                tenHinhThuc = request.tenHinhThuc
            };
            _context.hinhThucDaoTaos.Add(danhMucHinhThucDaoTao);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int idDanhMucHinhThucDaoTao)
        {
            var danhMucHinhThucDaoTao = await _context.hinhThucDaoTaos.FindAsync(idDanhMucHinhThucDaoTao);
            if (danhMucHinhThucDaoTao == null) throw new HRMException($"Không tìm thấy danh mục hình thức đào tạo : {idDanhMucHinhThucDaoTao}");

            _context.hinhThucDaoTaos.Remove(danhMucHinhThucDaoTao);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<DanhMucHinhThucDaoTaoViewModel>> GetAll()
        {
            var query = from p in _context.hinhThucDaoTaos select p;

            var data = await query.Select(x => new DanhMucHinhThucDaoTaoViewModel()
            {
                id = x.id,
                tenHinhThuc = x.tenHinhThuc
            }).ToListAsync();


            return data;
        }

        public async Task<DanhMucHinhThucDaoTaoViewModel> GetById(int id)
        {
            var query = from p in _context.hinhThucDaoTaos select p;

            var data = await query.Select(x => new DanhMucHinhThucDaoTaoViewModel()
            {
                id = x.id,
                tenHinhThuc = x.tenHinhThuc
            }).FirstAsync();


            return data;
        }

        public async Task<int> Update(DanhMucHinhThucDaoTaoUpdateRequest request)
        {
            var danhMucHinhThucDaoTao = await _context.hinhThucDaoTaos.FindAsync(request.id);
            if (danhMucHinhThucDaoTao == null) throw new HRMException($"Không tìm thấy danh mục hình thức đào tạo có id: {request.id }");

            danhMucHinhThucDaoTao.tenHinhThuc = request.tenHinhThuc;
            return await _context.SaveChangesAsync();
        }
    }
}