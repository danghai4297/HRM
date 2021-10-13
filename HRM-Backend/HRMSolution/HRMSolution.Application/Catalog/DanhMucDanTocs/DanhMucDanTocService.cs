using HRMSolution.Application.Catalog.DanhMucDanTocs.Dtos;
using HRMSolution.Data.EF;
using HRMSolution.Data.Entities;
using HRMSolution.Utilities.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucDanTocs
{
    public class DanhMucDanTocService : IDanhMucDanTocService
    {
        private readonly HRMDbContext _context;
        public DanhMucDanTocService(HRMDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(DanhMucDanTocCreateRequest request)
        {
            var danhMucDanToc = new DanhMucDanToc()
            {
                tenDanhMuc = request.tenDanhMuc
            };
            _context.danhMucDanTocs.Add(danhMucDanToc);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int idDanhMucDanToc)
        {
            var danhMucDanToc = await _context.danhMucDanTocs.FindAsync(idDanhMucDanToc);
            if (danhMucDanToc == null) throw new HRMException($"Không tìm thấy danh mục Dân Tộc : {idDanhMucDanToc}");
             
            _context.danhMucDanTocs.Remove(danhMucDanToc);
            return await _context.SaveChangesAsync();
        }

<<<<<<< HEAD
        public async Task<int> Update(int id, DanhMucDanTocUpdateRequest request)
        {
            var danhMucDanToc = await _context.danhMucDanTocs.FindAsync(id);
            if (danhMucDanToc == null) throw new HRMException($"Không tìm thấy danh mục Dân Tộc có id: {id}");
=======
        public async Task<int> Update(int id,DanhMucDanTocUpdateRequest request)
        {
            var danhMucDanToc = await _context.danhMucDanTocs.FindAsync(id);
            if (danhMucDanToc == null) throw new HRMException($"Không tìm thấy danh mục Dân Tộc có id: {id }");
>>>>>>> fec998c699e1da5c5acb2a969f82391a75a1b459

            danhMucDanToc.tenDanhMuc = request.tenDanhMuc;
            return await _context.SaveChangesAsync(); 
        }

        public async Task<List<DanhMucDanTocViewModel>> GetAll()
        {
            
            var query = from p in _context.danhMucDanTocs select p;
            
            var data = await query.Select(x => new DanhMucDanTocViewModel()
            {
                id = x.id,
                tenDanhMuc = x.tenDanhMuc
            }).ToListAsync();
            

            return data;
        }

        public async Task<DanhMucDanTocViewModel> GetById(int id)
        {
            var query = from p in _context.danhMucDanTocs where p.id == id select p;

            var data = await query.Select(x => new DanhMucDanTocViewModel()
            {
                id = x.id,
                tenDanhMuc = x.tenDanhMuc
            }).FirstAsync();


            return data;
        }
    }
}
