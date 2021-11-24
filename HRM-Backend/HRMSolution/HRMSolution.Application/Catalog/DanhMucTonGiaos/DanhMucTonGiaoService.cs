﻿using HRMSolution.Application.Catalog.DanhMucTonGiaos.DtonGiaos;
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
            if (request.tenDanhMuc == null)
            {
                return 0;
            }
            else
            {
                var danhMucTonGiao = new DanhMucTonGiao()
                {
                    tenDanhMuc = request.tenDanhMuc
                };
                _context.danhMucTonGiaos.Add(danhMucTonGiao);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }

        public async Task<int> Delete(int idDanhMucTonGiao)
        {
            var danhMucTonGiao = await _context.danhMucTonGiaos.FindAsync(idDanhMucTonGiao);
            if (danhMucTonGiao == null)
            {
                return 0;
            }
            else
            {
                _context.danhMucTonGiaos.Remove(danhMucTonGiao);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }

        public async Task<List<DanhMucTonGiaoViewModel>> GetAll()
        {
            var query = from p in _context.danhMucTonGiaos select p;
            if (query == null)
            {
                return null;
            }
            else
            {
                var data = await query.Select(x => new DanhMucTonGiaoViewModel()
                {
                    id = x.id,
                    tenDanhMuc = x.tenDanhMuc
                }).ToListAsync();
                return data;
            }
        }

        public async Task<DanhMucTonGiaoViewModel> GetById(int id)
        {
            var danhMucTonGiao = await _context.danhMucTonGiaos.FindAsync(id);
            if (danhMucTonGiao == null)
            {
                return null;
            }
            else
            {
                var query = from p in _context.danhMucTonGiaos where p.id == id select p;
                var data = await query.Select(x => new DanhMucTonGiaoViewModel()
                {
                    id = x.id,
                    tenDanhMuc = x.tenDanhMuc
                }).FirstAsync();
                return data;
            }
        }

        public async Task<int> Update(int id, DanhMucTonGiaoUpdateRequest request)
        {
            var danhMucTonGiao = await _context.danhMucTonGiaos.FindAsync(id);
            if (danhMucTonGiao == null || request.tenDanhMuc == null)
            {
                return 0;
            }
            else
            {
                danhMucTonGiao.tenDanhMuc = request.tenDanhMuc;
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }
    }
}
