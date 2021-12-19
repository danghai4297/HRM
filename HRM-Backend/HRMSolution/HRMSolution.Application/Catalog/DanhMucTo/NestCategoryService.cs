using HRMSolution.Application.Catalog.DanhMucTos.Dtos;
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

namespace HRMSolution.Application.Catalog.DanhMucTos
{
    public class NestCategoryService : INestCategoryService
    {
        private readonly HRMDbContext _context;
        public NestCategoryService(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(DanhMucToCreateRequest request)
        {
            char[] charsToTrim = { '*', ' ', '\'' };
            var tenDanhMuc = request.tenTo.Trim(charsToTrim);
            var checkPB = await _context.danhMucPhongBans.Where(x => x.id == request.idPhongBan).FirstOrDefaultAsync();
            var check = await _context.danhMucTos.Where(x => x.tenTo == request.tenTo && x.idPhongBan == checkPB.id).FirstOrDefaultAsync();
            if (request.maTo == null || request.tenTo == null || check != null)
            {
                return 0;
            }
            else
            {
                var danhMucTo = new DanhMucTo()
                {
                    maTo = request.maTo,
                    tenTo = tenDanhMuc,
                    idPhongBan = request.idPhongBan
                };
                _context.danhMucTos.Add(danhMucTo);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }

        public async Task<int> Delete(int idDanhMucTo)
        {
            var danhMucTo = await _context.danhMucTos.FindAsync(idDanhMucTo);
            if (danhMucTo == null)
            {
                return 0;
            }
            else
            {
                _context.danhMucTos.Remove(danhMucTo);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }

        public async Task<List<DanhMucToViewModel>> GetAll()
        {
            var query = from p in _context.danhMucTos
                        join pb in _context.danhMucPhongBans on p.idPhongBan equals pb.id
                        select new { p, pb };
            if (query == null)
            {
                return null;
            }
            else
            {
                var data = await query.Select(x => new DanhMucToViewModel()
                {
                    id = x.p.idTo,
                    maTo = x.p.maTo,
                    tenTo = x.p.tenTo,
                    idPhongBan = x.p.idPhongBan,
                    tenPhongBan = x.pb.tenPhongBan,
                    maPhongBan = x.pb.maPhongBan
                }).ToListAsync();
                return data;
            }
        }

        public async Task<DanhMucToViewModel> GetDetail(int id)
        {
            var danhMucTo = await _context.danhMucTos.FindAsync(id);

            if (danhMucTo == null)
            {
                return null;
            }
            else
            {
                var query = from p in _context.danhMucTos
                            join pb in _context.danhMucPhongBans on p.idPhongBan equals pb.id
                            where p.idTo == id
                            select new { p, pb };
                var check = await _context.dieuChuyens.Where(x => x.to == id).FirstOrDefaultAsync();
                var data = await query.Select(x => new DanhMucToViewModel()
                {
                    id = x.p.idTo,
                    maTo = x.p.maTo,
                    tenTo = x.p.tenTo,
                    idPhongBan = x.p.idPhongBan,
                    tenPhongBan = x.pb.tenPhongBan,
                    maPhongBan = x.pb.maPhongBan,
                    trangThai = check == null ? "Chưa sử dụng" : "Đang sử dụng"
                }).FirstAsync();
                return data;
            }
        }

        public async Task<int> Update(int id, DanhMucToUpdateRequest request)
        {
            char[] charsToTrim = { '*', ' ', '\'' };
            var tenDanhMuc = request.tenTo.Trim(charsToTrim);
            var danhMucTo = await _context.danhMucTos.FindAsync(id);
            var checkPB = await _context.danhMucPhongBans.Where(x => x.id == request.idPhongBan).FirstOrDefaultAsync();
            var check = await _context.danhMucTos.Where(x => x.tenTo == request.tenTo && x.idPhongBan == checkPB.id).FirstOrDefaultAsync();
            if (danhMucTo == null || request.maTo == null || request.tenTo == null || check != null)
            {
                return 0;
            }
            else
            {
                danhMucTo.maTo = request.maTo;
                danhMucTo.tenTo = tenDanhMuc;
                danhMucTo.idPhongBan = request.idPhongBan;
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                    return 0;
                else
                    return 1;
            }
        }
    }
}
