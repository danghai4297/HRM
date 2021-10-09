﻿using HRMSolution.Application.Catalog.DanhMucTonGiaos.DtonGiaos;
using HRMSolution.Data.EF;
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
    }
}