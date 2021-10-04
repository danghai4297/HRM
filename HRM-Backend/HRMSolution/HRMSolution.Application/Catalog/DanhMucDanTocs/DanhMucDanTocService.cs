﻿using HRMSolution.Application.Catalog.DanhMucDanTocs.Dtos;
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

        public async Task<int> Update(DanhMucDanTocUpdateRequest request)
        {
            var danhMucDanToc = await _context.danhMucDanTocs.FindAsync(request.id);
            if (danhMucDanToc == null) throw new HRMException($"Không tìm thấy danh mục Dân Tộc có id: {request.id }");

            danhMucDanToc.tenDanhMuc = request.tenDanhMuc;
            return await _context.SaveChangesAsync(); 
        }

        public List<DanhMucDanToc> GetAll()
        {
            
            var danhMucDanToc = _context.danhMucDanTocs.ToList();
            return danhMucDanToc;
        }


        
    }
}
