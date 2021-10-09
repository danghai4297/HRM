﻿using HRMSolution.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using HRMSolution.Application.Catalog.DanhMucLoaiHopDongs.Dtos;
using Microsoft.EntityFrameworkCore;
using HRMSolution.Data.Entities;

namespace HRMSolution.Application.Catalog.DanhMucLoaiHopDongs
{
    public class DanhMucLoaiHopDongService : IDanhMucLoaiHopDongService
    {
        private readonly HRMDbContext _context;
        public DanhMucLoaiHopDongService(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(DanhMucLoaiHopDongCreateRequest request)
        {
            var danhMucLoaiHopDong = new DanhMucLoaiHopDong()
            {
                maLoaiHopDong=request.maLoaiHopDong,
                tenLoaiHopDong = request.tenLoaiHopDong

            };
            _context.danhMucLoaiHopDongs.Add(danhMucLoaiHopDong);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<DanhMucLoaiHopDongViewModel>> GetAll()
        {
            var query = from p in _context.danhMucLoaiHopDongs
                        select p;
            var data = await query.Select(x => new DanhMucLoaiHopDongViewModel()
            {
                id = x.id,
                maLoaiHopDong = x.maLoaiHopDong,
                tenLoaiHopDong = x.tenLoaiHopDong
            }).ToListAsync();

            return data;
        }
    }
}
