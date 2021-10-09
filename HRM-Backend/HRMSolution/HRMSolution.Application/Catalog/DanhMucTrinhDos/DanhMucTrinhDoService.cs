﻿using HRMSolution.Application.Catalog.DanhMucTrinhDos.dTrinhDos;
using HRMSolution.Data.EF;
using HRMSolution.Data.Entities;
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
    }
}