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
    public class DanhMucToService : IDanhMucToService
    {
        private readonly HRMDbContext _context;
        public DanhMucToService(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(DanhMucToCreateRequest request)
        {
            var danhMucTo = new DanhMucTo()
            {
                maTo = request.maTo,
                tenTo = request.tenTo,
                idPhongBan = request.idPhongBan
            };
            _context.danhMucTos.Add(danhMucTo);
            return await _context.SaveChangesAsync();
        }

        public Task<int> Delete(int idDanhMucTo)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DanhMucToViewModel>> GetAll()
        {
            var query = from p in _context.danhMucTos
                        join pb in _context.danhMucPhongBans on p.idPhongBan equals pb.id
                        select new { p, pb };

            var data = await query.Select(x => new DanhMucToViewModel()
            {
                id = x.p.idTo,
                maTo = x.p.maTo,
                tenTo=x.p.tenTo,
                idPhongBan=x.p.idPhongBan,
                tenPhongBan = x.pb.tenPhongBan
            }).ToListAsync();
            return data;
        }

        public async Task<DanhMucToViewModel> GetDetail(int id)
        {
            var query = from p in _context.danhMucTos
                        join pb in _context.danhMucPhongBans on p.idPhongBan equals pb.id
                        select new { p, pb };

            var data = await query.Select(x => new DanhMucToViewModel()
            {
                id = x.p.idTo,
                maTo = x.p.maTo,
                tenTo = x.p.tenTo,
                idPhongBan = x.p.idPhongBan,
                tenPhongBan = x.pb.tenPhongBan
            }).FirstAsync();
            return data;
        }

        public async Task<int> Update(DanhMucToUpdateRequest request)
        {
            var danhMucTo = await _context.danhMucTos.FindAsync(request.idTo);
            if (danhMucTo == null) throw new HRMException($"Không tìm thấy danh mục tổ có id: {request.idTo }");

            danhMucTo.maTo = request.maTo;
            danhMucTo.tenTo = request.tenTo;
            danhMucTo.idPhongBan = request.idPhongBan;
            

            return await _context.SaveChangesAsync();
            
        }
    }
}