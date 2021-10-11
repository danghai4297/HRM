﻿using HRMSolution.Application.Catalog.NgoaiNgus.Dtos;
using HRMSolution.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HRMSolution.Application.Catalog.NgoaiNgus
{
    public class NgoaiNguService : INgoaiNguService
    {
        private readonly HRMDbContext _context;
        public NgoaiNguService(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<NgoaiNguViewModel> GetNgoaiNgu(int id)
        {
            var query = from p in _context.ngoaiNgus
                        join dmnn in _context.danhMucNgoaiNgus on p.idDanhMucNgoaiNgu equals dmnn.id
                        where p.id == id
                        select new { p, dmnn };


            var data = await query.Select(x => new NgoaiNguViewModel()
            {
                id = x.p.id,
                danhMucNgoaiNgu = x.dmnn.tenDanhMuc,
                ngayCap = x.p.ngayCap,
                trinhDo = x.p.trinhDo,
                noiCap = x.p.noiCap
            }).FirstAsync();

            return data;
        }
    }
}
