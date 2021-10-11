using HRMSolution.Application.Catalog.DanhMucPhongBans.DphongBans;
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

namespace HRMSolution.Application.Catalog.DanhMucPhongBans
{
    public class DanhMucPhongBanService : IDanhMucPhongBanService
    {
        private readonly HRMDbContext _context;
        public DanhMucPhongBanService(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(DanhMucPhongBanCreateRequest request)
        {
            var danhMucPhongBan = new DanhMucPhongBan()
            {
                maPhongBan = request.maPhongBan,
                tenPhongBan = request.tenPhongBan

            };
            _context.danhMucPhongBans.Add(danhMucPhongBan);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int idDanhMucPhongBan)
        {
            var danhMucPhongBan = await _context.danhMucPhongBans.FindAsync(idDanhMucPhongBan);
            if (danhMucPhongBan == null) throw new HRMException($"Không tìm thấy danh mục phòng ban : {idDanhMucPhongBan}");

            _context.danhMucPhongBans.Remove(danhMucPhongBan);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<DanhMucPhongBanViewModel>> GetAll()
        {
            var query = from p in _context.danhMucPhongBans select p;

            var data = await query.Select(x => new DanhMucPhongBanViewModel()
            {
                id = x.id,
                maPhongBan = x.maPhongBan,
                tenPhongBan = x.tenPhongBan
            }).ToListAsync();


            return data;
        }

        public async Task<int> Update(DanhMucPhongBanUpdateRequest request)
        {
            var danhMucPhongBan = await _context.danhMucPhongBans.FindAsync(request.id);
            if (danhMucPhongBan == null) throw new HRMException($"Không tìm thấy danh mục phòng ban có id: {request.id }");

            danhMucPhongBan.maPhongBan = request.maPhongBan;
            danhMucPhongBan.tenPhongBan = request.tenPhongBan;
            return await _context.SaveChangesAsync();
        }
    }
}