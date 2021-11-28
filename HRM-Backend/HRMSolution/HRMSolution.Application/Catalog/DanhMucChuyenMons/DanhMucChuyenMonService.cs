
using HRMSolution.Application.Catalog.DanhMucChuyenMons.DchuyenMons;
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

namespace HRMSolution.Application.Catalog.DanhMucChuyenMons
{
    public class DanhMucChuyenMonService : IDanhMucChuyenMonService
    {
        private readonly HRMDbContext _context;
        public DanhMucChuyenMonService(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(DanhMucChuyenMonCreateRequest request)
        {
            if (request.maChuyenMon == null || request.tenChuyenMon == null)
            {
                return 0;
            }
            else
            {
                var danhMucChuyenMon = new DanhMucChuyenMon()
                {
                    tenChuyenMon = request.tenChuyenMon,
                    maChuyenMon = request.maChuyenMon
                };
                _context.danhMucChuyenMons.Add(danhMucChuyenMon);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }

        public async Task<int> Delete(int idDanhMucChuyenMon)
        {
            var danhMucChuyenMon = await _context.danhMucChuyenMons.FindAsync(idDanhMucChuyenMon);
            if (danhMucChuyenMon == null)
            {
                return 0;
            }
            else
            {
                _context.danhMucChuyenMons.Remove(danhMucChuyenMon);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }

        public async Task<List<DanhMucChuyenMonViewModel>> GetAll()
        {
            var query = from p in _context.danhMucChuyenMons select p;
            if (query == null)
            {
                return null;
            }
            else
            {
                var data = await query.Select(x => new DanhMucChuyenMonViewModel()
                {
                    id = x.id,
                    tenChuyenMon = x.tenChuyenMon,
                    maChuyenMon = x.maChuyenMon
                }).ToListAsync();
                return data;
            }
        }

        public async Task<DanhMucChuyenMonViewModel> GetById(int id)
        {
            var danhMucChuyenMon = await _context.danhMucChuyenMons.FindAsync(id);
            if (danhMucChuyenMon == null)
            {
                return null;
            }
            else
            {
                var query = from p in _context.danhMucChuyenMons where p.id == id select p;
                var check = await _context.trinhDoVanHoas.Where(x => x.idChuyenMon == id).FirstOrDefaultAsync();
                var data = await query.Select(x => new DanhMucChuyenMonViewModel()
                {
                    id = x.id,
                    maChuyenMon = x.maChuyenMon,
                    tenChuyenMon = x.tenChuyenMon,
                    trangThai = check == null ? "Chưa sử dụng" : "Đang sử dụng"
                }).FirstAsync();
                return data;
            }
        }

        public async Task<int> Update(int id, DanhMucChuyenMonUpdateRequest request)
        {
            var danhMucChuyenMon = await _context.danhMucChuyenMons.FindAsync(id);
            if (danhMucChuyenMon == null || request.maChuyenMon == null || request.tenChuyenMon == null)
            {
                return 0;
            }
            else
            {
                danhMucChuyenMon.maChuyenMon = request.maChuyenMon;
                danhMucChuyenMon.tenChuyenMon = request.tenChuyenMon;
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }
    }
}
